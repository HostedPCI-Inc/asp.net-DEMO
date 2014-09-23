using HostedPCI.Domain.Enums;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol
{
    public class CreditRequest : CaptureOrCreditOrVoidRequest
    {
        public CreditRequest(decimal amount, string currencyCode, string merchantRefId, string processorRefId)
            : base(RequestType.Credit, amount, currencyCode, merchantRefId, processorRefId)
        {
            
        }
    }
}