using HostedPCI.Domain.Protocol;

namespace HostedPCI.WebUI.Models
{
    public class RequestResultModel
    {
        public Response Response { get; set; }
        public string Url { get; set; }
        public string RawRequest { get; set; }
        public string RawResponse { get; set; }

        public RequestResultModel()
        {

        }

        public RequestResultModel(Response response,string url,  string rawRequest , string rawResponse)
        {
            Response = response;
            Url = url;
            RawRequest = rawRequest;
            RawResponse = rawResponse;
        }
    }
}