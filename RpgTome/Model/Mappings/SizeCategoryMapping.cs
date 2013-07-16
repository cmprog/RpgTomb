using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public sealed class SizeCategoryMapping : ClassMap<SizeCategory>
    {
        public SizeCategoryMapping()
        {
            this.Id(x => x.Id);

            this.Map(x => x.Name);
            this.Map(x => x.OrderBy);
        }
    }
}
