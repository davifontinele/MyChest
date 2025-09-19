using MyChest.Models;

namespace MyChest.Forms
{
    public partial class ProductInfoForm : Form
    {
        private Product _selectedProduct { get; set; }
        public ProductInfoForm(Product _selectedProduct)
        {
            InitializeComponent();
            this._selectedProduct = _selectedProduct;
            DataGridLoad();
            LoadLabelsText();
        }
    }
}
