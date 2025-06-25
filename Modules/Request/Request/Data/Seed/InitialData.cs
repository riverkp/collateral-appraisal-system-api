namespace Request.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Requests.Models.Request> Requests => new List<Requests.Models.Request>
    {
        Request.Requests.Models.Request.From(
            "Appraisal",
            true,
            "High",
            "Online",
            1,
            new Reference(
                "PA-12345",
                1000000,
                DateTime.Now.AddMonths(-6)
            ),
            new LoanDetail(
                "LA-67890",
                500000,
                1200000
            ),
            Address.Create(
                "123",
                "A1",
                "2",
                "Location 1",
                "5",
                "Soi 10",
                "Main Road",
                "100101",
                "1001",
                "10",
                "12345"
            ),
            new Contact(
                "John Doe",
                "0123456789",
                "Project-001"
            ),
            new Fee(
                "01",
                "No additional fees"
            ),
            Requestor.Create(
                "EMP-001",
                "Jane Smith",
                "",
                "0987654321",
                "AO-001",
                "01",
                "01",
                "01",
                "01",
                "01"
            )
        )
    };
}