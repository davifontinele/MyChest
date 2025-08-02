using MyChest.Data.DAO;

namespace MyChest.Forms
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Além de representar um formulário de login, esta classe é responsável por verificar as credenciais do usuário.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            VerifyLogin();
        }
    }
}
