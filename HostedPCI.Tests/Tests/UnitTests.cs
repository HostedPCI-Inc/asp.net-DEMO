using System;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Enums;
using HostedPCI.Domain.Protocol.Models;
using HostedPCI.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace HostedPCI.Tests.Tests
{
    [TestClass]
    public class UnitTests
    {
        private static readonly IKernel NinjectKernel = Helper.GetNinjectKernel();
        private readonly IHostedPciDataConverter _converter = NinjectKernel.Get<IHostedPciDataConverter>();
        private readonly IHostedPciConfiguration _configuration = NinjectKernel.Get<IHostedPciConfiguration>();
        private readonly IHostedPciService _service = NinjectKernel.Get<IHostedPciService>();
        
        [TestMethod]
        public void TestMethod_Auth()
        {
            var credentials = _configuration.GetConfigurationSettings();

            var card = new CreditCard("Visa", "4111000000111111", 10, 2014, "123");
            var transaction = new Transaction(80.25M, "USD", merchantRefId: Guid.NewGuid().ToString("N"));
            var billigAddress = new BillingAddress("FirstName", "LastName", "123 Elm Street", "Beverly Hills", "CA", "90210", "US");
            var shippingAddress = new ShippingAddress("FirstName", "LastName", "123 Elm Street", "Beverly Hills", "CA", "90210", "US");
            var customer = new CustomerInfo("hpcitest1@mailinator.com", "hpcitest1", billigAddress, shippingAddress, "173.32.21.248");
            var orderItem1 = new OrderItem("Item1", "ItemName1", "Item Description 1", "1", 2.00M, false);
            var orderItem2 = new OrderItem("Item2", "ItemName2", "Item Description 2", "1", 1.25M, false);
            var orderItems = new[] {orderItem1, orderItem2};
            var order = new Order("Order:", "Test Order", 4.25M, orderItems);

            var request = new AuthRequest(card, transaction, customer, order);
            var response = _service.Send(_converter, credentials, request);

            Assert.AreEqual(Status.Success, response.Status);
        }
    }
}
