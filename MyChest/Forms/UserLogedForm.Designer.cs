namespace MyChest.Forms
{
    partial class UserLogedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogedForm));
            pictureBox1 = new PictureBox();
            lbUserName = new Label();
            btnLogoff = new Button();
            lbPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbUserName
            // 
            lbUserName.AutoSize = true;
            lbUserName.BorderStyle = BorderStyle.Fixed3D;
            lbUserName.Font = new Font("Segoe UI", 9.75F);
            lbUserName.Location = new Point(70, 12);
            lbUserName.Name = "lbUserName";
            lbUserName.Size = new Size(72, 19);
            lbUserName.TabIndex = 1;
            lbUserName.Text = "UserName";
            // 
            // btnLogoff
            // 
            btnLogoff.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogoff.Location = new Point(12, 166);
            btnLogoff.Name = "btnLogoff";
            btnLogoff.Size = new Size(75, 23);
            btnLogoff.TabIndex = 3;
            btnLogoff.Text = "Deslogar";
            btnLogoff.UseVisualStyleBackColor = true;
            btnLogoff.Click += btnLogoff_Click;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BorderStyle = BorderStyle.Fixed3D;
            lbPassword.Font = new Font("Segoe UI", 9.75F);
            lbPassword.Location = new Point(70, 31);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(93, 19);
            lbPassword.TabIndex = 5;
            lbPassword.Text = "UserPassword";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 201);
            Controls.Add(lbPassword);
            Controls.Add(btnLogoff);
            Controls.Add(lbUserName);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserForm";
            Text = "Usuário";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbUserName;
        private Button btnLogoff;
        private Label lbPassword;
    }
}