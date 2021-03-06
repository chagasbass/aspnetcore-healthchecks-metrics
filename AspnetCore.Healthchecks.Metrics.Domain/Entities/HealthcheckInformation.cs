namespace AspnetCore.Healthchecks.Metrics.Domain.Entities
{
    public class HealthcheckInformation
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public string AllocatedMemory { get; set; }
        public string TotalAvailableMemory { get; set; }
        public string MaxMemory { get; set; }

        public HealthcheckInformation() { }

    }
}
