using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.Tests.Helpers
{
    public static class TestValues
    {
        public static class Credentials
        {
            public const string Url = "http://domain.com/";
            public const string ApiVersion = "1.0";
            public const string ApiType = "Test";
            public const string UserName = "usename";
            public const string UserPassKey = "password";
        }

        public static class Address
        {
            public const string FirstName = "Jane";
            public const string LastName = "Doe";
            public const string Addr = "1234 South Oak Street";
            public const string City = "Chicago";
            public const string State = "Illinois";
            public const string ZipCode = "56789";
            public const string Country = "USA";
        }

        public static class CreditCard
        {
            public const string Type = "VISA";
            public const string Number = "4111111111111111";
            public const int ExpMonth = 12;
            public const int ExpYear = 2015;
            public const string Cvv = "123";
        }

        public static class NameValue
        {
            public const string Name = "Name";
            public const string Value = "Value";
        }

        public static class OrderItemValue
        {
            public const string Id = "1";
            public const string Name = "Name of OrderItem";
            public const string Description = "Description of OrderItem";
            public const string Quantity = "2";
            public const decimal Price = 3;
            public const bool Taxable = true;
        }

        public static class ThreeDSec
        {
            public const string ActionName = "verifyenroll";
            public const string AuthTxnId = "7410852";
            public const string PaReq = "QWERTADFG=";
            public const string PaRes = "ZAQ!@WSX=";
            public static readonly string[] AuthSignComboList = {"A", "B", "C"};
        }

        public static class TransactionAmount
        {
            public const decimal Amount = 100;
            public const string CurrencyCode = "USD";
            public const string MerchantRefId = "77";
            public const string PayName = "Payment name";
            public const string Comment = "Test comment";
            public const string ExtraParam1 = "Extra param 1";
            public const string ExtraParam2 = "Extra param 2";
            public const string ExtraParam3 = "Extra param 3";
            public const string ExtraParam4 = "Extra param 4";
            public const string ExtraParam5 = "Extra param 5";
            public const int InstallmentCount = 1;
            public const string LangCode = "En";
            public const string DuplicateWindowSeconds = "1";
        }

        public static class Order
        {
            public const string InvoiceNumber = "Test comment";
            public const decimal TotalAmount = 100;
            public const string Description = "Description of order";
            public static readonly OrderItem[] OrderItems;

            static Order()
            {
                OrderItems = new[]
                {
                    TestHelper.CreateRandomOrderItem(),
                    TestHelper.CreateRandomOrderItem(),
                    TestHelper.CreateRandomOrderItem()
                };
            }
        }

        public static class Customer
        {
            public const string Email = "test_user@domain.com";
            public const string CustomerId = "123";
            public const string CustomerIP = "127.0.0.1";
            public static readonly BillingAddress BillingAddress = TestHelper.CreateRandomBillingAddress();
            public static readonly ShippingAddress ShippingAddress = TestHelper.CreateRandomShippingAddress();
        }
    }
}