using MyChest.Data.DAO;
using MyChest.Models;

namespace MyChest.Forms
{
    partial class LoginForm
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

        /// <summary>
        /// Verifica as credenciais do usuário e, se forem válidas, abre o formulário HomeForm passando o obj do usuário logado.
        /// </summary>
        private void ValidadeLogin()
        {
            UserDAO userDAO = new UserDAO();

            if (userDAO.VerifyLogin(txtBoxUser.Text, txtBoxPassword.Text))
            {
                var userPermissionsList = userDAO.GetUserPermissionsByUserName(txtBoxUser.Text);
                User userLoged = new User(txtBoxUser.Text, txtBoxPassword.Text, userPermissionsList);

                HomeForm newForm = new HomeForm(userLoged);
                this.Hide();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos","Erro de login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtBoxUser.Text = string.Empty;
                txtBoxPassword.Text = string.Empty;
                txtBoxUser.Focus();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lbTitle = new Label();
            txtBoxUser = new TextBox();
            txtBoxPassword = new TextBox();
            lbUser = new Label();
            lbPassword = new Label();
            picBoxLogo = new PictureBox();
            BtnLogar = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(193, 160);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(70, 20);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "MyChest";
            // 
            // txtBoxUser
            // 
            txtBoxUser.Location = new Point(163, 211);
            txtBoxUser.Name = "txtBoxUser";
            txtBoxUser.Size = new Size(128, 23);
            txtBoxUser.TabIndex = 2;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Location = new Point(163, 262);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PasswordChar = '*';
            txtBoxPassword.Size = new Size(128, 23);
            txtBoxPassword.TabIndex = 3;
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.BorderStyle = BorderStyle.FixedSingle;
            lbUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUser.Location = new Point(163, 187);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(61, 22);
            lbUser.TabIndex = 4;
            lbUser.Text = "Usuário";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BorderStyle = BorderStyle.FixedSingle;
            lbPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(163, 238);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(51, 22);
            lbPassword.TabIndex = 5;
            lbPassword.Text = "Senha";
            // 
            // picBoxLogo
            // 
            picBoxLogo.Image = (Image)resources.GetObject("picBoxLogo.Image");
            picBoxLogo.Location = new Point(163, 25);
            picBoxLogo.Name = "picBoxLogo";
            picBoxLogo.Size = new Size(128, 128);
            picBoxLogo.SizeMode = PictureBoxSizeMode.AutoSize;
            picBoxLogo.TabIndex = 0;
            picBoxLogo.TabStop = false;
            // 
            // BtnLogar
            // 
            BtnLogar.Location = new Point(188, 307);
            BtnLogar.Name = "BtnLogar";
            BtnLogar.Size = new Size(75, 23);
            BtnLogar.TabIndex = 6;
            BtnLogar.Text = "Entrar";
            BtnLogar.UseVisualStyleBackColor = true;
            BtnLogar.Click += BtnLogar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(484, 361);
            Controls.Add(BtnLogar);
            Controls.Add(lbPassword);
            Controls.Add(lbUser);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUser);
            Controls.Add(lbTitle);
            Controls.Add(picBoxLogo);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyChest";
            FormClosed += LoginForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)picBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbTitle;
        private TextBox txtBoxUser;
        private TextBox txtBoxPassword;
        private Label lbUser;
        private Label lbPassword;
        private PictureBox picBoxLogo;
        private Button BtnLogar;
    }
}