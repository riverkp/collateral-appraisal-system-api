# 🧠 What is Domain-Driven Design (DDD)?
DDD is a way to design software based on the business domain. The idea is to model your code closely to the real-world business you're solving problems for, using Ubiquitous Language, Bounded Contexts, and rich domain models.

# 📚 Key Concepts of DDD
## Ubiquitous Language
Ubiquitous Language is a shared language between developers and domain experts. It helps everyone understand the domain better and ensures that the code reflects the business concepts accurately.
## Bounded Contexts
Bounded Contexts are boundaries within which a particular model is defined and applicable. They help to separate different parts of the system, allowing teams to work independently on different contexts without confusion.

Example:
`Loan`, `Collateral`, `CustomerProfile`, and `RiskEvaluation` may be separate Bounded Contexts in your bank system.

## Entities and Value Objects
Entities are objects that have a distinct identity and lifecycle, while Value Objects are immutable objects that describe characteristics or attributes without an identity. Entities can change over time, while Value Objects are defined by their attributes.

### Entity
- Has identity (ID) that stays the same over time.
- Can change values, but is still the same "thing".

```csharp
public class AppraisalRequest
{
public Guid Id { get; private set; }
public RequestDetail Detail { get; private set; }
public DateTime CreatedAt { get; private set; }

    public void UpdatePurpose(string newPurpose)
    {
        Detail = Detail.WithNewPurpose(newPurpose); // assuming immutable VO
    }
}
```

### Value Object
- No identity, defined by its attributes.
- Immutable, meaning once created, it cannot change.

```csharp
public record RequestDetail(string Purpose, string Channel)
{
    public RequestDetail WithNewPurpose(string newPurpose) =>
        this with { Purpose = newPurpose };
}
```

## Aggregates
Aggregates are clusters of related entities and value objects that are treated as a single unit for data changes. They help maintain consistency within the domain model by defining boundaries for transactions.

Example:
`AppraisalRequest` is the root; you update `RequestDetail` only through it.

## Domain Events
Domain Events are events that signify a change in the state of the domain. They help to decouple different parts of the system and allow for asynchronous processing of changes.

Example:
`AppraisalRequestSubmitted`, `AppraisalCompleted`.


## Repositories
Repositories are responsible for retrieving and storing aggregates. They provide an abstraction layer over the data storage, allowing the domain model to remain clean and focused on business logic.

- Abstracts database.
- Deals only with aggregate roots.

```csharp
public interface IAppraisalRequestRepository
{
    AppraisalRequest? GetById(Guid id);
    void Add(AppraisalRequest request);
    void Save(AppraisalRequest request);
}
```

```csharp
// Infrastructure Layer
public class EfAppraisalRequestRepository : IAppraisalRequestRepository
{
    private readonly AppraisalDbContext _context;

    public EfAppraisalRequestRepository(AppraisalDbContext context)
    {
        _context = context;
    }

    public AppraisalRequest? GetById(Guid id)
    {
        return _context.AppraisalRequests
            .Include(r => r.SomeChildEntityIfNeeded)
            .FirstOrDefault(r => r.Id == id);
    }

    public void Add(AppraisalRequest request)
    {
        _context.AppraisalRequests.Add(request);
    }

    public void Update(AppraisalRequest request)
    {
        _context.AppraisalRequests.Update(request);
    }
}
```

## Domain Services
Services are domain logic that doesn't naturally fit within an entity or value object. They encapsulate business operations and can be used to coordinate actions across multiple aggregates or entities.

```csharp
public class ValuationService
{
    public decimal EstimateValue(IEnumerable<Collateral> comps) { ... }
}
```

## Factories
Factories are responsible for creating complex objects or aggregates. They encapsulate the creation logic, ensuring that the domain model remains clean and focused on business rules rather than instantiation details.

# 🔷 DDD Learning Roadmap
## 1. Core DDD Concepts
- ✅ Entity, Value Object, Aggregate Root
- ✅ Domain Service vs Application Service
- ✅ Repository Pattern
- ✅ Ubiquitous Language
- ✅ Aggregate Lifecycle

## 2. Strategic DDD
- Bounded Contexts
- Context Maps (how domains relate to each other)
- Ubiquitous Language per context
- Anti-corruption layer (ACL)

## 3. Tactical Patterns in Depth
- 🧱 Aggregate design best practices (invariants, consistency boundaries)
- 📦 Factory Pattern vs Constructor
- 🧮 Domain Events: modeling and raising them properly
- 🔍 Specification Pattern for reusable business rules
- 🧾 Event Sourcing (optional if you want advanced audit)

## 4. Modular Monolith / Vertical Slice Architecture
- How to align modules = bounded contexts
- How to make vertical slice folders clean (feature → domain + app)
- Decoupling via interfaces and domain-only dependencies

## 5. DDD + CQRS + Event-Driven Design
- Use Command = change, Query = read
- Handlers work with aggregates via repo
- Raise Domain Events, publish Integration Events
- Orchestrate workflows with Domain Event Handlers

# 🚀 Advanced DDD Patterns and Best Practices

## Domain Events - Advanced Implementation
Domain Events are first-class citizens in this system with automatic dispatch and integration event translation.

### Domain Event Infrastructure
```csharp
// Base domain event with metadata
public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName!;
}

// Aggregate manages its own events
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    public readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public IDomainEvent[] ClearDomainEvents() 
    {
        var events = _domainEvents.ToArray();
        _domainEvents.Clear();
        return events;
    }
}
```

### Event Dispatch Pattern
Events are automatically dispatched during save operations:
```csharp
public class DispatchDomainEventInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(...)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
```

### Domain-to-Integration Event Translation
Domain events are translated to integration events for cross-module communication:
```csharp
public class RequestCreatedEventHandler : INotificationHandler<RequestCreatedEvent>
{
    public async Task Handle(RequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        var integrationEvent = new RequestCreatedIntegrationEvent
        {
            RequestId = notification.Request.Id,
            Purpose = notification.Request.Detail.Purpose
        };
        await bus.Publish(integrationEvent, cancellationToken);
    }
}
```

## Repository Pattern with Decorators
The system implements the decorator pattern for cross-cutting concerns like caching:

```csharp
// Repository registration with decorator
services.AddScoped<IRequestRepository, RequestRepository>();
services.Decorate<IRequestRepository, CachedRequestRepository>();

// Caching decorator implementation
public class CachedRequestRepository(IRequestRepository repository, IDistributedCache cache) 
    : IRequestRepository
{
    public async Task<Request> GetRequest(long requestId, bool asNoTracking = true, ...)
    {
        if (!asNoTracking) return await repository.GetRequest(requestId, asNoTracking, cancellationToken);
        
        var cachedRequest = await cache.GetStringAsync(requestId.ToString(), cancellationToken);
        if (!string.IsNullOrEmpty(cachedRequest))
            return JsonSerializer.Deserialize<Request>(cachedRequest)!;
            
        var request = await repository.GetRequest(requestId, asNoTracking, cancellationToken);
        await cache.SetStringAsync(requestId.ToString(), JsonSerializer.Serialize(request), cancellationToken);
        
        return request;
    }
}
```

## Value Object Design Patterns

### Factory Methods with Validation
```csharp
public record RequestDetail
{
    private RequestDetail(string purpose, bool hasAppraisalBook, ...) { }
    
    // Factory method enforces invariants
    public static RequestDetail Of(string purpose, bool hasAppraisalBook, ...)
    {
        ArgumentNullException.ThrowIfNull(purpose);
        ArgumentNullException.ThrowIfNull(priority);
        
        return new RequestDetail(purpose, hasAppraisalBook, ...);
    }
    
    // Immutable updates
    public RequestDetail WithNewPurpose(string newPurpose) =>
        Of(newPurpose, HasAppraisalBook, Priority, ...);
}
```

### Composite Value Objects
```csharp
public record LoanDetail(string? LoanApplicationNo, decimal? LimitAmt, decimal? TotalSellingPrice);
public record Address(string Street, string City, string State, string ZipCode);
public record Contact(string ContactPersonName, string ContactPersonContactNo, string? ProjectCode);
```

## Aggregate Invariants and Business Rules

### Encapsulated State Changes
```csharp
public class Request : Aggregate<long>
{
    private readonly List<RequestCustomer> _customers = [];
    public IReadOnlyList<RequestCustomer> Customers => _customers.AsReadOnly();
    
    // Business rule enforcement
    public void AddCustomer(RequestCustomer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);
        
        if (_customers.Any(c => c.Id == customer.Id))
            throw new InvalidOperationException("Customer already exists in the request.");
            
        _customers.Add(customer);
    }
    
    // Status transitions with business rules
    public void UpdateStatus(string status)
    {
        ArgumentException.ThrowIfNullOrEmpty(status);
        
        // Add business rule validation here
        Status = status;
    }
}
```

### Rich Entity Behavior
```csharp
public class RequestCustomer : Entity<long>
{
    public void Update(string name, string contactNumber)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(contactNumber);
        
        Name = name;
        ContactNumber = contactNumber;
    }
}
```

## Domain Services and Cross-Cutting Concerns

### Validation Pipeline as Domain Service
```csharp
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f is not null).ToList();
        
        if (failures.Count > 0)
            throw new ValidationException(failures);
            
        return await next(cancellationToken);
    }
}
```

### Audit Trail Pattern
```csharp
public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private void UpdateEntities(DbContext? context)
    {
        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = DateTime.Now;
                entry.Entity.CreatedBy = "System";
            }
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedOn = DateTime.Now;
                entry.Entity.UpdatedBy = "System";
            }
        }
    }
}
```

## CQRS Implementation Patterns

### Command/Query Separation
```csharp
// Command interfaces
public interface ICommand<out TResponse> : IRequest<TResponse> { }
public interface ICommand : ICommand<Unit> { }

// Query interface
public interface IQuery<out T> : IRequest<T> where T : notnull { }

// Command implementation
public record CreateRequestCommand(...) : ICommand<CreateRequestResult>;

// Command handler
internal class CreateRequestHandler : ICommandHandler<CreateRequestCommand, CreateRequestResult>
{
    public async Task<CreateRequestResult> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
    {
        var request = CreateNewRequest(command);
        dbContext.Requests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateRequestResult(request.Id);
    }
}
```

## Domain Exception Handling

### Domain-Specific Exceptions
```csharp
public class RequestNotFoundException(long id) : NotFoundException("Request", id) { }

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"{name} ({key}) not found.") { }
}

// Usage in domain
public void UpdateRequest(long id, RequestDetail detail)
{
    var request = requests.FirstOrDefault(r => r.Id == id) 
        ?? throw new RequestNotFoundException(id);
    
    request.UpdateDetail(detail);
}
```

## Integration Events for Cross-Module Communication

### Integration Event Base Class
```csharp
public record IntegrationEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}

// Cross-module event
public record RequestCreatedIntegrationEvent : IntegrationEvent
{
    public long RequestId { get; set; }
    public string Purpose { get; set; }
    public string Channel { get; set; }
}
```

### Event Consumers
```csharp
public class RequestCreatedIntegrationEventHandler : IConsumer<RequestCreatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<RequestCreatedIntegrationEvent> context)
    {
        // Handle cross-module concerns
        var message = context.Message;
        // Process the event...
    }
}
```

# 🚨 DDD Anti-Patterns to Avoid

## ❌ Anemic Domain Model
Don't create entities that only have getters/setters without behavior:
```csharp
// BAD - Anemic
public class Request
{
    public string Status { get; set; }
    public void SetStatus(string status) => Status = status;
}

// GOOD - Rich Domain Model
public class Request
{
    public string Status { get; private set; }
    public void Submit() 
    {
        if (Status != "Draft") throw new InvalidOperationException();
        Status = "Submitted";
        AddDomainEvent(new RequestSubmittedEvent(this));
    }
}
```

## ❌ Repository as Data Access Layer
Don't expose IQueryable or database-specific concerns:
```csharp
// BAD
public interface IRequestRepository
{
    IQueryable<Request> GetAll();
    void ExecuteSql(string sql);
}

// GOOD
public interface IRequestRepository
{
    Task<Request> GetById(long id);
    Task<IEnumerable<Request>> GetByStatus(string status);
    Task Save(Request request);
}
```

## ❌ God Aggregates
Don't create aggregates that manage too many entities:
```csharp
// BAD - Too many responsibilities
public class Request
{
    public List<Customer> AllCustomers { get; set; }
    public List<Product> AllProducts { get; set; }
    public List<Order> AllOrders { get; set; }
    // ... hundreds of properties
}

// GOOD - Focused aggregate
public class Request
{
    public RequestDetail Detail { get; private set; }
    public List<RequestCustomer> Customers { get; private set; }
    // Only what's needed for request consistency
}
```

## ❌ Domain Logic in Application Services
Keep domain logic in the domain layer:
```csharp
// BAD - Business logic in application service
public class CreateRequestHandler
{
    public async Task Handle(CreateRequestCommand command)
    {
        if (command.Purpose == "Loan" && command.Amount > 1000000)
            throw new Exception("Loan amount too high");
        
        var request = new Request();
        request.Purpose = command.Purpose;
        // ... more business logic
    }
}

// GOOD - Domain logic in aggregate
public class Request
{
    public static Request CreateLoanRequest(string purpose, decimal amount)
    {
        if (purpose == "Loan" && amount > 1000000)
            throw new DomainException("Loan amount exceeds limit");
        
        return new Request(purpose, amount);
    }
}
```

# 🎯 Advanced DDD Concepts

## Specification Pattern
Use specifications for complex business rules and query conditions:

```csharp
public abstract class Specification<T>
{
    public abstract bool IsSatisfiedBy(T entity);
    public abstract Expression<Func<T, bool>> ToExpression();
    
    public Specification<T> And(Specification<T> other) => new AndSpecification<T>(this, other);
    public Specification<T> Or(Specification<T> other) => new OrSpecification<T>(this, other);
}

// Business rule as specification
public class HighValueRequestSpecification : Specification<Request>
{
    public override bool IsSatisfiedBy(Request request)
    {
        return request.Detail.LoanDetail?.LimitAmt > 1000000;
    }
    
    public override Expression<Func<Request, bool>> ToExpression()
    {
        return r => r.Detail.LoanDetail.LimitAmt > 1000000;
    }
}

// Usage in domain service
public class RequestApprovalService
{
    public bool RequiresSpecialApproval(Request request)
    {
        var highValueSpec = new HighValueRequestSpecification();
        var urgentSpec = new UrgentRequestSpecification();
        
        return highValueSpec.Or(urgentSpec).IsSatisfiedBy(request);
    }
}
```

## Domain Service vs Application Service

### Domain Service
Contains business logic that doesn't naturally fit within an entity:
```csharp
public class RequestValidationService
{
    public ValidationResult ValidateForSubmission(Request request)
    {
        var errors = new List<string>();
        
        if (string.IsNullOrEmpty(request.Detail.Purpose))
            errors.Add("Purpose is required for submission");
            
        if (request.Customers.Count == 0)
            errors.Add("At least one customer is required");
            
        return new ValidationResult(errors);
    }
}
```

### Application Service
Orchestrates the use case without business logic:
```csharp
public class SubmitRequestHandler : ICommandHandler<SubmitRequestCommand>
{
    public async Task Handle(SubmitRequestCommand command, CancellationToken cancellationToken)
    {
        // 1. Load aggregate
        var request = await repository.GetById(command.RequestId);
        
        // 2. Validate using domain service
        var validationResult = domainService.ValidateForSubmission(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        // 3. Execute domain behavior
        request.Submit();
        
        // 4. Save aggregate
        await repository.Save(request);
    }
}
```

## Bounded Context Integration Patterns

### Anti-Corruption Layer (ACL)
Protect your domain from external systems:
```csharp
public class ExternalRiskAssessmentService
{
    public async Task<DomainRiskScore> GetRiskScore(Request request)
    {
        // Call external service
        var externalScore = await externalApi.CalculateRisk(request.Detail.Purpose);
        
        // Translate to domain model (ACL)
        return externalScore.Rating switch
        {
            "HIGH" => DomainRiskScore.High,
            "MEDIUM" => DomainRiskScore.Medium,
            "LOW" => DomainRiskScore.Low,
            _ => DomainRiskScore.Unknown
        };
    }
}
```

### Context Mapping
Define relationships between bounded contexts:
```csharp
// Shared kernel - common concepts across contexts
public record CustomerId(long Value);

// Request context
public class RequestCustomer : Entity<long>
{
    public CustomerId CustomerId { get; private set; }
    public string Name { get; private set; }
}

// Customer context (separate bounded context)
public class Customer : Aggregate<CustomerId>
{
    public PersonalInfo PersonalInfo { get; private set; }
    public CreditHistory CreditHistory { get; private set; }
}
```

## Event Sourcing Concepts
For advanced audit and state reconstruction:

```csharp
// Stream-based aggregate
public class RequestAggregate : IEventSourcedAggregate
{
    private readonly List<IDomainEvent> _events = new();
    public IEnumerable<IDomainEvent> Events => _events;
    
    public static RequestAggregate FromHistory(IEnumerable<IDomainEvent> events)
    {
        var aggregate = new RequestAggregate();
        foreach (var @event in events)
        {
            aggregate.Apply(@event);
        }
        return aggregate;
    }
    
    private void Apply(IDomainEvent @event)
    {
        switch (@event)
        {
            case RequestCreatedEvent e:
                ApplyRequestCreated(e);
                break;
            case RequestStatusChangedEvent e:
                ApplyStatusChanged(e);
                break;
        }
    }
}
```

## Aggregate Design Guidelines

### 🎯 Keep Aggregates Small
- Focus on consistency boundaries
- Avoid large object graphs
- Use eventual consistency between aggregates

### 🎯 Aggregate Invariants
```csharp
public class Request : Aggregate<long>
{
    private void EnsureInvariants()
    {
        if (Status == "Submitted" && Customers.Count == 0)
            throw new DomainException("Submitted request must have customers");
            
        if (Detail.LoanDetail?.LimitAmt <= 0)
            throw new DomainException("Loan amount must be positive");
    }
    
    public void Submit()
    {
        Status = "Submitted";
        EnsureInvariants(); // Validate before state change
        AddDomainEvent(new RequestSubmittedEvent(this));
    }
}
```

### 🎯 Optimistic Concurrency
```csharp
public class Request : Aggregate<long>
{
    public int Version { get; private set; }
    
    public void UpdateVersion()
    {
        Version++;
    }
}

// In repository
public async Task Save(Request request)
{
    try
    {
        request.UpdateVersion();
        context.Update(request);
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        throw new ConcurrencyException("Request was modified by another user");
    }
}
```

# 📋 DDD Implementation Checklist

## ✅ Tactical Patterns
- [ ] Entities with identity and lifecycle
- [ ] Value objects with immutability
- [ ] Aggregates with business invariants
- [ ] Domain events for state changes
- [ ] Repositories for persistence abstraction
- [ ] Domain services for cross-entity logic
- [ ] Specifications for complex business rules

## ✅ Strategic Patterns
- [ ] Bounded contexts defined
- [ ] Ubiquitous language established
- [ ] Context map documented
- [ ] Anti-corruption layers implemented
- [ ] Integration events for cross-context communication

## ✅ Infrastructure Patterns
- [ ] Domain event dispatch
- [ ] Audit trail implementation
- [ ] Caching decorators
- [ ] Validation pipeline
- [ ] Exception handling strategy
- [ ] Unit of work pattern

## ✅ CQRS Integration
- [ ] Command/query separation
- [ ] Command handlers with validation
- [ ] Query handlers optimized for reads
- [ ] Domain logic in commands only

---
## 🔍 STEP 1: Identify Core DDD Building Blocks in Request Module

We’ll answer:

| Concept                 | Question                                                |
| ----------------------- | ------------------------------------------------------- |
| **Entity**              | What has identity and a lifecycle?                      |
| **Value Object**        | What is descriptive, doesn’t need ID, and is immutable? |
| **Aggregate Root**      | What is the main entry point for request logic?         |
| **Domain Service**      | Any logic that doesn’t belong in a single entity?       |
| **Application Service** | Which handler coordinates the feature logic?            |

### 1. Entity
Has ID, can change over time, must be tracked.

Candidate entities:
- `Request` (main one)
- Maybe `RequestCustomer` (if it changes separately)
- `RequestDocument` (if you update/delete them independently)
These entities are tracked, have IDs, and their identity matters.

These entities are tracked, have IDs, and their identity matters.

```csharp
// Root Entity
public class Request
{
    public Guid Id { get; private set; }

    public RequestDetail Detail { get; private set; } // Value Object
    public RequestStatus Status { get; private set; } // Enum or VO
    public List<RequestDocument> Documents { get; private set; } = new();

    private Request() { } // EF needs this

    public static Request Create(RequestDetail detail)
    {
        return new Request
        {
            Id = Guid.NewGuid(),
            Detail = detail,
            Status = RequestStatus.Draft
        };
    }

    public void UpdateDetail(RequestDetail newDetail)
    {
        if (Status != RequestStatus.Draft)
            throw new InvalidOperationException("Cannot update once submitted.");

        Detail = newDetail;
    }

    public void Submit()
    {
        if (Status != RequestStatus.Draft)
            throw new InvalidOperationException("Only draft can be submitted.");

        Status = RequestStatus.Submitted;
    }

    public void AddDocument(RequestDocument doc)
    {
        Documents.Add(doc);
    }
}
```

### 2. Value Object
Descriptive data. Immutable. No ID needed.

Candidate VOs:
`RequestDetail` (AO code, Branch, Purpose, Channel)
`CustomerContactInfo` (name, email, phone)
`RequestStatus` (could even be an enum-backed value object)

These are perfect for VOs because they only describe the request.

```csharp
public record RequestDetail(
    string Purpose,
    string Channel,
    string AoCode,
    string BranchCode,
    string Department,
    string Section
)
{
    public RequestDetail WithNewPurpose(string newPurpose) =>
        this with { Purpose = newPurpose };
}
```
```csharp
request.UpdateDetail(request.Detail.WithNewPurpose("Collateral Review"));
```

### 3. Aggregate Root
Controls the lifecycle of a cluster of entities/VOs. 

✔ `Request` is the Aggregate Root.

It manages:
- Status transitions
- Document uploads
- Customer detail updates (maybe wrapped as VOs)

Rule: You should only persist/fetch Request, and do all modifications via methods on it.

#### 🏗️ Design Patterns
##### ✅ Pattern: Factory Method for Creation
- Protects from bad object construction
- Avoids partial/inconsistent states

```csharp
public static Request Create(RequestDetail detail)
{
    if (string.IsNullOrWhiteSpace(detail.Purpose))
        throw new ArgumentException("Purpose required");

    return new Request { Id = Guid.NewGuid(), Detail = detail, Status = Draft };
}
```

##### ✅ Pattern: Encapsulate Mutations
Don’t allow setting `Status` or `Detail` from outside. Instead, expose meaningful methods:
```csharp
public void UpdatePurpose(string purpose)
{
    Detail = Detail with { Purpose = purpose };
}
```

##### ✅ Pattern: Collection = Add Method
```csharp
public void AddDocument(RequestDocument document)
{
    if (Status != RequestStatus.Draft)
        throw new InvalidOperationException("Cannot add documents after submission.");

    Documents.Add(document);
}
```


### 4. Domain Service
When logic is not tied to one entity.

Examples:
`RequestFeeCalculator` (logic based on purpose/area/type)

`RequestDocumentValidator` (validates file size/type based on rules)

### 5. Application Service
`SubmitRequestHandler`

`GetRequestByIdHandler`

These coordinate:
- Load aggregate from repository
- Call domain logic
- Save via repository

### Mapping Table

| Concept             | Class Example                  | Why                                |
| ------------------- | ------------------------------ | ---------------------------------- |
| Entity              | `Request`, `RequestDocument`   | Identity + lifecycle               |
| Value Object        | `RequestDetail`, `ContactInfo` | Immutable + descriptive            |
| Aggregate Root      | `Request`                      | Controls changes to entire cluster |
| Domain Service      | `RequestFeeCalculator`         | Business logic outside one entity  |
| Application Service | `SubmitRequestHandler`         | Coordinates the use case           |
