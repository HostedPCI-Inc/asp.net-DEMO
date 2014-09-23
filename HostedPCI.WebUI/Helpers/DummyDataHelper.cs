using System;
using HostedPCI.WebUI.Models;
using HostedPCI.WebUI.Models.Entities;

namespace HostedPCI.WebUI.Helpers
{
    public static class DummyDataHelper
    {
        public static AuthOrSaleRequestModel GetDummyAuthRequestModel()
        {
            var card = new CreditCardModel();
            var transaction = new TransactionModel();

            var customer = new CustomerInfoModel
            {
                BillingAddress = new BillingAddressModel(),
                ShippingAddress = new ShippingAddressModel()
            };

            var orderItem1 = new OrderItemModel();
            var orderItem2 = new OrderItemModel();
            var orderItems = new[] {orderItem1, orderItem2};
            var order = new OrderModel {OrderItems = orderItems};

            var request = new AuthOrSaleRequestModel
            {
                CreditCard = card,
                CustomerInfo = customer,
                Transaction = transaction,
                Order = order
            };

            return request;
        }

        public static AuthOrSaleRequestModel GetTestAuthRequestModel()
        {
            var card = new CreditCardModel
            {
                CardNumber = "4111000000111111",
                CardType = "Visa",
                ExpirationMonth = 10,
                ExpirationYear = 2014,
                CvvCode = "123"
            };

            var transaction = new TransactionModel
            {
                Amount = 80.25M,
                CurrencyCode = "USD",
                MerchantRefId = Guid.NewGuid().ToString("N").ToUpper()
            };

            var customer = new CustomerInfoModel
            {
                Email = "hpcitest1@mailinator.com",
                CustomerId = "hpcitest1",
                CustomerIP = "173.32.21.248",
                BillingAddress = new BillingAddressModel
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "123 Elm Street",
                    State = "CA",
                    City = "Beverly Hills",
                    ZipCode = "90210",
                    Country = "US"
                },
                ShippingAddress = new ShippingAddressModel
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Address = "123 Elm Street",
                    State = "CA",
                    City = "Beverly Hills",
                    ZipCode = "90210",
                    Country = "US"
                }
            };

            var orderItem1 = new OrderItemModel
            {
                Id = "Item1",
                Name = "ItemName1",
                Description = "Item Description 1",
                Quantity = "1",
                Price = 2,
                Taxable = false
            };

            var orderItem2 = new OrderItemModel
            {
                Id = "Item2",
                Name = "ItemName2",
                Description = "Item Description 2",
                Quantity = "1",
                Price = 1,
                Taxable = false
            };

            var orderItems = new[] { orderItem1, orderItem2 };

            var order = new OrderModel
            {
                InvoiceNumber = "Order" + DateTime.Now.Ticks,
                Description = "Test Order",
                TotalAmount = 4.25M,
                OrderItems = orderItems
            };

            var request = new AuthOrSaleRequestModel
            {
                CreditCard = card,
                CustomerInfo = customer,
                Transaction = transaction,
                Order = order
            };

            return request;
        }

        public static CaptureOrCreditOrVoidRequestModel GetTestCaptureRequestModel()
        {
            return new CaptureOrCreditOrVoidRequestModel();
        }
    }
}