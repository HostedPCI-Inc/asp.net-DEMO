using System.Collections.Generic;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol.Enums;

namespace HostedPCI.Domain.Protocol
{
    public class Response
    {
        /// <summary> The Status response variable indicates if the API call is well formed </summary>
        public Status? Status { get; private set; }

        /// <summary> </summary>
        public ResponseStatus? ResponseStatus { get; private set; }

        /// <summary> Valid Authorization Code from Credit Card Processor </summary>
        public string ProcessorRefId { get; private set; }

        /// <summary> Name of payment processor or gateway processing the transaction </summary>
        public string ProcessorType { get; private set; }

        /// <summary> Short description of response </summary>
        public string ResponseStatusName { get; private set; }

        /// <summary> Alphanumeric code representing response </summary>
        public string ResponseStatusCode { get; private set; }

        /// <summary> Long description and informational text of response </summary>
        public string ResponseStatusDescription { get; private set; }

        /// <summary> Gateway specific reason code </summary>
        public string ResponseStatusReasonCode { get; private set; }

        /// <summary> Gateway specific result set, URL encoded </summary>
        public string FullNativeResp { get; private set; }

        /// <summary> ACS Url received from the “verifyenroll” call </summary>
        public string ThreeDSAcsUrl { get; private set; }

        /// <summary> Transaction Id received from the “verifyenroll” call </summary>
        public string ThreeDSTransactionId { get; private set; }

        /// <summary> Payer Authentication Request received from the “verifyenroll” call </summary>
        public string ThreeDSPARequest { get; private set; }

        /// <summary> Full response of a call to fraud checking service </summary>
        public string FraudServiceFullNativeResp { get; private set; }

        /// <summary> </summary>
        public string ErrorId { get; private set; }

        public Response(Status? status, ResponseStatus? responseStatus, string processorRefId, string processorType,
            string responseStatusName, string responseStatusCode, string responseStatusDescription,
            string responseStatusReasonCode, string fullNativeResp, string threeDSAcsUrl, string threeDSTransactionId,
            string threeDSPARequest, string fraudServiceFullNativeResp, string errorId)
        {
            FraudServiceFullNativeResp = fraudServiceFullNativeResp;
            ThreeDSPARequest = threeDSPARequest;
            ThreeDSTransactionId = threeDSTransactionId;
            ThreeDSAcsUrl = threeDSAcsUrl;
            FullNativeResp = fullNativeResp;
            ResponseStatusReasonCode = responseStatusReasonCode;
            ResponseStatusDescription = responseStatusDescription;
            ResponseStatusCode = responseStatusCode;
            ResponseStatusName = responseStatusName;
            ProcessorType = processorType;
            ProcessorRefId = processorRefId;
            ResponseStatus = responseStatus;
            Status = status;
            ErrorId = errorId;
        }

        public static Response Parse(IHostedPciDataConverter converter, Dictionary<string, string> dictionary)
        {
            return converter.ConvertToResponse(dictionary);
        }
    }
}
