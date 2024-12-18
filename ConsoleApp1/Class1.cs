using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public sealed class Alof
    {
        [JsonPropertyName("curty")]
        public UnionOf<Farlo, Porlo>? Settings { get; set; }
        [JsonPropertyName("marty")]
        public UnionOf<Porlo, string>? Sarlu { get; set; }
        [JsonPropertyName("felicina")]
        public UnionOf<Porlo, string>? Felicina { get; set; }
        [JsonPropertyName("salkd")]
        public UnionOf<bool, int>? Numbers { get; set; }
        [JsonPropertyName("parlt")]
        public UnionOf<decimal, bool>? Camerun { get; set; }
        public UnionOf<string, int>? Test { get; set; }
        [JsonPropertyName("calif")]
        public UnionOf<Porlo, Farlo, int> SalutiEBaci { get; set; }
        [JsonPropertyName("fakam")]
        public UnionOf<Porlo, Farlo, int, Fakam> Fakam { get; set; }
    }
    public sealed class Fakam
    {
        public string Olaf { get; set; }
        public Farlo Farlo { get; set; }
        [JsonPropertyName("qulo")]
        public List<string> Molest { get; set; }
        public List<Farlo> FarloList { get; set; }
        public Dictionary<string, string> Makko { get; set; }
        [JsonPropertyName("a")]
        public Dictionary<string, Farlo> FarloDictionary { get; set; }
    }
    public sealed class Farlo
    {
        public string Text { get; set; }
        public string RandomX { get; set; }
    }
    public sealed class Porlo
    {
        public string Value { get; set; }
        public string Selfish { get; set; }
    }
}
