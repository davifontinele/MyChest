namespace MyChest.Models
{
    /// <summary>
    /// Representa um endereço no sistema.
    /// Cada endereço é composto por um corredor, coluna, nível, hall e código do produto.
    /// </summary>
    internal class Address
    {
        public int Id { get; set; }
        public int Corridor { get; set; }
        public int Column { get; set; }
        public int Level { get; set; }
        public int Hall { get; set; }
        public int? ProductCode { get; set; }
        public Address(int corridor, int column, int level, int hall, int? productCode)
        {
            Corridor = corridor;
            Column = column;
            Level = level;
            Hall = hall;
            ProductCode = productCode;
        }
        public Address()
        {
            
        }
    }
}
