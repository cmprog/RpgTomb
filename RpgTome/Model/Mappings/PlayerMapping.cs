using FluentNHibernate.Mapping;

namespace RpgTome.Model.Mappings
{
    public class PlayerMapping : ClassMap<Player>
    {
        public PlayerMapping()
        {
            this.Id(x => x.Id);

            this.Component(x => x.Name, m =>
                {
                    m.Map(x => x.First, "FirstName");
                    m.Map(x => x.Last, "LastName");
                });
        }
    }
}
