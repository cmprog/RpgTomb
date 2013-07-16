using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgTome.Model
{
    public class Ability
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Abbreviation { get; set; }
        public virtual string Description { get; set; }
    }
}
