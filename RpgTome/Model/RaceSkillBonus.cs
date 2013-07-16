namespace RpgTome.Model
{
    public class RaceSkillBonus
    {
        public virtual Race Race { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual int Bonus { get; set; }

        public override int GetHashCode()
        {
            return HashHelper.GetHashCode(this.Race, this.Skill);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var lObjAsBonus = obj as RaceSkillBonus;
            if (lObjAsBonus == null) return false;

            return Equals(this.Race, lObjAsBonus.Race) &&
                   Equals(this.Skill, lObjAsBonus.Skill);
        }
    }
}
