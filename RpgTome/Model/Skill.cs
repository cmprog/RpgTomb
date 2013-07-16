﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgTome.Model
{
    public class Skill
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        
        public virtual Ability AssociatedAbility { get; set; }
    }
}
