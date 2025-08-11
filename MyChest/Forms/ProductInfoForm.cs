using MyChest.Models;

namespace MyChest.Forms
{
    public partial class ProductInfoForm : Form
    {
        private Product Product { get; set; }
        public ProductInfoForm(Product _prod)
        {
            InitializeComponent();
            Product = _prod;
            DataGridLoad();
            LoadLabelsText();
        }
    }
}
