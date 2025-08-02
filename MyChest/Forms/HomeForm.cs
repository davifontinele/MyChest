using MyChest.Forms;
using MyChest.Models;

namespace MyChest
{
    public partial class HomeForm : Form
    {
        private UserLoged? _userLoged;
        public HomeForm(UserLoged userLoged)
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
            listBoxWarning.Items.Add("Abre uma janela simples onde mostrará as informações do usuário logado");
            UserInfoForm userInfoForm = new UserInfoForm(_userLoged);
            userInfoForm.ShowDialog();
        }

        // Evento chamado quando o usuário clica na tecla "Delete" na lista de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é a tecla Delete
            if (e.KeyCode == Keys.Delete)
            {
                //Verifica se hitens selecionados na lista de avisos
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    //Criando um 
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
    }
}
