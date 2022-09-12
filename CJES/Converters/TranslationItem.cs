namespace CJES.Converters
{
    public class TranslationItem<T>
    {
        /// <summary>
        /// The 'main' term that will be used internally.
        /// </summary>
        /// <example>
        /// Eigentumswohnung, Condominium will be 'unified' under the notion 'Condominium'
        /// </example>
        public T Notion { get; }

        /// <summary>
        /// The piece of information used to translate back the more generic notion to the more specific term.
        /// </summary>
        /// <example>
        /// Condominium for DE will be 'translated' as Eigentumswohnung. DE, in this case, is the discriminator.
        /// Condominium for HR will be 'translated' as Condominium. In this case the discriminator is HR.
        /// </example>
        public string? Discriminator { get; }

        /// <summary>
        /// The term that will be translated into a notion. The resulting notion, together with the discriminator, will result into the term.
        /// </summary>
        /// <example>
        /// Eigentumswohnung and Condominium are the terms for Condominium notion.
        /// </example>
        public T Term { get; }
        public TranslationItem(T notion, string discriminator, T term)
        {
            Notion = notion;
            Discriminator = discriminator;
            Term = term;
        }
    }
}
