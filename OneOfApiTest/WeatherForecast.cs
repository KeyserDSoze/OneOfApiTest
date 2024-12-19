namespace OneOfApiTest
{
    public sealed class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public UnionOf<CurrentTime, string> Time { get; set; }
    }
    public sealed class CurrentTime
    {
        public DateTime Time { get; set; }
    }
}
