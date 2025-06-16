using System.Text.Json;

namespace Request.Data.JsonConverters;

public class RequestCustomerConverter : JsonConverter<RequestCustomer>
{
    public override RequestCustomer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;

        var id = root.GetProperty("id").GetInt64();
        var name = root.GetProperty("name").GetString() ?? throw new JsonException("Name is required.");
        var email = root.GetProperty("email").GetString() ?? throw new JsonException("Email is required.");

        return new RequestCustomer(id, name, email);
    }

    public override void Write(Utf8JsonWriter writer, RequestCustomer value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("id", value.Id.ToString());
        writer.WriteString("name", value.Name);
        writer.WriteString("contactNumber", value.ContactNumber);

        writer.WriteEndObject();
    }
}