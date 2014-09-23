using HostedPCI.Domain.Model;

namespace HostedPCI.Domain.Abstract.Services
{
    public interface IHostedPciConfiguration
    {
        ApiCredentials GetConfigurationSettings();
    }
}
