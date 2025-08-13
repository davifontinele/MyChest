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

        // Evento chamado quando o usu�rio clica no bot�o do seu usu�rio
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            // Cria uma nova inst�ncia do formul�rio UserForm, passando o usu�rio logado e o formul�rio atual como par�metros
            // Passa o formulario atual como par�metro porque dentro da form UserForm existe o metodo de logoff que fecha as 
            // forms e volta para a LoginForm
            UserForm userForm = new UserForm(_userLoged!, this);
            userForm.ShowDialog();
        }

        // Evento chamado quando o usu�rio clica em alguma tecla na lista de avisos
        // OBS: Precisamos fazer um sistema de verifica��o dos dados no DB para implementarem com essa funcionalidade de avisos
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

        // OBS: Tentar diminuir esse metodo. Se precisar cria-lo em HomeForm.Designer.cs e chama-lo aqui
        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica quantas colunas existem no dataGrid no momento e se h� apenas 1 linha selecionada,
            // como � usado o mesmo dataGrid para as demais informa��es isso serve para que
            // o sistema entenda que deve executar o bloco apenas quando estiver mostrando a tabela de produtos
            if (dataGrid.SelectedRows.Count == 1 && dataGrid.Columns.Count == 6)
            {
                // Instancia um obj Product para passar como par�metro a Form ProductInfoForm
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
                    Convert.ToString(dataGrid.SelectedRows[0].Cells[5].Value)!
                    );

                // Instancia uma nova Form passando o obj criado a cima como parametro
                ProductInfoForm newForm = new ProductInfoForm(selectedProd);
                newForm.Show();

                // Isso garante a form ProdictInfoForm fique sempre embaixo da nova form que for aberta por cima
                newForm.Owner = this;
            } else if (dataGrid.SelectedRows.Count == 1 && dataGrid.Columns.Count == 3)
            {
                // TODO: fazer dos demais objetos. Address, Users, etc...
            }
        }
    }
}
