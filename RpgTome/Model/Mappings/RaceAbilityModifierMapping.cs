using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class RaceAbilityModifierMapping : ClassMap<RaceAbilityModifier>
    {
        public RaceAbilityModifierMapping()
        {
            this.CompositeId()
                .KeyReference(x => x.Race, "RaceId")
                .KeyReference(x => x.Ability, "AbilityId");

            this.Map(x => x.Modifier);
        }
    }
}
