using System;
using System.Configuration;
using System.Linq;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Model;

namespace HostedPCI.Domain.Helpers
{
    public class HostedPciConfiguration : IHostedPciConfiguration
    {
        private const string PaymentAuthUrlSectionName = "HostedPCI_PaymentAuthUrl";
        private const string PaymentSaleUrlSectionName = "HostedPCI_PaymentSaleUrl";
        private const string PaymentCaptureUrlSectionName = "HostedPCI_PaymentCaptureUrl";
        private const string PaymentCreditUrlSectionName = "HostedPCI_PaymentCreditUrl";
        private const string PaymentVoidUrlSectionName = "HostedPCI_PaymentVoidUrl";

        private const string ApiVersionSectionName = "HostedPCI_ApiVersion";
        private const string ApiTypeSectionName = "HostedPCI_ApiType";
        private const string UserNameSectionName = "HostedPCI_UserName";
        private const string UserPassKeySectionName = "HostedPCI_UserPassKey";

        public ApiCredentials GetConfigurationSettings()
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(PaymentAuthUrlSectionName))
                TrhowCantFindSectionNameException(PaymentAuthUrlSectionName);
            string paymentAuthUrl = ConfigurationManager.AppSettings[PaymentAuthUrlSectionName];
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                TrhowSectionNameIsRequiredException(PaymentAuthUrlSectionName);
            
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(PaymentSaleUrlSectionName))
                TrhowCantFindSectionNameException(PaymentSaleUrlSectionName);
            string paymentSaleUrl = ConfigurationManager.AppSettings[PaymentSaleUrlSectionName];
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                TrhowSectionNameIsRequiredException(PaymentSaleUrlSectionName);

            if (!ConfigurationManager.AppSettings.AllKeys.Contains(PaymentCaptureUrlSectionName))
                TrhowCantFindSectionNameException(PaymentCaptureUrlSectionName);
            string paymentCaptureUrl = ConfigurationManager.AppSettings[PaymentCaptureUrlSectionName];
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                TrhowSectionNameIsRequiredException(PaymentCaptureUrlSectionName);

            if (!ConfigurationManager.AppSettings.AllKeys.Contains(PaymentCreditUrlSectionName))
                TrhowCantFindSectionNameException(PaymentCreditUrlSectionName);
            string paymentCreditUrl = ConfigurationManager.AppSettings[PaymentCreditUrlSectionName];
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                TrhowSectionNameIsRequiredException(PaymentCreditUrlSectionName);

            if (!ConfigurationManager.AppSettings.AllKeys.Contains(PaymentVoidUrlSectionName))
                TrhowCantFindSectionNameException(PaymentVoidUrlSectionName);
            string paymentVoidUrl = ConfigurationManager.AppSettings[PaymentVoidUrlSectionName];
            if (string.IsNullOrWhiteSpace(paymentAuthUrl))
                TrhowSectionNameIsRequiredException(PaymentVoidUrlSectionName);


            if (!ConfigurationManager.AppSettings.AllKeys.Contains(ApiVersionSectionName))
                TrhowCantFindSectionNameException(ApiVersionSectionName);
            string apiVersion = ConfigurationManager.AppSettings[ApiVersionSectionName];
            if (string.IsNullOrWhiteSpace(apiVersion))
                TrhowSectionNameIsRequiredException(ApiVersionSectionName);


            if (!ConfigurationManager.AppSettings.AllKeys.Contains(ApiTypeSectionName))
                TrhowCantFindSectionNameException(ApiTypeSectionName);
            string apiType = ConfigurationManager.AppSettings[ApiTypeSectionName];
            if (string.IsNullOrWhiteSpace(apiType))
                TrhowSectionNameIsRequiredException(ApiTypeSectionName);


            if (!ConfigurationManager.AppSettings.AllKeys.Contains(UserNameSectionName))
                TrhowCantFindSectionNameException(UserNameSectionName);
            string userName = ConfigurationManager.AppSettings[UserNameSectionName];
            if (string.IsNullOrWhiteSpace(userName))
                TrhowSectionNameIsRequiredException(UserNameSectionName);


            if (!ConfigurationManager.AppSettings.AllKeys.Contains(UserPassKeySectionName))
                TrhowCantFindSectionNameException(UserPassKeySectionName);
            string userPassKey = ConfigurationManager.AppSettings[UserPassKeySectionName];
            if (string.IsNullOrWhiteSpace(userPassKey))
                TrhowSectionNameIsRequiredException(UserPassKeySectionName);


            return new ApiCredentials(paymentAuthUrl, paymentSaleUrl, paymentCaptureUrl,
                paymentCreditUrl, paymentVoidUrl, apiVersion, apiType, userName, userPassKey);
        }

        private void TrhowCantFindSectionNameException(string name)
        {
            throw new ApplicationException(string.Format("Can't find '{0}' in configuraion file", name));
        }

        private void TrhowSectionNameIsRequiredException(string name)
        {
            throw new ApplicationException(
                string.Format("Invalid configuration settings. '{0}' is a required field.", name));
        }
    }
}