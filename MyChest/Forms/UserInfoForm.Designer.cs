namespace MyChest.Forms
{
    partial class UserInfoForm
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

        private bool UserModified()
        {
            if (_originalLogin != txtBoxUserLogin.Text || _originalPassword != txtBoxUserPassword.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            lbUserLogin = new Label();
            lbUserPassword = new Label();
            btnDeleteUser = new Button();
            btnConfirm = new Button();
            txtBoxUserLogin = new TextBox();
            txtBoxUserPassword = new TextBox();
            SuspendLayout();
            // 
            // lbUserLogin
            // 
            lbUserLogin.AutoSize = true;
            lbUserLogin.BorderStyle = BorderStyle.FixedSingle;
            lbUserLogin.Location = new Point(12, 9);
            lbUserLogin.Name = "lbUserLogin";
            lbUserLogin.Size = new Size(39, 17);
            lbUserLogin.TabIndex = 5;
            lbUserLogin.Text = "Login";
            // 
            // lbUserPassword
            // 
            lbUserPassword.AutoSize = true;
            lbUserPassword.BorderStyle = BorderStyle.FixedSingle;
            lbUserPassword.Location = new Point(12, 43);
            lbUserPassword.Name = "lbUserPassword";
            lbUserPassword.Size = new Size(41, 17);
            lbUserPassword.TabIndex = 14;
            lbUserPassword.Text = "Senha";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteUser.Location = new Point(99, 127);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(75, 23);
            btnDeleteUser.TabIndex = 18;
            btnDeleteUser.Text = "Deletar";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirm.Location = new Point(180, 127);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 19;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtBoxUserLogin
            // 
            txtBoxUserLogin.Location = new Point(59, 6);
            txtBoxUserLogin.Name = "txtBoxUserLogin";
            txtBoxUserLogin.Size = new Size(100, 23);
            txtBoxUserLogin.TabIndex = 20;
            txtBoxUserLogin.Text = "\"Login do User\"";
            // 
            // txtBoxUserPassword
            // 
            txtBoxUserPassword.Location = new Point(59, 40);
            txtBoxUserPassword.Name = "txtBoxUserPassword";
            txtBoxUserPassword.Size = new Size(100, 23);
            txtBoxUserPassword.TabIndex = 21;
            txtBoxUserPassword.Text = "\"Login do User\"";
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 162);
            Controls.Add(txtBoxUserPassword);
            Controls.Add(txtBoxUserLogin);
            Controls.Add(btnConfirm);
            Controls.Add(btnDeleteUser);
            Controls.Add(lbUserPassword);
            Controls.Add(lbUserLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserInfoForm";
            Text = "Nome do usuário";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUserLogin;
        private Label lbUserPassword;
        private Button btnDeleteUser;
        private Button btnConfirm;
        private TextBox txtBoxUserLogin;
        private TextBox txtBoxUserPassword;
    }
}