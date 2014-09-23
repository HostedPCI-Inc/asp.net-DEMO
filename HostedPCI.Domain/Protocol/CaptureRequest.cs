using HostedPCI.Domain.Enums;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol
{
    public class CaptureRequest : CaptureOrCreditOrVoidRequest
    {
        public CaptureRequest(decimal amount, string currencyCode, string merchantRefId, string processorRefId)
            : base(RequestType.Capture, amount, currencyCode, merchantRefId, processorRefId)
        {
            
        }
    }
}