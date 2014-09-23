namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface IOrderItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Quantity { get; set; }
        decimal? Price { get; set; }
        string Taxable { get; set; }
    }
}