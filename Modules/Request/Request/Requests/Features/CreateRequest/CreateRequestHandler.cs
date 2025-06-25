namespace Request.Requests.Features.CreateRequest;

internal class CreateRequestHandler(RequestDbContext dbContext)
    : ICommandHandler<CreateRequestCommand, CreateRequestResult>
{
    public async Task<CreateRequestResult> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
    {
        var request = CreateNewRequest(command);

        dbContext.Requests.Add(request);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateRequestResult(request.Id);
    }

    private static Models.Request CreateNewRequest(CreateRequestCommand command)
    {
        return Models.Request.From(
            command.Purpose,
            command.HasAppraisalBook,
            command.Priority,
            command.Channel,
            command.OccurConstInspec,
            new Reference(
                command.Reference.PrevAppraisalNo,
                command.Reference.PrevAppraisalValue,
                command.Reference.PrevAppraisalDate
            ),
            new LoanDetail(
                command.LoanDetail.LoanApplicationNo,
                command.LoanDetail.LimitAmt,
                command.LoanDetail.TotalSellingPrice
            ),
            Address.Create(
                command.Address.HouseNo,
                command.Address.RoomNo,
                command.Address.FloorNo,
                command.Address.LocationIdentifier,
                command.Address.Moo,
                command.Address.Soi,
                command.Address.Road,
                command.Address.SubDistrict,
                command.Address.District,
                command.Address.Province,
                command.Address.Postcode
            ),
            new Contact(
                command.Contact.ContactPersonName,
                command.Contact.ContactPersonContactNo,
                command.Contact.ProjectCode
            ),
            new Fee(
                command.Fee.FeeType,
                command.Fee.FeeRemark
            ),
            Requestor.Create(
                command.Requestor.RequestorEmpId,
                command.Requestor.RequestorName,
                command.Requestor.RequestorEmail,
                command.Requestor.RequestorContactNo,
                command.Requestor.RequestorAo,
                command.Requestor.RequestorBranch,
                command.Requestor.RequestorBusinessUnit,
                command.Requestor.RequestorDepartment,
                command.Requestor.RequestorSection,
                command.Requestor.RequestorCostCenter
            )
        );
    }
}