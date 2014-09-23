namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface IOrder
    {
        string InvoiceNumber { get; set; }
        string Description { get; set; }
        decimal? TotalAmount { get; set; }
        IOrderItem[] OrderItems { get; set; }
    }
}