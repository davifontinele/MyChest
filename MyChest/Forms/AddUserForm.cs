namespace MyChest.Forms
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            LoadUserPermissions();
        }

        private void btnCodastrateNewUser_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
    }
}
