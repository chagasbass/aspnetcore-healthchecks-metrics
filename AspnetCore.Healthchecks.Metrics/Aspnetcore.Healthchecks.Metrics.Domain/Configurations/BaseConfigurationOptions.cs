namespace AspnetCore.Healthchecks.Metrics.Domain.Configurations
{
    public class BaseConfigurationOptions
    {
        public const string BaseConfig = "BaseConfig";
        public string AddressService { get; set; }
        public string DatabaseConn { get; set; }
    }
}
