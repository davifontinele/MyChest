namespace MyChest
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            toolStripBtns = new ToolStrip();
            lbLogoTeste = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            btnProd = new ToolStripButton();
            btnUser = new ToolStripButton();
            btnAddress = new ToolStripButton();
            btnConfig = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnUserInfo = new ToolStripButton();
            colorDialog1 = new ColorDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            listBoxWarning = new ListBox();
            dataGridView1 = new DataGridView();
            txtBoxSearch = new TextBox();
            panel1 = new Panel();
            picBoxSearcIcon = new PictureBox();
            toolStripOptions = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxSearcIcon).BeginInit();
            toolStripOptions.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripBtns
            // 
            toolStripBtns.AllowItemReorder = true;
            toolStripBtns.AutoSize = false;
            toolStripBtns.BackColor = Color.LightSteelBlue;
            toolStripBtns.CanOverflow = false;
            toolStripBtns.Dock = DockStyle.Left;
            toolStripBtns.GripStyle = ToolStripGripStyle.Hidden;
            toolStripBtns.Items.AddRange(new ToolStripItem[] { lbLogoTeste, toolStripSeparator1, btnProd, btnUser, btnAddress, toolStripButton4, btnConfig, toolStripSeparator2, btnUserInfo });
            toolStripBtns.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStripBtns.Location = new Point(0, 0);
            toolStripBtns.Name = "toolStripBtns";
            toolStripBtns.Size = new Size(150, 681);
            toolStripBtns.TabIndex = 0;
            toolStripBtns.Text = "toolStrip1";
            // 
            // lbLogoTeste
            // 
            lbLogoTeste.Image = (Image)resources.GetObject("lbLogoTeste.Image");
            lbLogoTeste.ImageScaling = ToolStripItemImageScaling.None;
            lbLogoTeste.Name = "lbLogoTeste";
            lbLogoTeste.Size = new Size(148, 47);
            lbLogoTeste.Text = "MyChest";
            lbLogoTeste.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(148, 6);
            // 
            // btnProd
            // 
            btnProd.AccessibleDescription = "treste";
            btnProd.AccessibleName = "";
            btnProd.Image = (Image)resources.GetObject("btnProd.Image");
            btnProd.ImageScaling = ToolStripItemImageScaling.None;
            btnProd.ImageTransparentColor = Color.Magenta;
            btnProd.Name = "btnProd";
            btnProd.Size = new Size(148, 36);
            btnProd.Text = "Produtos";
            btnProd.Click += btnProd_Click;
            // 
            // btnUser
            // 
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.ImageScaling = ToolStripItemImageScaling.None;
            btnUser.ImageTransparentColor = Color.Magenta;
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(148, 36);
            btnUser.Text = "Usuários";
            // 
            // btnAddress
            // 
            btnAddress.Image = (Image)resources.GetObject("btnAddress.Image");
            btnAddress.ImageScaling = ToolStripItemImageScaling.None;
            btnAddress.ImageTransparentColor = Color.Magenta;
            btnAddress.Name = "btnAddress";
            btnAddress.Size = new Size(148, 36);
            btnAddress.Text = "Endereços";
            // 
            // btnConfig
            // 
            btnConfig.Image = (Image)resources.GetObject("btnConfig.Image");
            btnConfig.ImageScaling = ToolStripItemImageScaling.None;
            btnConfig.ImageTransparentColor = Color.Magenta;
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(148, 36);
            btnConfig.Text = "Configurações";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(148, 6);
            // 
            // btnUserInfo
            // 
            btnUserInfo.Image = (Image)resources.GetObject("btnUserInfo.Image");
            btnUserInfo.ImageScaling = ToolStripItemImageScaling.None;
            btnUserInfo.ImageTransparentColor = Color.Magenta;
            btnUserInfo.Name = "btnUserInfo";
            btnUserInfo.Size = new Size(148, 51);
            btnUserInfo.Text = "User";
            btnUserInfo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnUserInfo.Click += btnUserInfo_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // listBoxWarning
            // 
            listBoxWarning.AccessibleDescription = "";
            listBoxWarning.AccessibleName = "";
            listBoxWarning.Dock = DockStyle.Bottom;
            listBoxWarning.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxWarning.FormattingEnabled = true;
            listBoxWarning.ItemHeight = 20;
            listBoxWarning.Location = new Point(150, 477);
            listBoxWarning.Name = "listBoxWarning";
            listBoxWarning.SelectionMode = SelectionMode.MultiExtended;
            listBoxWarning.Size = new Size(1114, 204);
            listBoxWarning.TabIndex = 1;
            listBoxWarning.KeyDown += listBoxWarning_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(150, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1114, 477);
            dataGridView1.TabIndex = 2;
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.AcceptsTab = true;
            txtBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxSearch.BackColor = SystemColors.Info;
            txtBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            txtBoxSearch.Cursor = Cursors.IBeam;
            txtBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxSearch.ForeColor = SystemColors.ButtonShadow;
            txtBoxSearch.Location = new Point(27, 0);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(1089, 25);
            txtBoxSearch.TabIndex = 3;
            txtBoxSearch.Text = "Pesquisar";
            txtBoxSearch.Enter += txtBoxSearch_Enter;
            txtBoxSearch.Leave += txtBoxSearch_Leave;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(picBoxSearcIcon);
            panel1.Controls.Add(txtBoxSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(150, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 28);
            panel1.TabIndex = 4;
            // 
            // picBoxSearcIcon
            // 
            picBoxSearcIcon.Image = (Image)resources.GetObject("picBoxSearcIcon.Image");
            picBoxSearcIcon.Location = new Point(0, 0);
            picBoxSearcIcon.Name = "picBoxSearcIcon";
            picBoxSearcIcon.Size = new Size(27, 25);
            picBoxSearcIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxSearcIcon.TabIndex = 0;
            picBoxSearcIcon.TabStop = false;
            // 
            // toolStripOptions
            // 
            toolStripOptions.Dock = DockStyle.Right;
            toolStripOptions.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStripOptions.Location = new Point(1201, 28);
            toolStripOptions.Name = "toolStripOptions";
            toolStripOptions.Size = new Size(63, 449);
            toolStripOptions.TabIndex = 5;
            toolStripOptions.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(112, 20);
            toolStripButton1.Text = "Editar";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(60, 20);
            toolStripButton2.Text = "Excluir";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(60, 20);
            toolStripButton3.Text = "Saída";
            // 
            // toolStripButton4
            // 
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(148, 20);
            toolStripButton4.Text = "Recebimento";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1264, 681);
            Controls.Add(toolStripOptions);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(listBoxWarning);
            Controls.Add(toolStripBtns);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyChest";
            WindowState = FormWindowState.Maximized;
            toolStripBtns.ResumeLayout(false);
            toolStripBtns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxSearcIcon).EndInit();
            toolStripOptions.ResumeLayout(false);
            toolStripOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStripBtns;
        private ToolStripButton btnProd;
        private ToolStripLabel lbLogoTeste;
        private ToolStripButton btnUser;
        private ToolStripButton btnAddress;
        private ToolStripSeparator toolStripSeparator1;
        private ColorDialog colorDialog1;
        private ToolStripSeparator toolStripSeparator2;
        private ContextMenuStrip contextMenuStrip1;
        private ListBox listBoxWarning;
        private DataGridView dataGridView1;
        private TextBox txtBoxSearch;
        private Panel panel1;
        private PictureBox picBoxSearcIcon;
        private ToolStripButton btnUserInfo;
        private ToolStripButton btnConfig;
        private ToolStrip toolStripOptions;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton3;
    }
}
