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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            lbUserLogin = new Label();
            lbUserLoginInfo = new Label();
            lbUserPassword = new Label();
            lbUserPasswordInfo = new Label();
            btnChangePassword = new Button();
            btnChangeLogin = new Button();
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
            // lbUserLoginInfo
            // 
            lbUserLoginInfo.AutoSize = true;
            lbUserLoginInfo.BorderStyle = BorderStyle.Fixed3D;
            lbUserLoginInfo.Location = new Point(57, 9);
            lbUserLoginInfo.Name = "lbUserLoginInfo";
            lbUserLoginInfo.Size = new Size(92, 17);
            lbUserLoginInfo.TabIndex = 12;
            lbUserLoginInfo.Text = "\"Login do User\"";
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
            // lbUserPasswordInfo
            // 
            lbUserPasswordInfo.AutoSize = true;
            lbUserPasswordInfo.BorderStyle = BorderStyle.Fixed3D;
            lbUserPasswordInfo.Location = new Point(59, 43);
            lbUserPasswordInfo.Name = "lbUserPasswordInfo";
            lbUserPasswordInfo.Size = new Size(92, 17);
            lbUserPasswordInfo.TabIndex = 15;
            lbUserPasswordInfo.Text = "\"Login do User\"";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(12, 151);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(89, 23);
            btnChangePassword.TabIndex = 16;
            btnChangePassword.Text = "Mudar senha";
            btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnChangeLogin
            // 
            btnChangeLogin.Location = new Point(115, 151);
            btnChangeLogin.Name = "btnChangeLogin";
            btnChangeLogin.Size = new Size(82, 23);
            btnChangeLogin.TabIndex = 17;
            btnChangeLogin.Text = "Mudar login";
            btnChangeLogin.UseVisualStyleBackColor = true;
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 186);
            Controls.Add(btnChangeLogin);
            Controls.Add(btnChangePassword);
            Controls.Add(lbUserPasswordInfo);
            Controls.Add(lbUserPassword);
            Controls.Add(lbUserLoginInfo);
            Controls.Add(lbUserLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserInfoForm";
            Text = "Nome do usuário";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUserLogin;
        private Label lbUserLoginInfo;
        private Label lbUserPassword;
        private Label lbUserPasswordInfo;
        private Button btnChangePassword;
        private Button btnChangeLogin;
    }
}