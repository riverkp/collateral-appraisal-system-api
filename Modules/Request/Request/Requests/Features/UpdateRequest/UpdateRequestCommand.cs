namespace Request.Requests.Features.UpdateRequest;

public record UpdateRequestCommand(
    long Id,
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
) : ICommand<UpdateRequestResult>;