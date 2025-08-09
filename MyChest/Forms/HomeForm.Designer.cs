using MyChest.Data.DAO;
using MyChest.Models;

namespace MyChest
{
    partial class HomeForm
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

        /// <summary>
        /// Preence o DataGridView com os dados dos produtos
        /// </summary>
        private void DataGridProductLoad()
        {
            dataGrid.Columns.Clear();

            // Adiciona as colunas ao DataGridView com seu nome e texto visivel
            dataGrid.Columns.Add("codeCollum", "Código");
            dataGrid.Columns.Add("nameCollum", "Nome");
            dataGrid.Columns.Add("brandCollum", "Marca");
            dataGrid.Columns.Add("amountCollum", "Quantidade");
            dataGrid.Columns.Add("tagsCollum", "Tags");
            dataGrid.Columns.Add("measureCollum", "Medida");
            ProductDAO prod = new ProductDAO();

            // Preenche o DataGridView com os dados dos produtos retornados pela DAO
            foreach (var item in prod.GetAllData())
            {
                dataGrid.Rows.Add(item.Code, item.Name, item.Brand, item.Amount, item.TagsId, item.Measure);
            }
        }

        /// <summary>
        /// Preence o DataGridView com os dados dos usuários
        /// </summary>
        private void DataGridUserLoad()
        {
            dataGrid.Columns.Clear();

            // Adiciona as colunas ao DataGridView com seu nome e texto visivel
            dataGrid.Columns.Add("nameCollum", "Nome");
            dataGrid.Columns.Add("passwordCollum", "Senha");
            dataGrid.Columns.Add("roleCollum", "Cargo");
            UserDAO user = new UserDAO();

            // Preenche o DataGridView com os dados dos usuários retornados pela DAO
            foreach (var item in user.GetAllData())
            {
                dataGrid.Rows.Add(item.Name, item.Password, item.Role);
            }
        }

        /// <summary>
        /// Preence o DataGridView com os dados dos endereços
        /// </summary>
        private void DataGridAddressLoad()
        {
            dataGrid.Columns.Clear();

            // Adiciona as colunas ao DataGridView com seu nome e texto visivel
            dataGrid.Columns.Add("corriorCollum", "Corredor");
            dataGrid.Columns.Add("columnCollum", "Coluna");
            dataGrid.Columns.Add("levelCollum", "Nivel");
            dataGrid.Columns.Add("hallCollum", "Lote");
            dataGrid.Columns.Add("productCodeCollum", "Código do Produto");
            AddressDAO address = new AddressDAO();

            // Preenche o DataGridView com os dados dos endereços retornados pela DAO
            foreach (var item in address.GetAllData())
            {
                dataGrid.Rows.Add(item.Corridor, item.Column, item.Level, item.Hall, item.ProductCode);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            toolStripBtns = new ToolStrip();
            lbLogoTeste = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            btnProd = new ToolStripButton();
            btnUser = new ToolStripButton();
            btnAddress = new ToolStripButton();
            btnMoveProd = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            btnConfig = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnUserInfo = new ToolStripButton();
            colorDialog1 = new ColorDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            listBoxWarning = new ListBox();
            dataGrid = new DataGridView();
            txtBoxSearch = new TextBox();
            panel1 = new Panel();
            picBoxSearcIcon = new PictureBox();
            toolStripBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxSearcIcon).BeginInit();
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
            toolStripBtns.Items.AddRange(new ToolStripItem[] { lbLogoTeste, toolStripSeparator1, btnProd, btnUser, btnAddress, btnMoveProd, toolStripButton4, btnConfig, toolStripSeparator2, btnUserInfo });
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
            btnUser.Click += btnUser_Click;
            // 
            // btnAddress
            // 
            btnAddress.Image = (Image)resources.GetObject("btnAddress.Image");
            btnAddress.ImageScaling = ToolStripItemImageScaling.None;
            btnAddress.ImageTransparentColor = Color.Magenta;
            btnAddress.Name = "btnAddress";
            btnAddress.Size = new Size(148, 36);
            btnAddress.Text = "Endereços";
            btnAddress.Click += btnAddress_Click;
            // 
            // btnMoveProd
            // 
            btnMoveProd.Image = (Image)resources.GetObject("btnMoveProd.Image");
            btnMoveProd.ImageScaling = ToolStripItemImageScaling.None;
            btnMoveProd.ImageTransparentColor = Color.Magenta;
            btnMoveProd.Name = "btnMoveProd";
            btnMoveProd.Size = new Size(148, 36);
            btnMoveProd.Text = "Movimentar";
            btnMoveProd.Click += btnMoveProd_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(148, 20);
            toolStripButton4.Text = "Recebimento";
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
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToOrderColumns = true;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BorderStyle = BorderStyle.Fixed3D;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(150, 31);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(1114, 446);
            dataGrid.TabIndex = 2;
            dataGrid.CellDoubleClick += dataGrid_CellDoubleClick;
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.AcceptsTab = true;
            txtBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxSearch.BackColor = SystemColors.Info;
            txtBoxSearch.Cursor = Cursors.IBeam;
            txtBoxSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxSearch.ForeColor = SystemColors.ButtonShadow;
            txtBoxSearch.Location = new Point(27, 0);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.PlaceholderText = "Pesquisar";
            txtBoxSearch.Size = new Size(1089, 25);
            txtBoxSearch.TabIndex = 3;
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
            picBoxSearcIcon.BorderStyle = BorderStyle.Fixed3D;
            picBoxSearcIcon.Image = (Image)resources.GetObject("picBoxSearcIcon.Image");
            picBoxSearcIcon.Location = new Point(0, 0);
            picBoxSearcIcon.Name = "picBoxSearcIcon";
            picBoxSearcIcon.Size = new Size(27, 25);
            picBoxSearcIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxSearcIcon.TabIndex = 0;
            picBoxSearcIcon.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel1);
            Controls.Add(dataGrid);
            Controls.Add(listBoxWarning);
            Controls.Add(toolStripBtns);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1280, 720);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyChest";
            WindowState = FormWindowState.Maximized;
            FormClosed += HomeForm_FormClosed;
            Load += Home_Load;
            toolStripBtns.ResumeLayout(false);
            toolStripBtns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxSearcIcon).EndInit();
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
        private DataGridView dataGrid;
        private TextBox txtBoxSearch;
        private Panel panel1;
        private PictureBox picBoxSearcIcon;
        private ToolStripButton btnUserInfo;
        private ToolStripButton btnConfig;
        private ToolStripButton toolStripButton4;
        private ToolStripButton btnMoveProd;
    }
}
