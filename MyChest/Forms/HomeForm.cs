using MyChest.Forms;
using MyChest.Models;

namespace MyChest
{
    public partial class HomeForm : Form
    {
        private User? _userLoged;
        public HomeForm(User userLoged)
        {
            InitializeComponent();
            _userLoged = userLoged;
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            DataGridProductLoad();
        }

        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            txtBoxSearch.Text = string.Empty;
        }

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "Pesquisar";
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário UserInfoForm, passando o usuário logado e o formulário atual como parâmetros
            UserInfoForm userInfoForm = new UserInfoForm(_userLoged, this);
            userInfoForm.ShowDialog();
        }

        // Evento chamado quando o usuário clica em alguma tecla na lista de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é a tecla "Delete"
            if (e.KeyCode == Keys.Delete)
            {
                //Verifica se há itens selecionados na lista de avisos
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    // Exibe uma caixa de diálogo de confirmação
                    DialogResult result = MessageBox.Show("Você tem certeza que deseja excluir os itens selecionados?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Remove os itens selecionados da lista de avisos
                        for (int a = listBoxWarning.SelectedIndices.Count - 1; a >= 0; a--)
                        {
                            listBoxWarning.Items.RemoveAt(listBoxWarning.SelectedIndices[a]);
                        }
                    }
                    else
                    {
                        return;
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
    }
}
