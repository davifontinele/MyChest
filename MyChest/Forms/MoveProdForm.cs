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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o campo de texto não está vazio e se é possível converter o texto para um número inteiro
            if (int.TryParse(txtBoxProd.Text, out int code) && !string.IsNullOrWhiteSpace(txtBoxProd.Text))
            {
                txtBoxProd.BackColor = Color.White;

                //Atualiza as informações do produto com base no código fornecido
                UpdateLeftProductInfo(txtBoxProd.Text.ConvertToInt32());

                List<Label> labels = new List<Label>
                {
                    lbInfoProdCode,
                    lbProdAmount,
                    lbProdBrand,
                    lbProdCode,
                    lbProdMeasure
                };

                if (!TestLabelsContainsValidValues(labels))
                {
                    txtBoxProd.BackColor = Color.IndianRed;
                }
                else
                {
                    txtBoxProd.BackColor = Color.LightGreen;
                }
            }
            else
            {
                txtBoxProd.BackColor = Color.IndianRed;
            }
        }
        private void txtBoxProd2_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o campo de texto não está vazio e se é possível converter o texto para um número inteiro
            if (!string.IsNullOrWhiteSpace(txtBoxProd2.Text) && int.TryParse(txtBoxProd2.Text, out int code))
            {
                txtBoxProd2.BackColor = Color.White;

                // Atualiza as informações do produto com base no código fornecido
                UpdateRightProductInfo(txtBoxProd2.Text.ConvertToInt32());

                List<Label> labels = new List<Label>
                {
                    lbInfoProdCode2,
                    lbProdAmount2,
                    lbProdBrand2,
                    lbProdCode2,
                    lbProdMeasure2
                };

                if (!TestLabelsContainsValidValues(labels))
                {
                    txtBoxProd2.BackColor = Color.IndianRed;
                }

                if (!TestLabelsContainsValidValues(labels))
                {
                    txtBoxProd2.BackColor = Color.IndianRed;
                }
                else
                {
                    txtBoxProd2.BackColor = Color.LightGreen;
                }
            }
            else
            {
                txtBoxProd2.BackColor = Color.IndianRed;
            }
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
            // Verifica se o campo de texto mascarado está completamente preenchido
            if (maskTxtBoxSearchAddress.MaskCompleted)
            {
                GetAddressByNumber();
            }
            // Se o campo de texto estiver vazio ou contiver apenas espaços em branco (após remover os hífens), recarrega os dados do DataGrid
            else if (string.IsNullOrWhiteSpace(maskTxtBoxSearchAddress.Text.Replace("-", "")))
            {
                DataGridAddressLoad();
            }
        }

        private void btnMoveConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja executar esse operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            // Verifica se o usuário confirmou a operação
            if (result == DialogResult.Yes)
            {
                // Verifica se o campo de texto txtBoxProd2 está habilitado
                // Caso esteja o sistema entende que e uma movimentação entre produtos
                if (txtBoxProd2.Enabled == true)
                {
                    MoveProd(txtBoxProd.Text.ConvertToInt32(), txtBoxProd2.Text.ConvertToInt32());
                }

                // Caso contrário o sistema entende que e uma movimentação por endereço
                if (txtBoxProd2.Enabled == false && dataGrid.Enabled == true)
                {
                    MoveProd(txtBoxProd.Text.ConvertToInt32());
                }
            }
        }
    }
}
