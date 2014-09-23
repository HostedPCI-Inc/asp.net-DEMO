using HostedPCI.Domain.Model;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.Tests.Helpers
{
    public static class TestHelper
    {
        public static ApiCredentials CreateTestCredentials()
        {
            return new ApiCredentials(
                TestValues.Credentials.Url,
                TestValues.Credentials.Url,
                TestValues.Credentials.Url,
                TestValues.Credentials.Url,
                TestValues.Credentials.Url,
                TestValues.Credentials.ApiVersion,
                TestValues.Credentials.ApiType,
                TestValues.Credentials.UserName,
                TestValues.Credentials.UserPassKey);
        }

        public static BillingAddress CreateRandomBillingAddress()
        {
            return new BillingAddress(
                TestValues.Address.FirstName,
                TestValues.Address.LastName,
                TestValues.Address.Addr,
                TestValues.Address.City,
                TestValues.Address.State,
                TestValues.Address.ZipCode,
                TestValues.Address.Country);
        }

        public static ShippingAddress CreateRandomShippingAddress()
        {
            return new ShippingAddress(
                TestValues.Address.FirstName,
                TestValues.Address.LastName,
                TestValues.Address.Addr,
                TestValues.Address.City,
                TestValues.Address.State,
                TestValues.Address.ZipCode,
                TestValues.Address.Country);
        }

        public static CreditCard CreateRandomCreditCard()
        {
            return new CreditCard(
                TestValues.CreditCard.Type,
                TestValues.CreditCard.Number,
                TestValues.CreditCard.ExpMonth,
                TestValues.CreditCard.ExpYear,
                TestValues.CreditCard.Cvv);
        }

        public static FraudDetection CreateRandomFraudDetection()
        {
            return new FraudDetection(
                TestValues.NameValue.Name,
                TestValues.NameValue.Value);
        }

        public static OrderItem CreateRandomOrderItem(bool fillAll = true)
        {
            return fillAll
                ? new OrderItem(
                    TestValues.OrderItemValue.Id,
                    TestValues.OrderItemValue.Name,
                    TestValues.OrderItemValue.Description,
                    TestValues.OrderItemValue.Quantity,
                    TestValues.OrderItemValue.Price,
                    TestValues.OrderItemValue.Taxable)
                : new OrderItem(
                    TestValues.OrderItemValue.Id,
                    TestValues.OrderItemValue.Name,
                    price: TestValues.OrderItemValue.Price);
        }

        public static ThreeDSec CreateRandomThreeDSec(bool fillAll = true)
        {
            return fillAll
                ? new ThreeDSec(
                    TestValues.ThreeDSec.ActionName,
                    TestValues.ThreeDSec.AuthTxnId,
                    TestValues.ThreeDSec.PaReq,
                    TestValues.ThreeDSec.PaRes,
                    TestValues.ThreeDSec.AuthSignComboList)
                : new ThreeDSec(
                    TestValues.ThreeDSec.ActionName,
                    TestValues.ThreeDSec.AuthTxnId,
                    paRes: TestValues.ThreeDSec.PaRes);
        }

        public static Transaction CreateRandomTransactionAmount(bool fillAll = true)
        {
            return fillAll
                ? new Transaction(
                    TestValues.TransactionAmount.Amount,
                    TestValues.TransactionAmount.CurrencyCode,
                    TestValues.TransactionAmount.PayName,
                    TestValues.TransactionAmount.MerchantRefId,
                    TestValues.TransactionAmount.Comment,
                    TestValues.TransactionAmount.ExtraParam1,
                    TestValues.TransactionAmount.ExtraParam2,
                    TestValues.TransactionAmount.ExtraParam3,
                    TestValues.TransactionAmount.ExtraParam4,
                    TestValues.TransactionAmount.ExtraParam5,
                    TestValues.TransactionAmount.InstallmentCount,
                    TestValues.TransactionAmount.LangCode,
                    TestValues.TransactionAmount.DuplicateWindowSeconds)
                : new Transaction(
                    TestValues.TransactionAmount.Amount,
                    TestValues.TransactionAmount.CurrencyCode,
                    comment: TestValues.TransactionAmount.Comment);
        }

        public static Order CreateRandomOrder(bool fillAll = true)
        {
            return fillAll
                ? new Order(
                    TestValues.Order.InvoiceNumber,
                    TestValues.Order.Description,
                    TestValues.Order.TotalAmount,
                    TestValues.Order.OrderItems)
                : new Order(
                    TestValues.Order.InvoiceNumber,
                    orderItems: TestValues.Order.OrderItems);
        }

        public static CustomerInfo CreateCustomerInfo()
        {
            return new CustomerInfo(
                TestValues.Customer.Email,
                TestValues.Customer.CustomerId,
                TestValues.Customer.BillingAddress,
                TestValues.Customer.ShippingAddress,
                TestValues.Customer.CustomerIP);
        }
    }
}