using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CJES.Model
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Category
    {
        //x [EnumMember(Value = "ETW")]
        Eigentumswohnung,
        Condominium,
        //x [EnumMember(Value = "EFH")]
        Einfamilenhaus,
        SingleFamilyHouse,
        //x [EnumMember(Value = "MFH")]
        Mehrfamilienhaus,
        MultiFamilyDwelling,
        //x [EnumMember(Value = "GRD")]
        Grundstueck,
        UndevelopedPlot
    }
}
