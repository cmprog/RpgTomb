using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class RaceMapping : ClassMap<Race>
    {
        public RaceMapping()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Name);
            this.Map(x => x.Description);
            this.Map(x => x.Speed);

            this.Component(x => x.HeightRange, x =>
                {
                    x.Map(z => z.MinimumHeightInInches, "AverageHeightInchesMinimum");
                    x.Map(z => z.MaximumHeightInInches, "AverageHeightInchesMaximum");
                });

            this.Component(x => x.WeightRange, x =>
                {
                    x.Map(z => z.MinimumWeightInPounds, "AverageWeightPoundsMinimum");
                    x.Map(z => z.MaximumWeightInPounds, "AverageWeightPoundsMaximum");
                });

            this.References(x => x.Size, "SizeCategoryId").LazyLoad(Laziness.False);
        }
    }
}
