namespace RpgTome.Model
{
    public class RaceAbilityModifier
    {
        public virtual Race Race { get; set; }
        public virtual Ability Ability { get; set; }
        public virtual int Modifier { get; set; }

        public override int GetHashCode()
        {
            return HashHelper.GetHashCode(this.Race, this.Ability);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var lObjAsModifier = obj as RaceAbilityModifier;
            if (lObjAsModifier == null) return false;

            return Equals(this.Race, lObjAsModifier.Race) &&
                   Equals(this.Ability, lObjAsModifier.Ability);
        }
    }
}
