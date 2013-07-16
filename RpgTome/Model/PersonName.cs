using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgTome.Model
{
    public class PersonName
    {
        public virtual string First { get; set; }
        public virtual string Last { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.Last))
            {
                return this.First;
            }

            if (string.IsNullOrWhiteSpace(this.First))
            {
                return this.Last;
            }

            return string.Concat(this.Last, ", ", this.First);
        }
    }
}
