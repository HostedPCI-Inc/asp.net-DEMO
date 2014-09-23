using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Billing Location </summary>
    [DataContract]
    public class BillingAddress : IAddress
    {
        /// <summary> Customer First Name </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary> Customer Last Name </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary> Customer Billing Street Address </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary> Customer Billing City </summary>
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary> Customer Billing State </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary> Customer Billing ZipCode </summary>
        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }

        /// <summary> Customer Billing Country </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }


        public BillingAddress(string firstName, string lastName, string address,
            string city, string state, string zipCode, string country)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(firstName);
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException(lastName);
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException(address);
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(city);
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentNullException(state);
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentNullException(zipCode);
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentNullException(country);

            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
}
