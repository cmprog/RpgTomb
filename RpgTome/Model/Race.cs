namespace RpgTome.Model
{
    public class Race
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual HeightRange HeightRange { get; set; }
        public virtual WeightRange WeightRange { get; set; }

        public virtual int Speed { get; set; }
        public virtual SizeCategory Size { get; set; }
    }
}
