using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> User </summary>
    [DataContract]
    public class CustomerInfo : ICustomerInfo
    {
        /// <summary> Customer Email Address </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary> Customer User ID </summary>
        [DataMember(Name = "customerId", EmitDefaultValue = false)]
        public string CustomerId { get; set; }

        /// <summary> Customer IP Address </summary>
        [DataMember(Name = "customerIP", EmitDefaultValue = false)]
        public string CustomerIP { get; set; }

        /// <summary> Customer Billing Address </summary>
        [DataMember(Name = "billingLocation", EmitDefaultValue = false)]
        public IAddress BillingAddress { get; set; }

        /// <summary> Customer Shipping Address </summary>
        [DataMember(Name = "shippingLocation", EmitDefaultValue = false)]
        public IAddress ShippingAddress { get; set; }

        public CustomerInfo(string email, string customerId, BillingAddress billingAddress, ShippingAddress shippingAddress, string customerIP = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(email);
            if (string.IsNullOrWhiteSpace(customerId))
                throw new ArgumentNullException(customerId);
            if (billingAddress == null)
                throw new ArgumentNullException("billingAddress");
            if (shippingAddress == null)
                throw new ArgumentNullException("shippingAddress");

            Email = email;
            CustomerId = customerId;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            CustomerIP = customerIP;
        }
    }
}