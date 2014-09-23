using System;
using System.ComponentModel.DataAnnotations;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class TransactionModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string MerchantRefId { get; set; }

        public string PayName { get; set; }
        public string Comment { get; set; }
        public string ExtraParam1 { get; set; }
        public string ExtraParam2 { get; set; }
        public string ExtraParam3 { get; set; }
        public string ExtraParam4 { get; set; }
        public string ExtraParam5 { get; set; }
        public int? InstallmentCount { get; set; }
        public string LangCode { get; set; }
        public string DuplicateWindowSeconds { get; set; }

        public static Transaction ConvertToDomain(TransactionModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            return new Transaction(model.Amount, model.CurrencyCode, model.PayName,
                model.MerchantRefId, model.Comment, model.ExtraParam1, model.ExtraParam2,
                model.ExtraParam3, model.ExtraParam4, model.ExtraParam5, model.InstallmentCount,
                model.LangCode, model.DuplicateWindowSeconds);
        }
    }
}