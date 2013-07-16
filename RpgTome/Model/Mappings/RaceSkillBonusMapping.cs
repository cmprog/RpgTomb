using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public class RaceSkillBonusMapping : ClassMap<RaceSkillBonus>
    {
        public RaceSkillBonusMapping()
        {
            this.CompositeId()
                .KeyReference(x => x.Race, "RaceId")
                .KeyReference(x => x.Skill, "SkillId");

            this.Map(x => x.Bonus);
        }
    }
}
