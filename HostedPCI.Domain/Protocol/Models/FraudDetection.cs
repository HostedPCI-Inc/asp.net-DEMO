using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Fraud detection parameter </summary>
    [DataContract]
    public class FraudDetection : IFraudDetection
    {
        /// <summary> Parameter Name </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary> Parameter Value </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        public FraudDetection(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(value);

            Name = name;
            Value = value;
        }
    }
}

