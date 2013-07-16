namespace RpgTome.Model
{
    public class RaceLanguage
    {
        public virtual Race Race { get; set; }
        public virtual Language Language { get; set; }

        public override int GetHashCode()
        {
            return HashHelper.GetHashCode(this.Race, this.Language);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var lObjAsLanguage = obj as RaceLanguage;
            if (lObjAsLanguage == null) return false;

            return Equals(this.Race, lObjAsLanguage.Race) &&
                   Equals(this.Language, lObjAsLanguage.Language);
        }
    }
}
