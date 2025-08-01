namespace MyChest.Forms
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }


        private void btnLogoff_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo de confirmação antes de deslogar
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

        private void UserInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
