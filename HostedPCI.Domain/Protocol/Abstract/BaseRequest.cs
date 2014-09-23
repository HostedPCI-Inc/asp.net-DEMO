using System;
using System.Runtime.Serialization;
using HostedPCI.Domain.Enums;
using HostedPCI.Domain.Model;

namespace HostedPCI.Domain.Protocol.Abstract
{
    [DataContract]
    public abstract class BaseRequest
    {
        public RequestType RequestType { get; private set; }

        [DataMember(Name = "apiVersion", EmitDefaultValue = false)]
        public string ApiVersion { get; private set; }

        [DataMember(Name = "apiType", EmitDefaultValue = false)]
        public string ApiType { get; private set; }

        /// <summary> API UserId </summary>
        [DataMember(Name = "userName", EmitDefaultValue = false)]
        public string UserName { get; private set; }

        /// <summary> API Passkey </summary>
        [DataMember(Name = "userPassKey", EmitDefaultValue = false)]
        public string UserPassKey { get; private set; }

        protected BaseRequest(RequestType requestType)
        {
            RequestType = requestType;
        }

        public void SetRequestCredentials(ApiCredentials credentials)
        {
            if (credentials == null)
                throw new ArgumentNullException("credentials");
            if (string.IsNullOrWhiteSpace(credentials.ApiType))
                throw new ArgumentNullException(credentials.ApiType);
            if (string.IsNullOrWhiteSpace(credentials.ApiVersion))
                throw new ArgumentNullException(credentials.ApiVersion);
            if (string.IsNullOrWhiteSpace(credentials.UserName))
                throw new ArgumentNullException(credentials.UserName);
            if (string.IsNullOrWhiteSpace(credentials.UserPassKey))
                throw new ArgumentNullException(credentials.UserPassKey);

            ApiType = credentials.ApiType;
            ApiVersion = credentials.ApiVersion;
            UserName = credentials.UserName;
            UserPassKey = credentials.UserPassKey;
        }
    }
}