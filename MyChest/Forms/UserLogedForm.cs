using MyChest.Models;

namespace MyChest.Forms
{
    public partial class UserLogedForm : Form
    {
        private User? _userLoged;
        private Form _formHome;
        private LoginForm loginForm;
        public UserLogedForm(User userLoged, Form homeForm, LoginForm loginForm)
        {
            InitializeComponent();
            _formHome = homeForm;
            _userLoged = userLoged;
            this.loginForm = loginForm;

            if (_userLoged == null)
            {
                Text = "nome do usuário";
                lbUserName.Text = "nome do usuário";
                lbPassword.Text = "senha do usuário";
            }
            else
            {
                Text = _userLoged.Name;
                lbUserName.Text = _userLoged.Name;
                lbPassword.Text = _userLoged.Password;
            }
        }
        private void btnLogoff_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você tem certeza que deseja deslogar?", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _userLoged = null;
                Close();
                _formHome.Hide();
                loginForm.Show();
            }
        }
    }
}
