using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class SkillMapping : ClassMap<Skill>
    {
        public SkillMapping()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Name).Not.Nullable();
            this.Map(x => x.Description).Not.Nullable();

            this.References(x => x.AssociatedAbility, "AbilityId").Not.Nullable();
        }
    }
}
