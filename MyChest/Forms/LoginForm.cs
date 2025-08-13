namespace MyChest.Forms
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Além de representar um formulário de login, essa classe é responsável por verificar as credenciais do usuário.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            ValidadeLogin();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Isso garante que o programa seja fechado de qualquer maneira quando o formulário for fechado.
            // Fiz isso pois não consegui fazer com que o programa se encerre quando uma nova formLogin instanciada
            // em UserInfoForm.cs/btnLogoff_Click é fechada, antes o programa continuava rodando em segundo plano porque
            // a form principal instanciada em Program.cs não era fechada.
            Application.Exit();
        }
    }
}
