using System.Runtime.Serialization;
using HostedPCI.Domain.Protocol.Abstract;

namespace HostedPCI.Domain.Protocol.Models
{
    /// <summary> 3D Secure (Verified by Visa and MasterCard securecode)  </summary>
    [DataContract]
    public class ThreeDSec : IThreeDSec
    {
        /// <summary> 
        /// Value empty string when no 3D Secure action is requested. 
        /// Pass “verifyenroll” when card enrollment needs to be verified. 
        /// Pass “verifyresp” when authentication response needs to be verified 
        /// </summary>
        [DataMember(Name = "actionName", EmitDefaultValue = false)]
        public string ActionName { get; set; }

        /// <summary> Value pass the authentication id received from “verifyenroll” call </summary>
        [DataMember(Name = "authTxnId", EmitDefaultValue = false)]
        public string AuthTxnId { get; set; }

        /// <summary> Value pass the payer authentication request value received from “verifyenroll” call </summary>
        [DataMember(Name = "paReq", EmitDefaultValue = false)]
        public string PaReq { get; set; }

        /// <summary> Value pass the payer authentication response value received from pin verification call </summary>
        [DataMember(Name = "paRes", EmitDefaultValue = false)]
        public string PaRes { get; set; }

        /// <summary> 
        /// Value combined statuses of Authentication Result + Signature Result that are acceptable. 
        /// The results are received after the verification call is completed by HPCI service prior to requesting an Authorization from the payment gateway. 
        /// Typical values are “YY”, “AY” and “UY”.
        /// Where [x] starts at 0 and increases with each item added. 
        /// </summary>
        [DataMember(Name = "authSignComboList", EmitDefaultValue = false)]
        public string[] AuthSignComboList { get; set; }

        public ThreeDSec(string actionName = null, string authTxnId = null, string paReq = null, string paRes = null,
            string[] authSignComboList = null)
        {
            ActionName = actionName;
            AuthTxnId = authTxnId;
            PaReq = paReq;
            PaRes = paRes;
            AuthSignComboList = authSignComboList;
        }
    }
}