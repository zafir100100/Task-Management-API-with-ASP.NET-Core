using System.Text.Json.Serialization;

namespace OrderProcessingSystemDotnet.Models
{
    public class ResponseDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; } = null;
        public int StatusCode { get; set; } = 0;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Payload { get; set; } = null;
    }
}
