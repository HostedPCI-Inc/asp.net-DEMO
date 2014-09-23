using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Enums;

namespace HostedPCI.Domain.Helpers
{
    public class HostedPciDataConverter : IHostedPciDataConverter
    {
        public Dictionary<string, string> ConvertToDictionary(object request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var dictionary = new Dictionary<string, string>();
            request.ToDictionary(dictionary);
            return dictionary;
        }

        public Response ConvertToResponse(Dictionary<string, string> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            Status? status = null;
            string statusStr;
            if (dictionary.TryGetValue("status", out statusStr))
                status = (Status) Enum.Parse(typeof (Status), statusStr, true);

            ResponseStatus? responseStatus = null;
            string responseStatusStr;
            if (dictionary.TryGetValue("pxyResponse.responseStatus", out responseStatusStr))
                responseStatus = (ResponseStatus) Enum.Parse(typeof (ResponseStatus), responseStatusStr, true);

            string processorRefId;
            dictionary.TryGetValue("pxyResponse.processorRefId", out processorRefId);

            string processorType;
            dictionary.TryGetValue("pxyResponse.processorType", out processorType);

            string responseStatusName;
            dictionary.TryGetValue("pxyResponse.responseStatus.name", out responseStatusName);

            string responseStatusCode;
            dictionary.TryGetValue("pxyResponse.responseStatus.code", out responseStatusCode);

            string responseStatusDescription;
            dictionary.TryGetValue("pxyResponse.responseStatus.description", out responseStatusDescription);

            string responseStatusReasonCode;
            dictionary.TryGetValue("pxyResponse.responseStatus.reasonCode", out responseStatusReasonCode);

            string fullNativeResp;
            dictionary.TryGetValue("pxyResponse.fullNativeResp", out fullNativeResp);

            string threeDSAcsUrl;
            dictionary.TryGetValue("pxyResponse.threeDSAcsUrl", out threeDSAcsUrl);

            string threeDSTransactionId;
            dictionary.TryGetValue("pxyResponse.threeDSTransactionId", out threeDSTransactionId);

            string threeDSPARequest;
            dictionary.TryGetValue("pxyResponse.threeDSPARequest", out threeDSPARequest);

            string fraudServiceFullNativeResp;
            dictionary.TryGetValue("frdChkResp.fullNativeResp", out fraudServiceFullNativeResp);

            string errorId;
            dictionary.TryGetValue("errId", out errorId);

            var resp = new Response(status, responseStatus, processorRefId, processorType,
                responseStatusName, responseStatusCode, responseStatusDescription,
                responseStatusReasonCode, fullNativeResp, threeDSAcsUrl, threeDSTransactionId,
                threeDSPARequest, fraudServiceFullNativeResp, errorId);

            return resp;
        }

        public Dictionary<string, string> ConvertToDictionary(string queryString, bool urlDecode = true)
        {
            if (string.IsNullOrWhiteSpace(queryString))
                throw new ArgumentNullException(queryString);

            var dictionary = new Dictionary<string, string>();
            var items = queryString.Split(new[] {"&"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var keyValue = item.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 0 || keyValue.Length > 2)
                    throw new ArgumentException("Query string is invalid. It can't be splitted by '='.");

                var key = urlDecode ? HttpUtility.HtmlDecode(keyValue[0]) : keyValue[0];
                
                var value = keyValue.Length == 2
                    ? (urlDecode ? HttpUtility.HtmlDecode(keyValue[1]) : keyValue[1])
                    : string.Empty;

                dictionary.Add(key, value);
            }
            return dictionary;
        }

        public string ConvertToQueryString(Dictionary<string, string> dictionary, bool urlEncode = true)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            var requestStr = new StringBuilder();

            bool notfirst = false;
            foreach (var item in dictionary)
            {
                if (notfirst)
                    requestStr.Append("&");

                requestStr.Append(urlEncode ? HttpUtility.UrlEncode(item.Key) : item.Key);
                requestStr.Append("=");
                requestStr.Append(urlEncode ? HttpUtility.UrlEncode(item.Value) : item.Value);

                notfirst = true;
            }

            return requestStr.ToString();
        }

        public string ConvertToQueryString(object request, bool urlEncode = true)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var dicionary = ConvertToDictionary(request);
            return ConvertToQueryString(dicionary, urlEncode);
        }

        public Response ConvertToResponse(string queryString, bool urlDecode = true)
        {
            if (string.IsNullOrWhiteSpace(queryString))
                throw new ArgumentNullException(queryString);

            var dicionary = ConvertToDictionary(queryString, urlDecode);
            return ConvertToResponse(dicionary);
        }
    }
}
