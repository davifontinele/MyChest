using MyChest.Forms;
using MyChest.Models;

namespace MyChest
{
    public partial class HomeForm : Form
    {
        protected User? _userLoged;
        public HomeForm(User userLoged)
        {
            InitializeComponent();
            _userLoged = userLoged;
            ValidadeRole();

            btnUserInfo.Text = _userLoged.Name;
        }
        public HomeForm()
        {
            InitializeComponent();
        }
        private void btnProd_Click(object sender, EventArgs e)
        {
            DataGridProductLoad();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(_userLoged!, this);
            userForm.ShowDialog();
        }

        // OBS: Precisamos fazer um sistema de verificação dos dados no DB para implementarem com essa funcionalidade de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Você tem certeza que deseja excluir os itens selecionados?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        for (int a = listBoxWarning.SelectedIndices.Count - 1; a >= 0; a--)
                        {
                            listBoxWarning.Items.RemoveAt(listBoxWarning.SelectedIndices[a]);
                        }
                    }
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DataGridProductLoad();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            DataGridUserLoad();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            DataGridAddressLoad();
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnMoveProduct_Click(object sender, EventArgs e)
        {
            MoveProdForm moveProdForm = new MoveProdForm();
            moveProdForm.ShowDialog();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.SelectedRows.Count == 1 && dataGrid.Columns.Count == 6)
            {
                Product selectedProd = new Product(
                    // Code
                    Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value),

                    // Nome
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[1].Value)!,

                    // Marca
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[2].Value)!,

                    // Quantidade
                    Convert.ToInt32(dataGrid.SelectedRows[0].Cells[3].Value),

                    // Tags
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[4].Value)!,

                    // Medida
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[5].Value)!,

                    // Validade
                    DateOnly.FromDateTime(Convert.ToDateTime(dataGrid.SelectedRows[0].Cells[6].Value)).ToString()
                    );

                ProductInfoForm newForm = new ProductInfoForm(selectedProd);
                newForm.Show();

                newForm.Owner = this;
            }
        }

        private void btnReceiptProduct_Click(object sender, EventArgs e)
        {
            ReceiptProductForm newForm = new ReceiptProductForm();
            newForm.Show();

            newForm.Owner = this;
        }
    }
}
