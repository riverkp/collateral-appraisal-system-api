namespace Request.Requests.Features.CreateRequest;

public record CreateRequestCommand(
    string Purpose,
    bool HasAppraisalBook,
    string Priority,
    string Channel,
    int? OccurConstInspec,
    Reference Reference,
    LoanDetail LoanDetail,
    Address Address,
    Contact Contact,
    Fee Fee,
    Requestor Requestor
) : ICommand<CreateRequestResult>;