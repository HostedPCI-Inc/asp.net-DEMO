using System;
using HostedPCI.Domain.Protocol;
using HostedPCI.WebUI.Models.Entities;

namespace HostedPCI.WebUI.Models
{
    public class AuthOrSaleRequestModel
    {
        public CreditCardModel CreditCard { get; set; }
        public TransactionModel Transaction { get; set; }
        public CustomerInfoModel CustomerInfo { get; set; }
        public OrderModel Order { get; set; }
        public ThreeDSecModel ThreeDSec { get; set; }
        public FraudDetectionModel[] FraudDetection { get; set; }

        public static AuthRequest ConvertToAuthRequest(AuthOrSaleRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var card = CreditCardModel.ConvertToDomain(model.CreditCard);
            var transaction = TransactionModel.ConvertToDomain(model.Transaction);
            var customer = CustomerInfoModel.ConvertToDomain(model.CustomerInfo);
            var order = OrderModel.ConvertToDomain(model.Order);
            var threeDSec = ThreeDSecModel.ConvertToDomain(model.ThreeDSec);
            var fraudDetection = FraudDetectionModel.ConvertToDomain(model.FraudDetection);

            return new AuthRequest(card, transaction, customer, order, threeDSec, fraudDetection);
        }

        public static SaleRequest ConvertToSaleRequest(AuthOrSaleRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var card = CreditCardModel.ConvertToDomain(model.CreditCard);
            var transaction = TransactionModel.ConvertToDomain(model.Transaction);
            var customer = CustomerInfoModel.ConvertToDomain(model.CustomerInfo);
            var order = OrderModel.ConvertToDomain(model.Order);
            var threeDSec = ThreeDSecModel.ConvertToDomain(model.ThreeDSec);
            var fraudDetection = FraudDetectionModel.ConvertToDomain(model.FraudDetection);

            return new SaleRequest(card, transaction, customer, order, threeDSec, fraudDetection);
        }
    }
}