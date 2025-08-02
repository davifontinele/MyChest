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
            pictureBox1 = new PictureBox();
            lbUserName = new Label();
            btnLogoff = new Button();
            button1 = new Button();
            lbPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.Font = new Font("Segoe UI", 9.75F);
            lbUserName.Location = new Point(66, 9);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(70, 17);
            lbUserName.TabIndex = 1;
            lbUserName.Text = "UserName";
            // 
            // btnLogoff
            // 
            btnLogoff.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogoff.Location = new Point(196, 166);
            btnLogoff.Name = "btnLogoff";
            btnLogoff.Size = new Size(75, 23);
            btnLogoff.TabIndex = 3;
            btnLogoff.Text = "Deslogar";
            btnLogoff.UseVisualStyleBackColor = true;
            btnLogoff.Click += btnLogoff_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 166);
            button1.Name = "button1";
            button1.Size = new Size(92, 23);
            button1.TabIndex = 4;
            button1.Text = "Mudar Senha";
            button1.UseVisualStyleBackColor = true;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 9.75F);
            lbPassword.Location = new Point(66, 26);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(91, 17);
            lbPassword.TabIndex = 5;
            lbPassword.Text = "UserPassword";
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 201);
            Controls.Add(lbPassword);
            Controls.Add(button1);
            Controls.Add(btnLogoff);
            Controls.Add(lbUserName);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserInfoForm";
            Text = "UserInfo";
            Load += UserInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbUserName;
        private Button btnLogoff;
        private Button button1;
        private Label lbPassword;
    }
}