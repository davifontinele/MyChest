using MyChest.Forms;

namespace MyChest
{
    public partial class Home : Form
    {
        private int count = 0;
        public Home()
        {
            InitializeComponent();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            count++;
            listBoxWarning.Items.Add($"Bot�o Produtos clicado {count} vezes");
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
            listBoxWarning.Items.Add("Abre uma janela simples onde mostrar� as informa��es do usu�rio logado");
            UserInfo userInfoForm = new UserInfo();
            userInfoForm.ShowDialog();
        }

        // Evento chamado quando o usu�rio clica na tecla "Delete" na lista de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada � a tecla Delete
            if (e.KeyCode == Keys.Delete)
            {
                //Verifica se hitens selecionados na lista de avisos
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    //Criando um 
                    DialogResult result = MessageBox.Show("Voc� tem certeza que deseja excluir os itens selecionados?", "Confirma��o de Exclus�o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
    }
}
