using MyChest.Models;

namespace MyChest.Forms
{
    public partial class UserForm : Form
    {
        private User? _userLoged;
        public Form _formHome;
        public UserForm(User userLoged, Form homeForm)
        {
            InitializeComponent();
            _formHome = homeForm;
            _userLoged = userLoged;

            // Verificação usada em testes, remover depois
            if (_userLoged == null)
            {
                Text = "nome do usuário";
                lbUserName.Text = "nome do usuário";
                lbPassword.Text = "senha do usuário";
            }
            else
            {
                // Manter somente esse bloco
                Text = _userLoged.Name;
                lbUserName.Text = _userLoged.Name;
                lbPassword.Text = _userLoged.Password;
            }
        }
        private void btnLogoff_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo de confirmação para o logoff, result é um objeto DialogResult que indica a escolha do usuário
            DialogResult result = MessageBox.Show("Você tem certeza que deseja deslogar?", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _userLoged = null;
                Close();
                _formHome.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
