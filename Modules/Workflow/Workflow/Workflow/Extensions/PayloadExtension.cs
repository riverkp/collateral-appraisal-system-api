using System.Text.Json;

namespace Workflow.Workflow.Extensions;

public static class PayloadExtension
{
    public static T ConvertTo<T>(this object payload) where T : new()
    {
        var json = JsonSerializer.Serialize(payload);
        return JsonSerializer.Deserialize<T>(json) ?? new T();
    }
}