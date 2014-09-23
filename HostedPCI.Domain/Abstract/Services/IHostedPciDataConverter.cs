using System.Collections.Generic;
using HostedPCI.Domain.Protocol;

namespace HostedPCI.Domain.Abstract.Services
{
    public interface IHostedPciDataConverter
    {
        Dictionary<string, string> ConvertToDictionary(object request);
        Dictionary<string, string> ConvertToDictionary(string queryString, bool urlDecode = true);
        Response ConvertToResponse(Dictionary<string, string> dictionary);
        Response ConvertToResponse(string queryString, bool urlDecode = true);
        string ConvertToQueryString(Dictionary<string, string> dictionary, bool urlEncode = true);
        string ConvertToQueryString(object request, bool urlEncode = true);
    }
}
