using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class LanguageMapping : ClassMap<Language>
    {
        public LanguageMapping()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Name);
            this.Map(x => x.Script);
        }
    }
}
