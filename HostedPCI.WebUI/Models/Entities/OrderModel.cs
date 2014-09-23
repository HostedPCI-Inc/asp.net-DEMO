using System;
using System.Collections.Generic;
using System.Linq;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class OrderModel
    {
        public string InvoiceNumber { get; set; }
        public string Description { get; set; }
        public decimal? TotalAmount { get; set; }
        public OrderItemModel[] OrderItems { get; set; }

        public static Order ConvertToDomain(OrderModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            List<OrderItem> orderItems = null;

            if (model.OrderItems != null && model.OrderItems.Any())
                orderItems = model.OrderItems.Select(OrderItemModel.ConvertToDomain).ToList();

            return new Order(model.InvoiceNumber, model.Description, model.TotalAmount,
                orderItems != null ? orderItems.ToArray() : null);
        }
    }
}