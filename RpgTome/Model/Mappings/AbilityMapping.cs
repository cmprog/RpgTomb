using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class AbilityMapping : ClassMap<Ability>
    {
        public AbilityMapping()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Name).Not.Nullable();
            this.Map(x => x.Abbreviation).Not.Nullable();
            this.Map(x => x.Description).Not.Nullable();
        }
    }
}
