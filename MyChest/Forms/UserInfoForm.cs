using MyChest.Data.DAO;
using MyChest.Models;

namespace MyChest.Forms
{
    public partial class UserInfoForm : Form
    {
        private User _selectedUser;
        private string _originalLogin;
        private string _originalPassword;
        public UserInfoForm(User selectedUser)
        {
            InitializeComponent();

            this._selectedUser = selectedUser;

            txtBoxUserLogin.Text = _selectedUser.Name;
            txtBoxUserPassword.Text = _selectedUser.Password;

            _originalLogin = _selectedUser.Name!;
            _originalPassword = _selectedUser.Password!;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (UserModified())
            {
                DialogResult result = MessageBox.Show("Os dados do usuário foi modificado, deseja salvar as alterações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UserDAO userDAO = new UserDAO();
                    userDAO.UpdateUser(userDAO.GetUserId(_originalLogin), txtBoxUserLogin.Text, txtBoxUserPassword.Text);

                    MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            this.Close();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este usuário? Todos os dados relacionados a ele serão perdidos.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                UserDAO userDAO = new UserDAO();
                userDAO.DeleteUser(userDAO.GetUserId(_originalLogin));

                MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
