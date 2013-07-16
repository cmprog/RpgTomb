using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgTome.Model
{
    public class WeightRange
    {
        public virtual int MinimumWeightInPounds { get; set; }
        public virtual int MaximumWeightInPounds { get; set; }

        public override string ToString()
        {
            return string.Concat(this.MinimumWeightInPounds, "-", this.MaximumWeightInPounds, " lb.");
        }
    }
}
