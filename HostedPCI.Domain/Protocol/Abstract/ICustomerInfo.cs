namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface ICustomerInfo
    {
        string Email { get; set; }
        string CustomerId { get; set; }
        string CustomerIP { get; set; }
        IAddress BillingAddress { get; set; }
        IAddress ShippingAddress { get; set; }
    }
}