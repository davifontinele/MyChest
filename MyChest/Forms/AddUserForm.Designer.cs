using Microsoft.VisualBasic.ApplicationServices;
using MyChest.Data.DAO;
using MyChest.Extensions;
using MyChest.Models;

namespace MyChest.Forms
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadUserPermissions()
        {
            UserDAO userDAO = new UserDAO();
            var permissions = userDAO.GetAllPermissions();

            checkBoxPemissions.Items.Clear();
            foreach (var permission in permissions)
            {
                checkBoxPemissions.Items.Add(permission.Value);
            }
        }

        private void AddNewUser()
        {
            Models.User user = new Models.User(txtBoxName.Text, txtBoxPassword.Text);
            Dictionary<int, Permissions> permissions = new Dictionary<int, Permissions>();

            UserDAO userDAO = new UserDAO();
            foreach (var item in checkBoxPemissions.CheckedItems)
            {
                if (Enum.TryParse<Permissions>(item.ToString(), ignoreCase: true, out var permission))
                {
                    permissions.Add(userDAO.GetPermissionId(permission.ToString()),permission);
                }
            }
            
            userDAO.InsertUser(user);
            List<int> permissionsId = new List<int>(permissions.Keys);
            userDAO.InsertUserPermissions(userDAO.GetUserId(user.Name), permissionsId);

            ClearFields();
        }

        private void ClearFields()
        {
            txtBoxName.Clear();
            txtBoxPassword.Clear();
            checkBoxPemissions.ClearSelected();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            txtBoxName = new TextBox();
            lbName = new Label();
            btnCodastrateNewUser = new Button();
            txtBoxPassword = new TextBox();
            lbPassword = new Label();
            lbProduct = new Label();
            checkBoxPemissions = new CheckedListBox();
            SuspendLayout();
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(12, 29);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(109, 23);
            txtBoxName.TabIndex = 20;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.BorderStyle = BorderStyle.FixedSingle;
            lbName.Location = new Point(45, 9);
            lbName.Name = "lbName";
            lbName.Size = new Size(42, 17);
            lbName.TabIndex = 19;
            lbName.Text = "Nome";
            // 
            // btnCodastrateNewUser
            // 
            btnCodastrateNewUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCodastrateNewUser.Location = new Point(12, 121);
            btnCodastrateNewUser.Name = "btnCodastrateNewUser";
            btnCodastrateNewUser.Size = new Size(75, 23);
            btnCodastrateNewUser.TabIndex = 21;
            btnCodastrateNewUser.Text = "Cadastrar";
            btnCodastrateNewUser.UseVisualStyleBackColor = true;
            btnCodastrateNewUser.Click += btnCodastrateNewUser_Click;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Location = new Point(127, 29);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.Size = new Size(109, 23);
            txtBoxPassword.TabIndex = 23;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BorderStyle = BorderStyle.FixedSingle;
            lbPassword.Location = new Point(161, 9);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(41, 17);
            lbPassword.TabIndex = 22;
            lbPassword.Text = "Senha";
            // 
            // lbProduct
            // 
            lbProduct.AutoSize = true;
            lbProduct.BorderStyle = BorderStyle.FixedSingle;
            lbProduct.Location = new Point(305, 9);
            lbProduct.Name = "lbProduct";
            lbProduct.Size = new Size(68, 17);
            lbProduct.TabIndex = 27;
            lbProduct.Text = "Permissões";
            // 
            // checkBoxPemissions
            // 
            checkBoxPemissions.FormattingEnabled = true;
            checkBoxPemissions.Location = new Point(242, 29);
            checkBoxPemissions.Name = "checkBoxPemissions";
            checkBoxPemissions.Size = new Size(194, 112);
            checkBoxPemissions.TabIndex = 28;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(449, 156);
            Controls.Add(checkBoxPemissions);
            Controls.Add(lbProduct);
            Controls.Add(txtBoxPassword);
            Controls.Add(lbPassword);
            Controls.Add(btnCodastrateNewUser);
            Controls.Add(txtBoxName);
            Controls.Add(lbName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddUserForm";
            Text = "Cadastrar Usuário";
            Load += AddUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxName;
        private Label lbName;
        private Button btnCodastrateNewUser;
        private TextBox txtBoxPassword;
        private Label lbPassword;
        private Label lbProduct;
        private CheckedListBox checkBoxPemissions;
    }
}