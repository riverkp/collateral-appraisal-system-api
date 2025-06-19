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
