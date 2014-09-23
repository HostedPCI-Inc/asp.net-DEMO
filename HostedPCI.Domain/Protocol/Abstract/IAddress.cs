namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface IAddress
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string Country { get; set; }
    }
}