namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface IFraudDetection
    {
        string Name { get; set; }
        string Value { get; set; }
    }
}