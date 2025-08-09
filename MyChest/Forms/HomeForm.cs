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
            ValidadeRole();
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
            // Cria uma nova inst�ncia do formul�rio UserInfoForm, passando o usu�rio logado e o formul�rio atual como par�metros
            UserInfoForm userInfoForm = new UserInfoForm(_userLoged!, this);
            userInfoForm.ShowDialog();
        }

        // Evento chamado quando o usu�rio clica em alguma tecla na lista de avisos
        private void listBoxWarning_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada � a tecla "Delete"
            if (e.KeyCode == Keys.Delete)
            {
                //Verifica se h� itens selecionados na lista de avisos
                if (listBoxWarning.SelectedItems.Count > 0)
                {
                    // Exibe uma caixa de di�logo de confirma��o
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

        private void btnMoveProd_Click(object sender, EventArgs e)
        {
            MoveProdForm moveProdForm = new MoveProdForm();
            moveProdForm.ShowDialog();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Adiciona os valores da linha do DataGridView selecionado ao objeto Address
            //address.Corridor = dataGrid.SelectedRows[0].Cells[0].Value.ToString().ConvertToInt32();
            //address.Column = dataGrid.SelectedRows[0].Cells[1].Value.ToString().ConvertToInt32();
            //address.Level = dataGrid.SelectedRows[0].Cells[2].Value.ToString().ConvertToInt32();
            //address.Hall = dataGrid.SelectedRows[0].Cells[3].Value.ToString().ConvertToInt32();
            if (dataGrid.SelectedRows.Count == 1)
            {

            }
        }
    }
}
