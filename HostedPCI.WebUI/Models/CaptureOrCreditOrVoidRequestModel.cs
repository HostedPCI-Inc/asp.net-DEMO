using System;
using System.ComponentModel.DataAnnotations;
using HostedPCI.Domain.Protocol;

namespace HostedPCI.WebUI.Models
{
    public class CaptureOrCreditOrVoidRequestModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string MerchantRefId { get; set; }

        [Required]
        public string ProcessorRefId { get; set; }

        public static CaptureRequest ConvertToCaptureRequest(CaptureOrCreditOrVoidRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new CaptureRequest(model.Amount, model.CurrencyCode, model.MerchantRefId, model.ProcessorRefId);
        }

        public static CreditRequest ConvertToCreditRequest(CaptureOrCreditOrVoidRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new CreditRequest(model.Amount, model.CurrencyCode, model.MerchantRefId, model.ProcessorRefId);
        }

        public static VoidRequest ConvertToVoidRequest(CaptureOrCreditOrVoidRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new VoidRequest(model.Amount, model.CurrencyCode, model.MerchantRefId, model.ProcessorRefId);
        }
    }
}