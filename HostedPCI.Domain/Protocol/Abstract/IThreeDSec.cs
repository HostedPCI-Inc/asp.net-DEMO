namespace HostedPCI.Domain.Protocol.Abstract
{
    public interface IThreeDSec
    {
        string ActionName { get; set; }
        string AuthTxnId { get; set; }
        string PaReq { get; set; }
        string PaRes { get; set; }
    }
}