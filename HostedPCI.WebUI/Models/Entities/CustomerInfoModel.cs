using System;
using System.ComponentModel.DataAnnotations;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class CustomerInfoModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public string CustomerIP { get; set; }

        [Required]
        public BillingAddressModel BillingAddress { get; set; }

        [Required]
        public ShippingAddressModel ShippingAddress { get; set; }

        public static CustomerInfo ConvertToDomain(CustomerInfoModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (model.BillingAddress == null)
                throw new ArgumentNullException("model.BillingAddress");
            if (model.ShippingAddress == null)
                throw new ArgumentNullException("model.ShippingAddress");

            var billigAddress = BillingAddressModel.ConvertToDomain(model.BillingAddress);
            var shippingAddress = ShippingAddressModel.ConvertToDomain(model.ShippingAddress);

            return new CustomerInfo(model.Email, model.CustomerId, billigAddress,
                shippingAddress, model.CustomerIP);
        }
    }
}