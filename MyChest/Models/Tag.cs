namespace MyChest.Models
{
    internal class Tag
    {
        public int id { get; set; }
        public string name { get; set; }

        public Tag(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
