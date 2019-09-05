namespace ConfigurationProvider.Host.Models
{
    public class ServiceSettings
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionStringRead { get; set; }
        public string ConnectionStringWrite { get; set; }
        public int BatchSize { get; set; }
        public int WaitTimeout { get; set; }
        public bool AlwaysLogDetailedInfo { get; set; }
        public bool WriteAllMessages { get; set; }
    }
}
