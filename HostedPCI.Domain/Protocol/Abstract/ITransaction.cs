namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface ITransaction
    {
        decimal Amount { get; set; }
        string CurrencyCode { get; set; }
        string MerchantRefId { get; set; }
        string PayName { get; set; }
        string Comment { get; set; }
        string ExtraParam1 { get; set; }
        string ExtraParam2 { get; set; }
        string ExtraParam3 { get; set; }
        string ExtraParam4 { get; set; }
        string ExtraParam5 { get; set; }
        int? InstallmentCount { get; set; }
        string LangCode { get; set; }
        string DuplicateWindowSeconds { get; set; }
    }
}