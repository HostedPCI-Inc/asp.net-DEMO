using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Enums;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.Domain.Protocol.Abstract
{
    public abstract class AuthOrSaleRequest : BaseRequest
    {
        [DataMember(Name = "pxyCreditCard", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "pxyTransaction", EmitDefaultValue = false)]
        public Transaction Transaction { get; set; }

        [DataMember(Name = "pxyCustomerInfo", EmitDefaultValue = false)]
        public CustomerInfo CustomerInfo { get; set; }

        [DataMember(Name = "pxyOrder", EmitDefaultValue = false)]
        public Order Order { get; set; }

        [DataMember(Name = "pxyThreeDSecAuth", EmitDefaultValue = false)]
        public ThreeDSec ThreeDSec { get; set; }

        [DataMember(Name = "fraudChkParamList", EmitDefaultValue = false)]
        public FraudDetection[] FraudDetection { get; set; }

        protected AuthOrSaleRequest(RequestType requestType, CreditCard creditCard, Transaction transaction,
            CustomerInfo customerInfo, Order order, ThreeDSec threeDSec = null, FraudDetection[] fraudDetection = null)
            : base(requestType)
        {
            if (creditCard == null)
                throw new ArgumentNullException("creditCard");
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (customerInfo == null)
                throw new ArgumentNullException("customerInfo");
            if (order == null)
                throw new ArgumentNullException("order");

            CreditCard = creditCard;
            Transaction = transaction;
            CustomerInfo = customerInfo;
            Order = order;
            ThreeDSec = threeDSec;
            FraudDetection = fraudDetection;
        }

    }
}