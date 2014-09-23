using System.Collections.Generic;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol;
using HostedPCI.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace HostedPCI.Tests.Tests
{
    [TestClass]
    public class SerializationTests
    {
        private static readonly IKernel NinjectKernel = Helper.GetNinjectKernel();
        private readonly IHostedPciDataConverter _converter = NinjectKernel.Get<IHostedPciDataConverter>();

        [TestMethod]
        public void TestBillingAddress()
        {
            var billingAddress = TestHelper.CreateRandomBillingAddress();
            var dictionary = _converter.ConvertToDictionary(billingAddress);

            Assert.AreEqual(7, dictionary.Count);
            AssertAreEqualAddressValues(dictionary);
        }

        [TestMethod]
        public void TestShippingAddress()
        {
            var shippingAddress = TestHelper.CreateRandomShippingAddress();
            var dictionary = _converter.ConvertToDictionary(shippingAddress);

            Assert.AreEqual(7, dictionary.Count);
            AssertAreEqualAddressValues(dictionary);
        }

        [TestMethod]
        public void TestCreditCard()
        {
            var creditCard = TestHelper.CreateRandomCreditCard();
            var dictionary = _converter.ConvertToDictionary(creditCard);

            Assert.AreEqual(5, dictionary.Count);
            AssertAreEqualCreditCardValues(dictionary);
        }

        [TestMethod]
        public void TestFraudDetection()
        {
            var fraudDetection = TestHelper.CreateRandomFraudDetection();
            var dictionary = _converter.ConvertToDictionary(fraudDetection);

            Assert.AreEqual(2, dictionary.Count);
            AssertAreEqualFraudValues(dictionary);
        }

        [TestMethod]
        public void TestOrderItem()
        {
            var orderItem = TestHelper.CreateRandomOrderItem();
            var dictionary = _converter.ConvertToDictionary(orderItem);

            Assert.AreEqual(6, dictionary.Count);
            Assert.AreEqual(TestValues.OrderItemValue.Id, dictionary["itemId"]);
            Assert.AreEqual(TestValues.OrderItemValue.Name, dictionary["itemName"]);
            Assert.AreEqual(TestValues.OrderItemValue.Description, dictionary["itemDescription"]);
            Assert.AreEqual(TestValues.OrderItemValue.Quantity, dictionary["itemQuantity"]);
            Assert.AreEqual(TestValues.OrderItemValue.Price.ToString(), dictionary["itemPrice"]);
            Assert.AreEqual(TestValues.OrderItemValue.Taxable ? "Y" : "N", dictionary["itemTaxable"]);
        }

        [TestMethod]
        public void TestThreeDSec()
        {
            var threeDSec = TestHelper.CreateRandomThreeDSec();
            var dictionary = _converter.ConvertToDictionary(threeDSec);

            Assert.AreEqual(4 + TestValues.ThreeDSec.AuthSignComboList.Length, dictionary.Count);
            AssertAreEqualThreeDSecValues(dictionary);

            for (int i = 0; i < TestValues.ThreeDSec.AuthSignComboList.Length; i++)
            {
                var name = string.Format("authSignComboList[{0}]", i);
                Assert.AreEqual(TestValues.ThreeDSec.AuthSignComboList[i], dictionary[name]);
            }
        }

        [TestMethod]
        public void TestTransactionAmount()
        {
            var transactionAmount = TestHelper.CreateRandomTransactionAmount();
            var dictionary = _converter.ConvertToDictionary(transactionAmount);
            
            Assert.AreEqual(13, dictionary.Count);
            AssertAreEqualTransactionValues(dictionary);
        }

        [TestMethod]
        public void TestOrder()
        {
            var order = TestHelper.CreateRandomOrder();
            var dictionary = _converter.ConvertToDictionary(order);

            var elementsCount =
                3 + /* invoiceNumber,description,totalAmount */
                TestValues.Order.OrderItems.Length*6; /* 6--count of fields in 'OrderItem' obj */

            Assert.AreEqual(elementsCount, dictionary.Count);
            AssertAreEqualOrderValues(dictionary);

            for (int i = 0; i < TestValues.Order.OrderItems.Length; i++)
            {
                var prefix = string.Format("orderItems[{0}].", i);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Id, dictionary[prefix + "itemId"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Name, dictionary[prefix + "itemName"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Description, dictionary[prefix + "itemDescription"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Quantity, dictionary[prefix + "itemQuantity"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Price.ToString(), dictionary[prefix + "itemPrice"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Taxable, dictionary[prefix + "itemTaxable"]);
            }
        }

        [TestMethod]
        public void TestCustomer()
        {
            var customerInfo = TestHelper.CreateCustomerInfo();
            var dictionary = _converter.ConvertToDictionary(customerInfo);
            
            var elementsCount =
                3 + /* customerInfo */
                7 + /* billing address */
                7;  /* shipping address */

            Assert.AreEqual(elementsCount, dictionary.Count);
            AssertAreEqualCustomerValues(dictionary);
            AssertAreEqualAddressValues(dictionary, "billingLocation.");
            AssertAreEqualAddressValues(dictionary, "shippingLocation.");
            
        }

        [TestMethod]
        public void TestCreditCardAuthorizationTransaction()
        {
            var credentials = TestHelper.CreateTestCredentials();
            var creditCard = TestHelper.CreateRandomCreditCard();
            var transactionAmount = TestHelper.CreateRandomTransactionAmount();
            var customerInfo = TestHelper.CreateCustomerInfo();
            var order = TestHelper.CreateRandomOrder();
            var threeDSec = TestHelper.CreateRandomThreeDSec();
            var fraudDetection = TestHelper.CreateRandomFraudDetection();

            var request = new AuthRequest(creditCard, transactionAmount, customerInfo, order, threeDSec, new[] { fraudDetection });
            request.SetRequestCredentials(credentials);

            var dictionary = _converter.ConvertToDictionary(request);

            var elementsCount =
                4 + /* credentials */
                5 + /* creadit card */
                13 + /* transaction */
                3 + /* customer info */
                7 + /* billing address */
                7 + /* shipping address */
                3 + /* order */
                order.OrderItems.Length*6 + /* order items */
                4 + /* 3ds */
                threeDSec.AuthSignComboList.Length + /* 3ds items */
                request.FraudDetection.Length * 2; /* fraud items */

            Assert.AreEqual(elementsCount, dictionary.Count);

            Assert.AreEqual(TestValues.Credentials.ApiVersion, dictionary["apiVersion"]);
            Assert.AreEqual(TestValues.Credentials.ApiType, dictionary["apiType"]);
            Assert.AreEqual(TestValues.Credentials.UserName, dictionary["userName"]);
            Assert.AreEqual(TestValues.Credentials.UserPassKey, dictionary["userPassKey"]);

            AssertAreEqualCreditCardValues(dictionary, "pxyCreditCard.");
            AssertAreEqualTransactionValues(dictionary, "pxyTransaction.");
            AssertAreEqualCustomerValues(dictionary, "pxyCustomerInfo.");
            AssertAreEqualAddressValues(dictionary, "pxyCustomerInfo.billingLocation.");
            AssertAreEqualAddressValues(dictionary, "pxyCustomerInfo.shippingLocation.");
            AssertAreEqualOrderValues(dictionary, "pxyOrder.");

            for (int i = 0; i < TestValues.Order.OrderItems.Length; i++)
            {
                var prefix = string.Format("pxyOrder.orderItems[{0}].", i);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Id, dictionary[prefix + "itemId"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Name, dictionary[prefix + "itemName"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Description, dictionary[prefix + "itemDescription"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Quantity, dictionary[prefix + "itemQuantity"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Price.ToString(), dictionary[prefix + "itemPrice"]);
                Assert.AreEqual(TestValues.Order.OrderItems[i].Taxable, dictionary[prefix + "itemTaxable"]);
            }
            
            AssertAreEqualThreeDSecValues(dictionary, "pxyThreeDSecAuth.");

            for (int i = 0; i < TestValues.ThreeDSec.AuthSignComboList.Length; i++)
            {
                var name = string.Format("pxyThreeDSecAuth.authSignComboList[{0}]", i);
                Assert.AreEqual(TestValues.ThreeDSec.AuthSignComboList[i], dictionary[name]);
            }

            for (int i = 0; i < request.FraudDetection.Length; i++)
            {
                var prefix = string.Format("fraudChkParamList[{0}]", i);
                Assert.AreEqual(request.FraudDetection[i].Name, dictionary[prefix + ".name"]);
                Assert.AreEqual(request.FraudDetection[i].Value, dictionary[prefix + ".value"]);
            }
        }

        private void AssertAreEqualThreeDSecValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.ThreeDSec.ActionName, dictionary[prefix + "actionName"]);
            Assert.AreEqual(TestValues.ThreeDSec.AuthTxnId, dictionary[prefix + "authTxnId"]);
            Assert.AreEqual(TestValues.ThreeDSec.PaReq, dictionary[prefix + "paReq"]);
            Assert.AreEqual(TestValues.ThreeDSec.PaRes, dictionary[prefix + "paRes"]);
        }

        private void AssertAreEqualFraudValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.NameValue.Name, dictionary[prefix + "name"]);
            Assert.AreEqual(TestValues.NameValue.Value, dictionary[prefix + "value"]);
        }

        private void AssertAreEqualOrderValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.Order.InvoiceNumber, dictionary[prefix + "invoiceNumber"]);
            Assert.AreEqual(TestValues.Order.Description, dictionary[prefix + "description"]);
            Assert.AreEqual(TestValues.Order.TotalAmount.ToString(), dictionary[prefix + "totalAmount"]);
        }

        private void AssertAreEqualCustomerValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.Customer.Email, dictionary[prefix + "email"]);
            Assert.AreEqual(TestValues.Customer.CustomerId, dictionary[prefix + "customerId"]);
            Assert.AreEqual(TestValues.Customer.CustomerIP, dictionary[prefix + "customerIP"]);
        }

        private void AssertAreEqualAddressValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.Address.FirstName, dictionary[prefix + "firstName"]);
            Assert.AreEqual(TestValues.Address.LastName, dictionary[prefix + "lastName"]);
            Assert.AreEqual(TestValues.Address.Addr, dictionary[prefix + "address"]);
            Assert.AreEqual(TestValues.Address.City, dictionary[prefix + "city"]);
            Assert.AreEqual(TestValues.Address.State, dictionary[prefix + "state"]);
            Assert.AreEqual(TestValues.Address.ZipCode, dictionary[prefix + "zipCode"]);
            Assert.AreEqual(TestValues.Address.Country, dictionary[prefix + "country"]);
        }

        private void AssertAreEqualCreditCardValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.CreditCard.Type, dictionary[prefix + "cardType"]);
            Assert.AreEqual(TestValues.CreditCard.Number, dictionary[prefix + "creditCardNumber"]);
            Assert.AreEqual(TestValues.CreditCard.ExpMonth.ToString(), dictionary[prefix + "expirationMonth"]);
            Assert.AreEqual(TestValues.CreditCard.ExpYear.ToString(), dictionary[prefix + "expirationYear"]);
            Assert.AreEqual(TestValues.CreditCard.Cvv, dictionary[prefix + "cardCodeVerification"]);
        }

        private void AssertAreEqualTransactionValues(Dictionary<string, string> dictionary, string prefix = "")
        {
            Assert.AreEqual(TestValues.TransactionAmount.Amount.ToString(), dictionary[prefix + "txnAmount"]);
            Assert.AreEqual(TestValues.TransactionAmount.CurrencyCode, dictionary[prefix + "txnCurISO"]);
            Assert.AreEqual(TestValues.TransactionAmount.MerchantRefId.ToString(), dictionary[prefix + "merchantRefId"]);
            Assert.AreEqual(TestValues.TransactionAmount.PayName, dictionary[prefix + "txnPayName"]);
            Assert.AreEqual(TestValues.TransactionAmount.Comment, dictionary[prefix + "txnComment"]);
            Assert.AreEqual(TestValues.TransactionAmount.ExtraParam1, dictionary[prefix + "txnExtraParam1"]);
            Assert.AreEqual(TestValues.TransactionAmount.ExtraParam2, dictionary[prefix + "txnExtraParam2"]);
            Assert.AreEqual(TestValues.TransactionAmount.ExtraParam3, dictionary[prefix + "txnExtraParam3"]);
            Assert.AreEqual(TestValues.TransactionAmount.ExtraParam4, dictionary[prefix + "txnExtraParam4"]);
            Assert.AreEqual(TestValues.TransactionAmount.ExtraParam5, dictionary[prefix + "txnExtraParam5"]);
            Assert.AreEqual(TestValues.TransactionAmount.InstallmentCount.ToString(), dictionary[prefix + "txnInstallmentCount"]);
            Assert.AreEqual(TestValues.TransactionAmount.LangCode, dictionary[prefix + "txnLangCode"]);
            Assert.AreEqual(TestValues.TransactionAmount.DuplicateWindowSeconds, dictionary[prefix + "txnDuplicateWindowSeconds"]);
        }
    }
}