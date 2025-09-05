namespace MyChest.Forms
{
    public partial class ReceiptProductForm : Form
    {
        public ReceiptProductForm()
        {
            InitializeComponent();
        }

        private void btnConfirmReceipt_Click(object sender, EventArgs e)
        {
            ReceiptNewProduct();
        }

        private void ReceiptProductForm_Load(object sender, EventArgs e)
        {
            LoadMeasureUnits();
            LoadProductTags();
        }

        // Adicionar inserção de validade
    }
}
