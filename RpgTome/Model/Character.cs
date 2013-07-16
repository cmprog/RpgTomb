namespace RpgTome.Model
{
    public class Character
    {
        public virtual int Id { get; set; }

        public virtual Player OwningPlayer { get; set; }
        public virtual Player BackupPlayer { get; set; }

        public virtual string Name { get; set; }
        public virtual int TotalExperience { get; set; }
        public virtual int Level { get; set; }

        public virtual Race Race { get; set; }
        public virtual CharacterClass Class { get; set; }

        public virtual int Age { get; set; }
        public virtual Height Height { get; set; }
        public virtual int Weight { get; set; }
    }
}
