using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Transaction Amount </summary>
    [DataContract]
    public class Transaction : ITransaction
    {
        /// <summary> Amount to Authorize </summary>
        [DataMember(Name = "txnAmount", EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        /// <summary> ISO Currency Code </summary>
        [DataMember(Name = "txnCurISO", EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }

        /// <summary> Merchant Reference Number (order Id) </summary>
        [DataMember(Name = "merchantRefId", EmitDefaultValue = false)]
        public string MerchantRefId { get; set; }

        /// <summary> “DEF” or a payment profile name </summary>
        [DataMember(Name = "txnPayName", EmitDefaultValue = false)]
        public string PayName { get; set; }

        /// <summary> Empty string or short comment not longer than 50 characters </summary>
        [DataMember(Name = "txnComment", EmitDefaultValue = false)]
        public string Comment { get; set; }

        /// <summary> Value not required for all gateways, please ask HPCI support for more details </summary>
        [DataMember(Name = "txnExtraParam1", EmitDefaultValue = false)]
        public string ExtraParam1 { get; set; }

        /// <summary> Value not required for all gateways, please ask HPCI support for more details </summary>
        [DataMember(Name = "txnExtraParam2", EmitDefaultValue = false)]
        public string ExtraParam2 { get; set; }

        /// <summary> Value not required for all gateways, please ask HPCI support for more details </summary>
        [DataMember(Name = "txnExtraParam3", EmitDefaultValue = false)]
        public string ExtraParam3 { get; set; }

        /// <summary> Value not required for all gateways, please ask HPCI support for more details </summary>
        [DataMember(Name = "txnExtraParam4", EmitDefaultValue = false)]
        public string ExtraParam4 { get; set; }

        /// <summary> Value not required for all gateways, please ask HPCI support for more details </summary>
        [DataMember(Name = "txnExtraParam5", EmitDefaultValue = false)]
        public string ExtraParam5 { get; set; }

        /// <summary> Value for installment count for the transaction amount not required for all gateways, optional for Global Collect gateway </summary>
        [DataMember(Name = "txnInstallmentCount", EmitDefaultValue = false)]
        public int? InstallmentCount { get; set; }

        /// <summary> Value for language code for transaction, not required for all gateways, optional for Global Collect gateway </summary>
        [DataMember(Name = "txnLangCode", EmitDefaultValue = false)]
        public string LangCode { get; set; }

        /// <summary> Value for defining duplicate transaction validation window in seconds, not required for all gateways, optional for Authorize.net </summary>
        [DataMember(Name = "txnDuplicateWindowSeconds", EmitDefaultValue = false)]
        public string DuplicateWindowSeconds { get; set; }

        public Transaction(decimal amount, string currencyCode, string payName = null, string merchantRefId = null,
            string comment = null, string extraParam1 = null, string extraParam2 = null, string extraParam3 = null,
            string extraParam4 = null, string extraParam5 = null, int? installmentCount = null, string langCode = null,
            string duplicateWindowSeconds = null)
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentNullException(currencyCode);
            if (amount <= 0)
                throw new ArgumentException("Invalid value of Amount");

            Amount = amount;
            CurrencyCode = currencyCode;
            PayName = payName;
            MerchantRefId = merchantRefId;
            Comment = comment;
            ExtraParam1 = extraParam1;
            ExtraParam2 = extraParam2;
            ExtraParam3 = extraParam3;
            ExtraParam4 = extraParam4;
            ExtraParam5 = extraParam5;
            InstallmentCount = installmentCount;
            LangCode = langCode;
            DuplicateWindowSeconds = duplicateWindowSeconds;
        }
    }
}