using System;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class OrderItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Taxable { get; set; }

        public static OrderItem ConvertToDomain(OrderItemModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new OrderItem(model.Id, model.Name, model.Description, model.Quantity, model.Price, model.Taxable);
        }
    }
}