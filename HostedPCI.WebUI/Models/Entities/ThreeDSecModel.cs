using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class ThreeDSecModel
    {
        public string ActionName { get; set; }
        public string AuthTxnId { get; set; }
        public string PaReq { get; set; }
        public string PaRes { get; set; }

        public static ThreeDSec ConvertToDomain(ThreeDSecModel model)
        {
            return model == null ? null : new ThreeDSec(model.ActionName, model.AuthTxnId, model.PaReq, model.PaRes);
        }
    }
}