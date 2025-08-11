namespace MyChest.Models
{
    public class Product
    {
        /// <summary>
        /// Representa um produto no sistema.
        /// Cada instância contém informações como código, nome, marca, quantidade, tags e medida.
        /// </summary>
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public int? Amount { get; set; }
        public string? TagsId { get; set; }
        public string? Measure { get; set; }
        public Product(int code, string name, string brand, int amount, string tagsId, string measure)
        {
            this.Code = code;
            this.Name = name;
            this.Brand = brand;
            this.Amount = amount;
            this.TagsId = tagsId;
            this.Measure = measure;
        }
        public Product()
        {
            
        }
    }
}
