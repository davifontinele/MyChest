using MyChest.Data.DAO;

namespace MyChest.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public string userName { get; set; }
        public string  userPassword { get; set; }
        public string userRole { get; set; }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            VerifyLogin();
        }
    }
}
