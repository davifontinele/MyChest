namespace MyChest.Models
{
    internal class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string TagsId { get; set; }
        public string Measure { get; set; }
        public Product(int code, string name, string brand, string description, int amount, string tagsId, string measure)
        {
            this.Code = code;
            this.Name = name;
            this.Brand = brand;
            this.Description = description;
            this.Amount = amount;
            this.TagsId = tagsId;
            this.Measure = measure;
        }
    }
}
