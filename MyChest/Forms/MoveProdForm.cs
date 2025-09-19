using MyChest.Extensions;

namespace MyChest.Forms
{
    public partial class MoveProdForm : Form
    {
        public MoveProdForm()
        {
            InitializeComponent();

            Size = new Size(550, 270);
            HideAddressMoveComponents();
        }

        private void textBoxLeft_TextChanged(object sender, EventArgs e)
        {
            if (
                txtBoxLeftProduct.Text.TestConvertToInt32() && 
                !string.IsNullOrWhiteSpace(txtBoxLeftProduct.Text))
            {
                txtBoxLeftProduct.BackColor = Color.White;

                UpdateLeftProductInfo(txtBoxLeftProduct.Text.ConvertToInt32());

                List<Label> labels = new List<Label>
                {
                    lbInfoProductCode,
                    lbLeftProductAmount,
                    lbLeftProductBrand,
                    lbLeftProductCode,
                    lbLeftProductMeasure,
                    lbLeftProductValidity
                };

                if (!TestLabelsContainsValidValues(labels))
                    txtBoxLeftProduct.BackColor = Color.IndianRed;
                else
                    txtBoxLeftProduct.BackColor = Color.LightGreen;
            }
            else
                txtBoxLeftProduct.BackColor = Color.IndianRed;
        }

        private void txtBoxProdRight_TextChanged(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrWhiteSpace(txtBoxRightProduct.Text) && 
                txtBoxRightProduct.Text.TestConvertToInt32())
            {
                txtBoxRightProduct.BackColor = Color.White;

                UpdateRightProductInfo(txtBoxRightProduct.Text.ConvertToInt32());

                List<Label> labels = new List<Label>
                {
                    lbRightProductCodeInfo,
                    lbRightProductAmount,
                    lbRightProductBrand,
                    lbRightProductCode,
                    lbRightProductMeasure
                };

                if (!TestLabelsContainsValidValues(labels))
                    txtBoxRightProduct.BackColor = Color.IndianRed;

                if (!TestLabelsContainsValidValues(labels))
                    txtBoxRightProduct.BackColor = Color.IndianRed;
                else
                    txtBoxRightProduct.BackColor = Color.LightGreen;
            }
            else
                txtBoxRightProduct.BackColor = Color.IndianRed;
        }

        private void btnMovProdByProd_Click(object sender, EventArgs e)
        {
            Size = new Size(550, 270);
            HideAddressMoveComponents();
            ShowProductMoveComponents();
        }

        private void btnMovProdByAddress_Click(object sender, EventArgs e)
        {
            HideProductMoveComponents();
            Size = new Size(720, 270);
            ShowAddressMoveComponents();

            DataGridAddressStart();
        }

        private void maskTxtBoxSearchAddress_TextChanged(object sender, EventArgs e)
        {
            if (maskTxtBoxSearchAddress.MaskCompleted)
                GetAddressByNumber();

            else if (string.IsNullOrWhiteSpace(maskTxtBoxSearchAddress.Text.Replace("-", "")))
                DataGridAddressLoad();
        }

        private void btnMoveConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tem certeza que deseja executar esse operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (txtBoxRightProduct.Enabled == true)
                    MoveProd(txtBoxLeftProduct.Text.ConvertToInt32(), txtBoxRightProduct.Text.ConvertToInt32());

                if (txtBoxRightProduct.Enabled == false && dataGrid.Enabled == true)
                    MoveProd(txtBoxLeftProduct.Text.ConvertToInt32());
            }
        }
    }
}
