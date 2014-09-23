using HostedPCI.Domain.Model;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Abstract.Services
{
    public interface IHostedPciService
    {
        Response Send(IHostedPciDataConverter converter, ApiCredentials credentials, BaseRequest request);

        Response Send(IHostedPciDataConverter converter, ApiCredentials credentials, BaseRequest request,
            out string url, out string rawRquest, out string rawResponse);
    }
}
