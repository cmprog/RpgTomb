namespace RpgTome.Model
{
    public class SizeCategory
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual int OrderBy { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
