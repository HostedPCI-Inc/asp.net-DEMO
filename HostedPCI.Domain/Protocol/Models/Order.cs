using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Order  </summary>
    [DataContract]
    public class Order : IOrder
    {
        /// <summary> Additional Merchant Identifier (order Id) </summary>
        [DataMember(Name = "invoiceNumber", EmitDefaultValue = false)]
        public string InvoiceNumber { get; set; }

        /// <summary> Order Description </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary> Total Amount of Order </summary>
        [DataMember(Name = "totalAmount", EmitDefaultValue = false)]
        public decimal? TotalAmount { get; set; }

        /// <summary> Order Items </summary>
        [DataMember(Name = "orderItems", EmitDefaultValue = false)]
        public IOrderItem[] OrderItems { get; set; }

        public Order(string invoiceNumber = null, string description = null, decimal? totalAmount = null, OrderItem[] orderItems = null)
        {
            InvoiceNumber = invoiceNumber;
            Description = description;
            TotalAmount = totalAmount;
            OrderItems = orderItems;
        }
    }
}