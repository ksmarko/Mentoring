namespace ConfigurationProvider.Host.Models
{
    public class ParsingSettings
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string Path { get; set; }
        public int BatchSize { get; set; }
    }
}
