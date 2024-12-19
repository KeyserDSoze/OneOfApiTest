using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public sealed class ThirdClass
    {
        public string Stringable { get; set; }
        public SecondClass SecondClass { get; set; }
        [JsonPropertyName("array")]
        public List<string> ArrayOfStrings { get; set; }
        public List<SecondClass> ListOfSecondClasses { get; set; }
        public Dictionary<string, string> DictionaryItems { get; set; }
        [JsonPropertyName("a")]
        public Dictionary<string, SecondClass> ObjectDictionary { get; set; }
    }
}
