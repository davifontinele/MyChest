using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChest.Models
{
    internal class Product
    {
        public int code { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string tagsId { get; set; }
        public string measure { get; set; }
        public Product(int code, string name, string brand, string description, int amount, string tagsId, string measure)
        {
            this.code = code;
            this.name = name;
            this.brand = brand;
            this.description = description;
            this.amount = amount;
            this.tagsId = tagsId;
            this.measure = measure;
        }
    }
}
