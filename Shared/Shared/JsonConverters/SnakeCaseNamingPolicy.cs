using System.Text.Json;
using System.Text.RegularExpressions;

namespace Shared.JsonConverters;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return Regex.Replace(
            name,
            @"([a-z0-9])([A-Z])",
            "$1_$2", RegexOptions.NonBacktracking
        ).ToLower();
    }
}