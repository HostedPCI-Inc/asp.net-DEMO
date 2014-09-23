using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Enums;

namespace HostedPCI.Domain.Protocol.Abstract
{
    public abstract class CaptureOrCreditOrVoidRequest : BaseRequest
    {
        /// <summary> Transaction Amount to Capture </summary>
        [DataMember(Name = "pxyTransaction.txnAmount", EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        /// <summary> ISO Currency Code </summary>
        [DataMember(Name = "pxyTransaction.txnCurISO", EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        /// <summary> Merchant Reference Number (order Id) </summary>
        [DataMember(Name = "pxyTransaction.merchantRefId", EmitDefaultValue = false)]
        public string MerchantRefId { get; set; }

        /// <summary> Processor ID provided from Authorization or Sale </summary>
        [DataMember(Name = "pxyTransaction.processorRefId", EmitDefaultValue = false)]
        public string ProcessorRefId { get; set; }

        protected CaptureOrCreditOrVoidRequest(RequestType requestType, decimal amount, string currencyCode,
            string merchantRefId, string processorRefId)
            : base(requestType)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid value of Amount");
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentNullException(currencyCode);
            if (string.IsNullOrWhiteSpace(merchantRefId))
                throw new ArgumentNullException(merchantRefId);
            if (string.IsNullOrWhiteSpace(processorRefId))
                throw new ArgumentNullException(processorRefId);

            Amount = amount;
            CurrencyCode = currencyCode;
            MerchantRefId = merchantRefId;
            ProcessorRefId = processorRefId;
        }
    }
}