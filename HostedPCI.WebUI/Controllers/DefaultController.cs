using System.Web.Mvc;
using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Protocol.Abstract;
using HostedPCI.WebUI.Helpers;
using HostedPCI.WebUI.Models;

namespace HostedPCI.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHostedPciService _service;
        private readonly IHostedPciDataConverter _converter;
        private readonly IHostedPciConfiguration _configuration;

        public DefaultController(IHostedPciService service, IHostedPciDataConverter converter, IHostedPciConfiguration configuration)
        {
            _service = service;
            _converter = converter;
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Auth

        public ActionResult Auth()
        {
            return View(DummyDataHelper.GetTestAuthRequestModel());
        }

        public ActionResult DummyAuth()
        {
            return View("Auth", DummyDataHelper.GetDummyAuthRequestModel());
        }

        [HttpPost]
        public ActionResult Auth(AuthOrSaleRequestModel model)
        {
            return ProcessModelPostRequest(model, AuthOrSaleRequestModel.ConvertToAuthRequest(model));
        }

        #endregion

        #region Sale

        public ActionResult Sale()
        {
            return View(DummyDataHelper.GetTestAuthRequestModel());
        }

        public ActionResult DummySale()
        {
            return View("Sale", DummyDataHelper.GetDummyAuthRequestModel());
        }

        [HttpPost]
        public ActionResult Sale(AuthOrSaleRequestModel model)
        {
            return ProcessModelPostRequest(model, AuthOrSaleRequestModel.ConvertToSaleRequest(model));
        }

        #endregion

        #region Capture

        public ActionResult Capture()
        {
            return View(DummyDataHelper.GetTestCaptureRequestModel());
        }

        [HttpPost]
        public ActionResult Capture(CaptureOrCreditOrVoidRequestModel model)
        {
            return ProcessModelPostRequest(model, CaptureOrCreditOrVoidRequestModel.ConvertToCaptureRequest(model));
        }

        #endregion

        #region Credit

        public ActionResult Credit()
        {
            return View(DummyDataHelper.GetTestCaptureRequestModel());
        }

        [HttpPost]
        public ActionResult Credit(CaptureOrCreditOrVoidRequestModel model)
        {
            return ProcessModelPostRequest(model, CaptureOrCreditOrVoidRequestModel.ConvertToCreditRequest(model));
        }

        #endregion

        #region Void

        public ActionResult Void()
        {
            return View(DummyDataHelper.GetTestCaptureRequestModel());
        }

        [HttpPost]
        public ActionResult Void(CaptureOrCreditOrVoidRequestModel model)
        {
            return ProcessModelPostRequest(model, CaptureOrCreditOrVoidRequestModel.ConvertToVoidRequest(model));
        }

        #endregion

        private ActionResult ProcessModelPostRequest(object model, BaseRequest request)
        {
            if (!ModelState.IsValid)
                return View(model);

            string url;
            string rawRequest;
            string rawResponse;

            var response = _service.Send(_converter, _configuration.GetConfigurationSettings(),
                request, out url, out rawRequest, out rawResponse);

            var responseModel = new RequestResultModel(response, url, rawRequest, rawResponse);

            return View("Response", responseModel);
        }
    }
}