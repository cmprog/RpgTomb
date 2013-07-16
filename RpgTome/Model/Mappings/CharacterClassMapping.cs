using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class CharacterClassMapping : ClassMap<CharacterClass>
    {
        public CharacterClassMapping()
        {
            this.Id(x => x.Id);
        }
    }
}
