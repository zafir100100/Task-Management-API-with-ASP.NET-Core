using System.Text.Json.Serialization;

namespace OrderProcessingSystemDotnet.Models
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Payload { get; set; } = null;
    }
}
