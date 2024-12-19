using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public sealed class SecondClass
    {
        [JsonPropertyName("FirstProperty")]
        public string FirstProperty { get; set; }
        [JsonPropertyName("dd")]
        public string SecondProperty { get; set; }
    }
}
