using CJES.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CJES.Converters
{
    public class ReportRequestConverter : JsonConverter<ReportRequest>
    {
        public override ReportRequest Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var adjustedOptions = AdjustOptions(options);
            var reportRequest = JsonSerializer.Deserialize<ReportRequest>(ref reader, adjustedOptions);
            reportRequest.Category = CategoryTranslationMap.GetNotion(reportRequest.Category, reportRequest.Discriminator);
            return reportRequest;
        }

        public override void Write(
            Utf8JsonWriter writer,
            ReportRequest reportRequest,
            JsonSerializerOptions options)
        {
            reportRequest.Category = CategoryTranslationMap.GetTerm(reportRequest.Category, reportRequest.Discriminator);
            var adjustedOptions = AdjustOptions(options);
            JsonSerializer.Serialize(writer, reportRequest, typeof(ReportRequest), adjustedOptions);
        }

        private JsonSerializerOptions AdjustOptions(JsonSerializerOptions options)
        {
            var optionsClone = new JsonSerializerOptions(options);
            optionsClone.Converters.Remove(optionsClone.Converters.First(converter => converter is ReportRequestConverter));
            return optionsClone;
        }
    }
}
