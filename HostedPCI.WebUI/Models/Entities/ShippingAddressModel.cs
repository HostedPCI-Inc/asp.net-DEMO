using System;
using System.ComponentModel.DataAnnotations;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class ShippingAddressModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }

        public static ShippingAddress ConvertToDomain(ShippingAddressModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new ShippingAddress(model.FirstName, model.FirstName, model.Address,
                model.City, model.State, model.ZipCode, model.Country);
        }
    }
}