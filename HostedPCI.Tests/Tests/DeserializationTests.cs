using System.Collections.Generic;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol;
using HostedPCI.Domain.Protocol.Enums;
using HostedPCI.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace HostedPCI.Tests.Tests
{
    [TestClass]
    public class DeserializationTests
    {
        private static readonly IKernel NinjectKernel = Helper.GetNinjectKernel();
        private readonly IHostedPciDataConverter _converter = NinjectKernel.Get<IHostedPciDataConverter>();
        
        [TestMethod]
        public void TestResponse()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"status", "success"},
                {"pxyResponse.responseStatus", "approved"},
                {"pxyResponse.processorRefId", "1"},
                {"pxyResponse.processorType", "2"},
                {"pxyResponse.responseStatus.name", "3"},
                {"pxyResponse.responseStatus.code", "4"},
                {"pxyResponse.responseStatus.description", "5"},
                {"pxyResponse.responseStatus.reasonCode", "6"},
                {"pxyResponse.fullNativeResp", "7"},
                {"pxyResponse.threeDSAcsUrl", "8"},
                {"pxyResponse.threeDSTransactionId", "9"},
                {"pxyResponse.threeDSPARequest", "10"},
                {"frdChkResp.fullNativeResp", "11"}
            };

            var response = Response.Parse(_converter, dictionary);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Success, response.Status);
            Assert.AreEqual(ResponseStatus.Approved, response.ResponseStatus);
            Assert.AreEqual("1", response.ProcessorRefId);
            Assert.AreEqual("2", response.ProcessorType);
            Assert.AreEqual("3", response.ResponseStatusName);
            Assert.AreEqual("4", response.ResponseStatusCode);
            Assert.AreEqual("5", response.ResponseStatusDescription);
            Assert.AreEqual("6", response.ResponseStatusReasonCode);
            Assert.AreEqual("7", response.FullNativeResp);
            Assert.AreEqual("8", response.ThreeDSAcsUrl);
            Assert.AreEqual("9", response.ThreeDSTransactionId);
            Assert.AreEqual("10", response.ThreeDSPARequest);
            Assert.AreEqual("11", response.FraudServiceFullNativeResp);
        }
    }
}