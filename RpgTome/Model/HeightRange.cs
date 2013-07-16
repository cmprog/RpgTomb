using System.Text;

namespace RpgTome.Model
{
    public class HeightRange
    {
        public virtual int MinimumHeightInInches { get; set; }
        public virtual int MaximumHeightInInches { get; set; }

        public override string ToString()
        {
            var lStringBuilder = new StringBuilder();
            this.ToStringAppend(lStringBuilder, this.MinimumHeightInInches);
            lStringBuilder.Append(" - ");
            this.ToStringAppend(lStringBuilder, this.MaximumHeightInInches);
            return lStringBuilder.ToString();
        }

        private void ToStringAppend(StringBuilder stringBuilder, int totalInches)
        {
            var lFeet = totalInches/12;
            var lInches = totalInches%12;

            if (lFeet > 0) stringBuilder.Append(lFeet).Append("'");
            stringBuilder.Append(lInches).Append("''");
        }
    }
}
