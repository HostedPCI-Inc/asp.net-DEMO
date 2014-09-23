using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> Order Item </summary>
    [DataContract]
    public class OrderItem : IOrderItem
    {
        /// <summary> Merchant Item ID </summary>
        [DataMember(Name = "itemId", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary> Merchant Item Name </summary>
        [DataMember(Name = "itemName", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary> Merchant Item Description </summary>
        [DataMember(Name = "itemDescription", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary> Item Quantity Ordered </summary>
        [DataMember(Name = "itemQuantity", EmitDefaultValue = false)]
        public string Quantity { get; set; }

        /// <summary> Item Price per Unit </summary>
        [DataMember(Name = "itemPrice", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <summary> Value  [Is Item Taxable Y/N]  Where [x] starts at 0 and increases with each item added </summary>
        [DataMember(Name = "itemTaxable", EmitDefaultValue = false)]
        public string Taxable { get; set; }

        public OrderItem(string id = null, string name = null, string description = null, string quantity = null,
            decimal? price = null, bool? taxable = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            Taxable = taxable.HasValue ? (taxable.Value ? "Y" : "N") : null;
        }
    }
}