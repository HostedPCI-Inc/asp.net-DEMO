namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface ICreditCard
    {
        string CardType { get; set; }
        string CardNumber { get; set; }
        int ExpirationMonth { get; set; }
        int ExpirationYear { get; set; }
        string CvvCode { get; set; }
    }
}