using CJES.Model;
using static CJES.Model.Category;

namespace CJES.Converters
{
    public static class CategoryTranslationMap
    {
        private static readonly List<TranslationItem<Category>> _map = new(){
            new TranslationItem<Category>(Condominium, "DE", Eigentumswohnung),
            new TranslationItem<Category>(Condominium, "AT", Eigentumswohnung),
            new TranslationItem<Category>(Condominium, "HR", Condominium),

            new TranslationItem<Category>(SingleFamilyHouse, "DE", Einfamilenhaus),
            new TranslationItem<Category>(SingleFamilyHouse, "AT", Einfamilenhaus),
            new TranslationItem<Category>(SingleFamilyHouse, "HR", SingleFamilyHouse),

            new TranslationItem<Category>(MultiFamilyDwelling, "DE", Mehrfamilienhaus),
            new TranslationItem<Category>(MultiFamilyDwelling, "AT", Mehrfamilienhaus),
            new TranslationItem<Category>(MultiFamilyDwelling, "HR", MultiFamilyDwelling),

            new TranslationItem<Category>(UndevelopedPlot, "DE", Grundstueck),
            new TranslationItem<Category>(UndevelopedPlot, "AT", Grundstueck),
            new TranslationItem<Category>(UndevelopedPlot, "HR", UndevelopedPlot),
        };

        public static Category GetNotion(Category term, string? discriminator)
        {
            return
                (null == discriminator ?
                _map.FirstOrDefault(item => item.Term == term)?.Notion
                : _map.SingleOrDefault(item => item.Term == term && item.Discriminator == discriminator)?.Notion)
                ?? term;
        }

        public static Category GetTerm(Category notion, string? discriminator)
        {
            return
                (null == discriminator ?
                _map.FirstOrDefault(item => item.Notion == notion)?.Term
                : _map.SingleOrDefault(item => item.Notion == notion && item.Discriminator == discriminator)?.Term)
                ?? notion;
        }
    }
}
