using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Card Number </summary>
    [DataContract]
    public class CreditCard : ICreditCard
    {
        /// <summary> Type of Credit Card Used </summary>
        [DataMember(Name = "cardType", EmitDefaultValue = false)]
        public string CardType { get; set; }

        /// <summary> HPCI Token Representing Credit Card </summary>
        [DataMember(Name = "creditCardNumber", EmitDefaultValue = false)]
        public string CardNumber { get; set; }

        /// <summary> Credit Card Expiry Month </summary>
        [DataMember(Name = "expirationMonth", EmitDefaultValue = false)]
        public int ExpirationMonth { get; set; }

        /// <summary> Credit Card Expiry Year </summary>
        [DataMember(Name = "expirationYear", EmitDefaultValue = false)]
        public int ExpirationYear { get; set; }

        /// <summary> HPCI Token Representing CVV Code </summary>
        [DataMember(Name = "cardCodeVerification", EmitDefaultValue = false)]
        public string CvvCode { get; set; }

        public CreditCard(string cardType, string cardNumber, int expirationMonth, int expirationYear, string cvvCode)
        {
            if (string.IsNullOrWhiteSpace(cardType))
                throw new ArgumentNullException(cardNumber);
            if (string.IsNullOrWhiteSpace(cardNumber))
                throw new ArgumentNullException(cardNumber);
            if (string.IsNullOrWhiteSpace(cvvCode))
                throw new ArgumentNullException(cvvCode);

            if (expirationMonth < 0 || expirationMonth > 12)
                throw new ArgumentException("Invalid value of ExpirationMonth");
            if (expirationYear < 0 || expirationYear < DateTime.Now.Year)
                throw new ArgumentException("Invalid value of ExpirationYear");
            if (expirationYear == DateTime.Now.Year && expirationMonth < DateTime.Now.Month)
                throw new ArgumentException("Invalid value of ExpirationMonth and ExpirationYear");


            CardType = cardType;
            CardNumber = cardNumber;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            CvvCode = cvvCode;
        }
    }
}