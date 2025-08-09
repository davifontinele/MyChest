using MyChest.Extensions;

namespace MyChest.Forms
{
    public partial class MoveProdForm : Form
    {
        public MoveProdForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o campo de texto não está vazio e se é possível converter o texto para um número inteiro
            if (!string.IsNullOrWhiteSpace(txtBoxProd.Text) && int.TryParse(txtBoxProd.Text, out int code))
            {
                UpdateLeftProductInfo(txtBoxProd.Text.ConvertToInt32());
            }
        }
        private void txtBoxProd2_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o campo de texto não está vazio e se é possível converter o texto para um número inteiro
            if (!string.IsNullOrWhiteSpace(txtBoxProd2.Text) && int.TryParse(txtBoxProd2.Text, out int code))
            {
                UpdateRightProductInfo(txtBoxProd2.Text.ConvertToInt32());
            }
        }

        private void MoveProdForm_Load(object sender, EventArgs e)
        {
            Size = new Size(550, 270);
            ShowAddressMoveComponents();
            HideAddressMoveComponents();
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
                if (txtBoxProd2.Enabled == false)
                {
                    MoveProd(txtBoxProd.Text.ConvertToInt32());
                }
            }
        }
    }
}
