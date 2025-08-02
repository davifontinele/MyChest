using MyChest.Models;

namespace MyChest.Forms
{
    public partial class UserInfoForm : Form
    {
        private UserLoged? _userLoged;
        public UserInfoForm(UserLoged userLoged)
        {
            InitializeComponent();
            _userLoged = userLoged;
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
            lbUserName.Text = _userLoged.Name;
            lbPassword.Text = _userLoged.Password;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você tem certeza que deseja deslogar?", "Confirmação de Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                return;
            }
            else
            {
                return;
            }
        }        
    }
}
