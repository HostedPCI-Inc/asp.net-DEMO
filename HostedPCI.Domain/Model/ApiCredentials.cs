using System;
using HostedPCI.Domain.Enums;

namespace HostedPCI.Domain.Model
{
    public class ApiCredentials
    {
        private readonly string _paymentAuthUrl;
        private readonly string _paymentSaleUrl;
        private readonly string _paymentCaptureUrl;
        private readonly string _paymentCreditUrl;
        private readonly string _paymentVoidUrl;

        public string ApiVersion { get; private set; }
        public string ApiType { get; private set; }
        public string UserName { get; private set; }
        public string UserPassKey { get; private set; }

        public ApiCredentials(string paymentAuthUrl, string paymentSaleUrl, string paymentCaptureUrl,
            string paymentCreditUrl, string paymentVoidUrl, string apiVersion, string apiType,
            string userName, string userPassKey)
        {
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                throw new ArgumentNullException(paymentAuthUrl);
            if (string.IsNullOrWhiteSpace(paymentSaleUrl))
                throw new ArgumentNullException(paymentSaleUrl);
            if (string.IsNullOrWhiteSpace(paymentCaptureUrl))
                throw new ArgumentNullException(paymentCaptureUrl);
            if (string.IsNullOrWhiteSpace(paymentCreditUrl))
                throw new ArgumentNullException(paymentCreditUrl);
            if (string.IsNullOrWhiteSpace(paymentVoidUrl))
                throw new ArgumentNullException(paymentVoidUrl);

            if (string.IsNullOrWhiteSpace(apiVersion))
                throw new ArgumentNullException(apiVersion);
            if (string.IsNullOrWhiteSpace(apiType))
                throw new ArgumentNullException(apiType);
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(userName);
            if (string.IsNullOrWhiteSpace(userPassKey))
                throw new ArgumentNullException(userPassKey);

            _paymentAuthUrl = paymentAuthUrl;
            _paymentSaleUrl = paymentSaleUrl;
            _paymentCaptureUrl = paymentCaptureUrl;
            _paymentCreditUrl = paymentCreditUrl;
            _paymentVoidUrl = paymentVoidUrl;

            ApiVersion = apiVersion;
            ApiType = apiType;
            UserName = userName;
            UserPassKey = userPassKey;
        }

        public string GetUrl(RequestType requestType)
        {
            switch (requestType)
            {
                case RequestType.Auth:
                    return _paymentAuthUrl;

                case RequestType.Sale:
                    return _paymentSaleUrl;

                case RequestType.Capture:
                    return _paymentCaptureUrl;

                case RequestType.Credit:
                    return _paymentCreditUrl;

                case RequestType.Void:
                    return _paymentVoidUrl;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}