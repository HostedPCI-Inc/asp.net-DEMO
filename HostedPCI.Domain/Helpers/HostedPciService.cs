using System.IO;
using System.Net;
using System.Text;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Model;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Helpers
{
    public class HostedPciService : IHostedPciService
    {
        public Response Send(IHostedPciDataConverter converter, ApiCredentials credentials, BaseRequest request)
        {
            request.SetRequestCredentials(credentials);
            var queryString = converter.ConvertToQueryString(request);
            var responseString = Post(queryString, credentials.GetUrl(request.RequestType));
            return converter.ConvertToResponse(responseString);
        }

        public Response Send(IHostedPciDataConverter converter, ApiCredentials credentials, BaseRequest request,
             out string url, out string rawRquest, out string rawResponse)
        {
            var requestUrl = credentials.GetUrl(request.RequestType);
            
            request.SetRequestCredentials(credentials);
            var queryString = converter.ConvertToQueryString(request);
            var responseString = Post(queryString, requestUrl);
            var response = converter.ConvertToResponse(responseString);
            
            url = requestUrl;
            rawRquest = queryString;
            rawResponse = responseString;

            return response;
        }

        public static string Post(string postData, string postUrl)
        {
            var request = (HttpWebRequest) WebRequest.Create(postUrl);
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;

            var encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
            }

            var response = (HttpWebResponse) request.GetResponse();
            string text = null;

            using (Stream data = response.GetResponseStream())
                if (data != null)
                    using (var reader = new StreamReader(data))
                        text = reader.ReadToEnd();

            return text;
        }
    }
}