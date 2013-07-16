using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class CharacterMapping : ClassMap<Character>
    {
        public CharacterMapping()
        {
            this.Id(x => x.Id);

            this.References(x => x.OwningPlayer, "OwningPlayerId").LazyLoad(Laziness.False);
            this.References(x => x.BackupPlayer, "BackupPlayerId").Nullable().LazyLoad(Laziness.False);

            this.Map(x => x.Name);
            this.Map(x => x.TotalExperience);
            this.Map(x => x.Level);

            this.References(x => x.Race, "RaceId");
            this.References(x => x.Class, "ClassId");

            this.Map(x => x.Age);
            this.Map(x => x.Height, "HeightInches");
            this.Map(x => x.Weight, "WeightPounds");
        }
    }
}
