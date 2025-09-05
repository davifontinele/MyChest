using MyChest.Extensions;

namespace MyChest.Forms
{
    public partial class AddAddressForm : Form
    {
        public AddAddressForm()
        {
            InitializeComponent();
        }

        private void AddAddressForm_Load(object sender, EventArgs e)
        {
            LoadProductsInComboBoxProducts();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            AddNewAddress();
        }

        private void txtBoxCorridor_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCorridor.Text.TestConvertToInt32())
            {
                txtBoxCorridor.BackColor = Color.Green;
            }
            else
            {
                txtBoxCorridor.BackColor = Color.IndianRed;
            }
        }

        private void txtBoxColumn_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxColumn.Text.TestConvertToInt32())
            {
                txtBoxColumn.BackColor = Color.Green;
            }
            else
            {
                txtBoxColumn.BackColor = Color.IndianRed;
            }
        }

        private void txtBoxLevel_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxLevel.Text.TestConvertToInt32())
            {
                txtBoxLevel.BackColor = Color.Green;
            }
            else
            {
                txtBoxLevel.BackColor = Color.IndianRed;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxHall.Text.TestConvertToInt32())
            {
                txtBoxHall.BackColor = Color.Green;
            }
            else
            {
                txtBoxHall.BackColor = Color.IndianRed;
            }
        }
    }
}
