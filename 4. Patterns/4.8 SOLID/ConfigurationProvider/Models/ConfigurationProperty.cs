namespace ConfigurationProvider.Models
{
    public class ConfigurationProperty
    {
        public string FullName => $"{Namespace}.{Class}";
        public string Namespace { get; set; }
        public string Class { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
    }
}
