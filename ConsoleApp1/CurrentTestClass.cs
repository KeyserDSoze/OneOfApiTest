using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public sealed class CurrentTestClass
    {
        [JsonPropertyName("c")]
        public UnionOf<SecondClass, FirstClass>? SecondClass_OneClass { get; set; }
        [JsonPropertyName("m")]
        public UnionOf<FirstClass, string>? OneClass_String { get; set; }
        [JsonPropertyName("f")]
        public UnionOf<FirstClass, string>? OneClass_string__2 { get; set; }
        [JsonPropertyName("s")]
        public UnionOf<bool, int>? Bool_Int { get; set; }
        [JsonPropertyName("p")]
        public UnionOf<decimal, bool>? Decimal_Bool { get; set; }
        public UnionOf<string, int>? Test { get; set; }
        [JsonPropertyName("d")]
        public UnionOf<FirstClass, SecondClass, int>? OneCLass_SecondClass_Int { get; set; }
        [JsonPropertyName("e")]
        public UnionOf<FirstClass, SecondClass, int, ThirdClass>? FirstClass_SecondClass_Int_ThirdClass { get; set; }
    }
}
