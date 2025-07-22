namespace Assignment.AssigneeSelection.Strategies;

/// <summary>
/// Represents a strategy for selecting an assignee randomly from a pool of eligible users.
/// </summary>
public class RandomAssigneeSelector : IAssigneeSelector
{
    private readonly ILogger<RandomAssigneeSelector> _logger;
    private readonly Random _random;

    public RandomAssigneeSelector(ILogger<RandomAssigneeSelector> logger)
    {
        _logger = logger;
        _random = new Random();
    }

    public async Task<AssigneeSelectionResult> SelectAssigneeAsync(
        AssignmentContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var eligibleUsers = await GetEligibleUsersAsync(context, cancellationToken);

            if (!eligibleUsers.Any())
            {
                return AssigneeSelectionResult.Failure("No eligible users found for assignment");
            }

            var selectedUser = SelectRandomUser(eligibleUsers);

            _logger.LogInformation("Random selector assigned user {UserId} for activity {ActivityName}",
                selectedUser, context.ActivityName);

            return AssigneeSelectionResult.Success(selectedUser, new Dictionary<string, object>
            {
                ["SelectionStrategy"] = "Random",
                ["EligibleUserCount"] = eligibleUsers.Count,
                ["Seed"] = _random.Next() // For debugging/audit purposes
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during random assignee selection");
            return AssigneeSelectionResult.Failure($"Selection failed: {ex.Message}");
        }
    }

    private async Task<List<string>> GetEligibleUsersAsync(AssignmentContext context,
        CancellationToken cancellationToken)
    {
        // TODO: Implement logic to fetch eligible users based on context
        await Task.CompletedTask;
        return new List<string> { "User1", "User2", "User3" };
    }

    private string SelectRandomUser(List<string> eligibleUsers)
    {
        var randomIndex = _random.Next(eligibleUsers.Count);
        return eligibleUsers[randomIndex];
    }
}