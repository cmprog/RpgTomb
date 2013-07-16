using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class RaceLanguageMapping : ClassMap<RaceLanguage>
    {
        public RaceLanguageMapping()
        {
            this.CompositeId()
                .KeyReference(x => x.Race, "RaceId")
                .KeyReference(x => x.Language, "LanguageId");
        }
    }
}
