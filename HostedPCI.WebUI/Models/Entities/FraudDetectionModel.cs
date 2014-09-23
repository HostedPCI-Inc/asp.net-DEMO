using System.Linq;
using HostedPCI.Domain.Protocol.Models;

namespace HostedPCI.WebUI.Models.Entities
{
    public class FraudDetectionModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static FraudDetection[] ConvertToDomain(FraudDetectionModel[] model)
        {
            if (model == null || !model.Any())
                return null;

            return model.Select(ConvertToDomain).ToArray();
        }

        public static FraudDetection ConvertToDomain(FraudDetectionModel model)
        {
            return model == null ? null : new FraudDetection(model.Name, model.Value);
        }
    }
}