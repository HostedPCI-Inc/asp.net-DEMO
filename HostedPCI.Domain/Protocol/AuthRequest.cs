using HostedPCI.Domain.Protocol.Abstract;
using HostedPCI.Domain.Protocol.Models;
using HostedPCI.Domain.Enums;

namespace HostedPCI.Domain.Protocol
{
    public class AuthRequest : AuthOrSaleRequest
    {
        public AuthRequest(CreditCard creditCard, Transaction transaction, CustomerInfo customerInfo,
            Order order, ThreeDSec threeDSec = null, FraudDetection[] fraudDetection = null)
            : base(RequestType.Auth, creditCard, transaction, customerInfo, order, threeDSec, fraudDetection)
        {

        }
    }
}