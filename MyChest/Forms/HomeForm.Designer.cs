using MyChest.Data.DAO;
using MyChest.Interfaces;
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
        /// Desativa e esconde funcionalidades que o nivel de acesso do usuário nao permite acessar
        /// </summary> 
        private void ConfigureUIByUserPermissions()
        {
            foreach (var permission in _userLoged.Permissions)
            {
                switch (permission)
                {
                    case Permissions.MOVEPRODUCT:
                        btnMoveProduct.Enabled = true;
                        btnMoveProduct.Visible = true;
                        break;
                    case Permissions.EDITUSER:
                        btnUser.Enabled = true;
                        btnUser.Visible = true;
                        break;
                    case Permissions.ADMIN:
                        btnMoveProduct.Enabled = true;
                        btnMoveProduct.Visible = true;
                        btnUser.Enabled = true;
                        btnUser.Visible = true;
                        btnReceiptProduct.Enabled = true;
                        btnReceiptProduct.Visible = true;
                        break;
                }
            }
        }

        public void HideAndDisableButtons()
        {
            btnMoveProduct.Enabled = false;
            btnMoveProduct.Visible = false;
            btnUser.Enabled = false;
            btnUser.Visible = false;
            btnReceiptProduct.Enabled = false;
            btnReceiptProduct.Visible = false;
        }

        /// <summary>
        /// Preence o DataGridView com os dados dos produtos
        /// </summary>
        private void DataGridProductLoad()
        {
            maskTextSearch.Mask = "";

            picBoxAdd.Visible = false;
            picBoxAdd.Enabled = false;

            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("codeCollum", "Código");
            dataGrid.Columns.Add("nameCollum", "Nome");
            dataGrid.Columns.Add("brandCollum", "Marca");
            dataGrid.Columns.Add("amountCollum", "Quantidade");
            dataGrid.Columns.Add("tagsCollum", "Tags");
            dataGrid.Columns.Add("measureCollum", "Medida");
            ProductDAO prod = new ProductDAO();

            foreach (var item in ((IData<Product>)prod).GetAllData())
            {
                dataGrid.Rows.Add(item.Code, item.Name, item.Brand, item.Amount, item.Tags, item.Measure);
            }
        }

        /// <summary>
        /// Preenche o DataGridView com os dados dos usuários
        /// </summary>
        private void DataGridUserLoad()
        {
            maskTextSearch.Mask = "";

            picBoxAdd.Visible = true;
            picBoxAdd.Enabled = true;

            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("nameColumn", "Nome");
            dataGrid.Columns.Add("passwordColumn", "Senha");
            dataGrid.Columns.Add("permissionsColumn", "Permissões");
            UserDAO user = new UserDAO();

            foreach (var item in ((IData<User>)user).GetAllData())
            {
                string permissoesTexto = string.Join(", ", item.Permissions);
                if (string.IsNullOrWhiteSpace(permissoesTexto))
                {
                    dataGrid.Rows.Add(item.Name, item.Password, "SEM PERMISSÕES");
                }
                else
                {
                    dataGrid.Rows.Add(item.Name, item.Password, permissoesTexto);
                }
            }
        }

        /// <summary>
        /// Preence o DataGridView com os dados dos endereços
        /// </summary>
        private void DataGridAddressLoad()
        {
            maskTextSearch.Mask = "000-000-00-000";

            picBoxAdd.Visible = true;
            picBoxAdd.Enabled = true;

            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("corriorCollum", "Corredor");
            dataGrid.Columns.Add("columnCollum", "Coluna");
            dataGrid.Columns.Add("levelCollum", "Nivel");
            dataGrid.Columns.Add("hallCollum", "Lote");
            dataGrid.Columns.Add("productCodeCollum", "Código do Produto");
            AddressDAO address = new AddressDAO();

            foreach (var item in ((IData<Address>)address).GetAllData())
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
            btnMoveProduct = new ToolStripButton();
            btnReceiptProduct = new ToolStripButton();
            btnConfig = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnUserInfo = new ToolStripButton();
            colorDialog1 = new ColorDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            listBoxWarning = new ListBox();
            dataGrid = new DataGridView();
            panel1 = new Panel();
            comboBoxSearch = new ComboBox();
            picBoxAdd = new PictureBox();
            maskTextSearch = new MaskedTextBox();
            picBoxSearcIcon = new PictureBox();
            toolStripBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxAdd).BeginInit();
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
            toolStripBtns.Items.AddRange(new ToolStripItem[] { lbLogoTeste, toolStripSeparator1, btnProd, btnUser, btnAddress, btnMoveProduct, btnReceiptProduct, btnConfig, toolStripSeparator2, btnUserInfo });
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
            btnProd.Click += btnProduct_Click;
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
            // btnMoveProduct
            // 
            btnMoveProduct.Image = (Image)resources.GetObject("btnMoveProduct.Image");
            btnMoveProduct.ImageScaling = ToolStripItemImageScaling.None;
            btnMoveProduct.ImageTransparentColor = Color.Magenta;
            btnMoveProduct.Name = "btnMoveProduct";
            btnMoveProduct.Size = new Size(148, 36);
            btnMoveProduct.Text = "Movimentar";
            btnMoveProduct.Click += btnMoveProduct_Click;
            // 
            // btnReceiptProduct
            // 
            btnReceiptProduct.Image = (Image)resources.GetObject("btnReceiptProduct.Image");
            btnReceiptProduct.ImageScaling = ToolStripItemImageScaling.None;
            btnReceiptProduct.ImageTransparentColor = Color.Magenta;
            btnReceiptProduct.Name = "btnReceiptProduct";
            btnReceiptProduct.Size = new Size(148, 36);
            btnReceiptProduct.Text = "Recebimento";
            btnReceiptProduct.Click += btnReceiptProduct_Click;
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
            btnUserInfo.Click += btnUserLoged_Click;
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
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(comboBoxSearch);
            panel1.Controls.Add(picBoxAdd);
            panel1.Controls.Add(maskTextSearch);
            panel1.Controls.Add(picBoxSearcIcon);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(150, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 29);
            panel1.TabIndex = 4;
            // 
            // comboBoxSearch
            // 
            comboBoxSearch.BackColor = SystemColors.Info;
            comboBoxSearch.Cursor = Cursors.Hand;
            comboBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearch.Enabled = false;
            comboBoxSearch.FormattingEnabled = true;
            comboBoxSearch.Items.AddRange(new object[] { "Código", "Nome", "Marca" });
            comboBoxSearch.Location = new Point(25, 3);
            comboBoxSearch.Name = "comboBoxSearch";
            comboBoxSearch.Size = new Size(72, 23);
            comboBoxSearch.TabIndex = 7;
            comboBoxSearch.Visible = false;
            comboBoxSearch.SelectedIndexChanged += comboBoxSearch_SelectedIndexChanged;
            // 
            // picBoxAdd
            // 
            picBoxAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBoxAdd.BorderStyle = BorderStyle.Fixed3D;
            picBoxAdd.Image = (Image)resources.GetObject("picBoxAdd.Image");
            picBoxAdd.Location = new Point(1082, 0);
            picBoxAdd.Name = "picBoxAdd";
            picBoxAdd.Size = new Size(32, 25);
            picBoxAdd.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxAdd.TabIndex = 6;
            picBoxAdd.TabStop = false;
            picBoxAdd.Click += picBoxAdd_Click;
            // 
            // maskTextSearch
            // 
            maskTextSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            maskTextSearch.BackColor = SystemColors.Info;
            maskTextSearch.Cursor = Cursors.IBeam;
            maskTextSearch.Font = new Font("Segoe UI", 9.75F);
            maskTextSearch.ForeColor = SystemColors.ButtonShadow;
            maskTextSearch.Location = new Point(25, 0);
            maskTextSearch.Mask = "000-000-00-000";
            maskTextSearch.Name = "maskTextSearch";
            maskTextSearch.Size = new Size(1056, 25);
            maskTextSearch.TabIndex = 5;
            maskTextSearch.KeyDown += maskTextSearch_KeyDown;
            // 
            // picBoxSearcIcon
            // 
            picBoxSearcIcon.BorderStyle = BorderStyle.Fixed3D;
            picBoxSearcIcon.Cursor = Cursors.Hand;
            picBoxSearcIcon.Image = (Image)resources.GetObject("picBoxSearcIcon.Image");
            picBoxSearcIcon.Location = new Point(0, 0);
            picBoxSearcIcon.Name = "picBoxSearcIcon";
            picBoxSearcIcon.Size = new Size(27, 25);
            picBoxSearcIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxSearcIcon.TabIndex = 0;
            picBoxSearcIcon.TabStop = false;
            picBoxSearcIcon.Click += picBoxSearcIcon_Click;
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
            ((System.ComponentModel.ISupportInitialize)picBoxAdd).EndInit();
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
        private Panel panel1;
        private ToolStripButton btnUserInfo;
        private ToolStripButton btnConfig;
        private ToolStripButton btnReceiptProduct;
        private ToolStripButton btnMoveProduct;
        private MaskedTextBox maskTextSearch;
        private PictureBox picBoxAdd;
        private PictureBox picBoxSearcIcon;
        private ComboBox comboBoxSearch;
    }
}
