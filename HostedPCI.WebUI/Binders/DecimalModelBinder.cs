using System;
using System.Globalization;
using System.Web.Mvc;

namespace HostedPCI.WebUI.Binders
{
    public class DecimalModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == null)
                return base.BindModel(controllerContext, bindingContext);

            var wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            if (!string.IsNullOrWhiteSpace(valueProviderResult.AttemptedValue))
            {
                if (valueProviderResult.AttemptedValue
                        .IndexOf(wantedSeperator, StringComparison.InvariantCultureIgnoreCase) > -1)
                    return Convert.ToDecimal(valueProviderResult.AttemptedValue);


                var alternateSeperator = (wantedSeperator == "," ? "." : ",");
                var attemptedValue = valueProviderResult.AttemptedValue.Replace(alternateSeperator, wantedSeperator);
                return Convert.ToDecimal(attemptedValue);
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}