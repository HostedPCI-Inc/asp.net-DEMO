using HostedPCI.Domain.Enums;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol
{
    public class VoidRequest : CaptureOrCreditOrVoidRequest
    {
        public VoidRequest(decimal amount, string currencyCode, string merchantRefId, string processorRefId)
            : base(RequestType.Void, amount, currencyCode, merchantRefId, processorRefId)
        {
            
        }
    }
}