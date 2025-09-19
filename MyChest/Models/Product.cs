namespace MyChest.Models
{
    public class Product
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int? Amount { get; set; }
        public string? Tags { get; set; }
        public string? Measure { get; set; }
        public DateOnly? Validity { get; set; }
        public Product(int code, string name, string brand, int amount, string? tagsId, string measure, DateOnly? validity)
        {
            this.Code = code;
            this.Name = name;
            this.Brand = brand;
            this.Amount = amount;
            this.Tags = tagsId;
            this.Measure = measure;
            this.Validity = validity;
        }
        public Product()
        {
            
        }
    }
}
