using MyChest.Models;

namespace MyChest.Forms
{
    public partial class UserInfoForm : Form
    {
        private User? _userLoged;
        public Form? _formHome;
        public UserInfoForm(User userLoged, Form homeForm)
        {
            InitializeComponent();
            _userLoged = userLoged;
            _formHome = homeForm;
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
            lbUserName.Text = _userLoged.Name;
            lbPassword.Text = _userLoged.Password;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo de confirmação para o logoff, result é um objeto DialogResult que indica a escolha do usuário
            DialogResult result = MessageBox.Show("Você tem certeza que deseja deslogar?", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _userLoged = null;
                this.Close();
                _formHome.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                return;
            }
        }
    }
}
