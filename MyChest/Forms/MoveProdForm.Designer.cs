using MyChest.Data.DAO;
using MyChest.Extensions;
using MyChest.Interfaces;
using MyChest.Models;

namespace MyChest.Forms
{
    partial class MoveProdForm
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
        /// Atualiza o dataGrid com o endereço especificado
        /// </summary>
        private void GetAddressByNumber()
        {
            AddressDAO addressDAO = new AddressDAO();
            string[] addressNumbers = maskTxtBoxSearchAddress.Text.Split('-');
            DataGridAddressUpdate
                (
                    addressDAO.GetAddressByNumbers
                    (
                        addressNumbers[0].ConvertToInt32(),
                        addressNumbers[1].ConvertToInt32(),
                        addressNumbers[2].ConvertToInt32(),
                        addressNumbers[3].ConvertToInt32()
                    )
                );
        }

        /// <summary>
        /// Verifica se os labels possuem valores válidos.
        /// </summary>
        /// <param name="labels">Lista de labels a ser verificadas</param>
        /// <returns>Retorna true se caso todos os valores forem válidos e false caso contrário</returns>
        private bool TestLabelsContainsValidValues(List<Label> labels)
        {
            foreach (var item in labels)
            {
                if (string.IsNullOrWhiteSpace(item.Text))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Movimenta o produto selecionado para o endereço especificado.
        /// </summary>
        /// <param name="codeProd">Código do produto a ser movimentado</param>
        private void MoveProd(int codeProd)
        {
            try
            {
                AddressDAO addressDAO = new AddressDAO();
                Address address = new Address();

                address.Corridor = dataGrid.SelectedRows[0].Cells[0].Value.ToString().ConvertToInt32();
                address.Column = dataGrid.SelectedRows[0].Cells[1].Value.ToString().ConvertToInt32();
                address.Level = dataGrid.SelectedRows[0].Cells[2].Value.ToString().ConvertToInt32();
                address.Hall = dataGrid.SelectedRows[0].Cells[3].Value.ToString().ConvertToInt32();

                addressDAO.MoveProductForAddress(codeProd, address);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Produto não selecionado ou inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Troca os enderços entre os produtos
        /// Produto A - Endereço B
        /// Produto C - Endereço D
        /// Com a mudança fica:
        /// Produto A - Endereço D
        /// Produto C - Endereço B
        /// </summary>
        /// <param name="firstCodeProd">Código do primeiro produto</param>
        /// <param name="secondCodeProd">Código do segundo produto</param>
        private void MoveProd(int firstCodeProd, int secondCodeProd)
        {
            try
            {
                ProductDAO productDao = new ProductDAO();
                productDao.SwapAddressesBetweenProducts(firstCodeProd, secondCodeProd);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Produto não selecionado ou inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Atualiza as informações dos campos de exibição com o produto pesquisado pelo codigo.
        /// </summary>
        /// <param name="code">Código usado como parâmetro de pesquisa</param>
        private void UpdateLeftProductInfo(int code)
        {
            IData<Product> productDao = new ProductDAO();

            lbLeftProductCode.Text = productDao.GetById(code).Code.ToString();
            lbLeftProductName.Text = productDao.GetById(code).Name;
            lbLeftProductBrand.Text = productDao.GetById(code).Brand;
            lbLeftProductAmount.Text = productDao.GetById(code).Amount.ToString();
            lbLeftProductMeasure.Text = productDao.GetById(code).Measure;
        }

        /// <summary>
        /// Atualiza as informações dos campos de exibição com com o produto pesquisado pelo código.
        /// </summary>
        /// <param name="code">Código usado como parâmetro de pesquisa</param>
        private void UpdateRightProductInfo(int code)
        {
            IData<Product> productDao = new ProductDAO();

            lbRightProductCode.Text = productDao.GetById(code).Code.ToString();
            lbRightProductName.Text = productDao.GetById(code).Name;
            lbRightProductBrand.Text = productDao.GetById(code).Brand;
            lbRightProductAmount.Text = productDao.GetById(code).Amount.ToString();
            lbRightProductMeasure.Text = productDao.GetById(code).Measure;
        }

        /// <summary>
        /// Atualiza o DataGridView com os dados do endereço especificado.
        /// </summary>
        /// <param name="address">Espera um objeto do tipo "Address" utilizando de suas propriedades para atualizar o endereço no DataGridView</param>
        private void DataGridAddressUpdate(Address address)
        {
            dataGrid.Rows.Clear();
            dataGrid.Rows.Add(address.Corridor, address.Column, address.Level, address.Hall);
        }

        /// <summary>
        /// Começa o DataGridView, desenha as colunas e preenche com os dados dos endereços.
        /// </summary>
        private void DataGridAddressStart()
        {
            dataGrid.Columns.Clear();

            dataGrid.Columns.Add("corriorCollum", "Corredor");
            dataGrid.Columns.Add("columnCollum", "Coluna");
            dataGrid.Columns.Add("levelCollum", "Nivel");
            dataGrid.Columns.Add("hallCollum", "Lote");

            DataGridAddressLoad();
        }

        /// <summary>
        /// Carrega os dados do DataGridView com os endereços existentes no banco de dados.
        /// </summary>
        private void DataGridAddressLoad()
        {
            AddressDAO address = new AddressDAO();

            foreach (var item in ((IData<Address>)address).GetAllData())
            {
                dataGrid.Rows.Add(item.Corridor, item.Column, item.Level, item.Hall);
            }
        }

        /// <summary>
        /// Ativa e mostra os componentes necessários para a movimentação de endereços para endereços.
        /// </summary>
        private void ShowAddressMoveComponents()
        {
            dataGrid.Enabled = true;
            dataGrid.Show();

            picBoxSearch.Enabled = true;
            picBoxSearch.Show();

            maskTxtBoxSearchAddress.Enabled = true;
            maskTxtBoxSearchAddress.Show();
        }

        /// <summary>
        /// Ativa e mostra os componentes necessários para a movimentação de produtos para produtos.
        /// </summary>
        private void ShowProductMoveComponents()
        {
            lbRightProductCodeInfo.Enabled = true;
            lbRightProductCode.Enabled = true;
            lbRightProductName.Enabled = true;
            lbRightProductBrand.Enabled = true;
            lbRightProductAmount.Enabled = true;
            lbRightProductMeasure.Enabled = true;
            txtBoxRightProduct.Enabled = true;
            lbRightProductCodeInfo.Show();
            lbRightProductCode.Show();
            lbRightProductName.Show();
            lbRightProductBrand.Show();
            lbRightProductAmount.Show();
            lbRightProductMeasure.Show();
            txtBoxRightProduct.Show();
        }

        /// <summary>
        /// Desativa e esconde os componentes necessários para a movimentação de endereços para endereços.
        /// </summary>
        private void HideAddressMoveComponents()
        {
            dataGrid.Enabled = false;
            dataGrid.Hide();

            picBoxSearch.Enabled = false;
            picBoxSearch.Hide();

            maskTxtBoxSearchAddress.Enabled = false;
            maskTxtBoxSearchAddress.Hide();
        }

        /// <summary>
        /// Desativa e esconde os componentes necessários para a movimentação de produtos para produtos.
        /// </summary>
        private void HideProductMoveComponents()
        {
            lbRightProductCodeInfo.Enabled = false;
            lbRightProductCode.Enabled = false;
            lbRightProductName.Enabled = false;
            lbRightProductBrand.Enabled = false;
            lbRightProductAmount.Enabled = false;
            lbRightProductMeasure.Enabled = false;
            txtBoxRightProduct.Enabled = false;
            lbRightProductCodeInfo.Hide();
            lbRightProductCode.Hide();
            lbRightProductName.Hide();
            lbRightProductBrand.Hide();
            lbRightProductAmount.Hide();
            lbRightProductMeasure.Hide();
            txtBoxRightProduct.Hide();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveProdForm));
            txtBoxLeftProduct = new TextBox();
            lbInfoProductCode = new Label();
            lbLeftProductCode = new Label();
            lbLeftProductName = new Label();
            lbLeftProductBrand = new Label();
            lbLeftProductAmount = new Label();
            lbLeftProductMeasure = new Label();
            lbRightProductMeasure = new Label();
            lbRightProductAmount = new Label();
            lbRightProductBrand = new Label();
            lbRightProductName = new Label();
            lbRightProductCode = new Label();
            lbRightProductCodeInfo = new Label();
            txtBoxRightProduct = new TextBox();
            toolStrip = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            btnMovOptions = new ToolStripMenuItem();
            btnMovProdByProd = new ToolStripMenuItem();
            btnMovProdByAddress = new ToolStripMenuItem();
            picBoxArrows = new PictureBox();
            dataGrid = new DataGridView();
            picBoxSearch = new PictureBox();
            maskTxtBoxSearchAddress = new MaskedTextBox();
            btnMoveConfirm = new Button();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArrows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).BeginInit();
            SuspendLayout();
            // 
            // txtBoxProduct
            // 
            txtBoxLeftProduct.Location = new Point(12, 56);
            txtBoxLeftProduct.Name = "txtBoxProduct";
            txtBoxLeftProduct.Size = new Size(109, 23);
            txtBoxLeftProduct.TabIndex = 0;
            txtBoxLeftProduct.TextChanged += textBoxLeft_TextChanged;
            // 
            // lbInfoProductCode
            // 
            lbInfoProductCode.AutoSize = true;
            lbInfoProductCode.Location = new Point(12, 38);
            lbInfoProductCode.Name = "lbInfoProductCode";
            lbInfoProductCode.Size = new Size(109, 15);
            lbInfoProductCode.TabIndex = 1;
            lbInfoProductCode.Text = "Código do produto";
            // 
            // lbProductCode
            // 
            lbLeftProductCode.AutoSize = true;
            lbLeftProductCode.BorderStyle = BorderStyle.Fixed3D;
            lbLeftProductCode.Location = new Point(12, 91);
            lbLeftProductCode.Name = "lbProductCode";
            lbLeftProductCode.Size = new Size(33, 17);
            lbLeftProductCode.TabIndex = 2;
            lbLeftProductCode.Text = "0000";
            // 
            // lbProductName
            // 
            lbLeftProductName.AutoSize = true;
            lbLeftProductName.BorderStyle = BorderStyle.Fixed3D;
            lbLeftProductName.Location = new Point(12, 108);
            lbLeftProductName.Name = "lbProductName";
            lbLeftProductName.Size = new Size(105, 17);
            lbLeftProductName.TabIndex = 3;
            lbLeftProductName.Text = "Nome do produto";
            // 
            // lbProdBrand
            // 
            lbLeftProductBrand.AutoSize = true;
            lbLeftProductBrand.BorderStyle = BorderStyle.Fixed3D;
            lbLeftProductBrand.Location = new Point(12, 125);
            lbLeftProductBrand.Name = "lbProdBrand";
            lbLeftProductBrand.Size = new Size(42, 17);
            lbLeftProductBrand.TabIndex = 4;
            lbLeftProductBrand.Text = "Marca";
            // 
            // lbProdAmount
            // 
            lbLeftProductAmount.AutoSize = true;
            lbLeftProductAmount.BorderStyle = BorderStyle.Fixed3D;
            lbLeftProductAmount.Location = new Point(12, 142);
            lbLeftProductAmount.Name = "lbProdAmount";
            lbLeftProductAmount.Size = new Size(27, 17);
            lbLeftProductAmount.TabIndex = 5;
            lbLeftProductAmount.Text = "000";
            // 
            // lbProdMeasure
            // 
            lbLeftProductMeasure.AutoSize = true;
            lbLeftProductMeasure.BorderStyle = BorderStyle.Fixed3D;
            lbLeftProductMeasure.Location = new Point(12, 159);
            lbLeftProductMeasure.Name = "lbProdMeasure";
            lbLeftProductMeasure.Size = new Size(49, 17);
            lbLeftProductMeasure.TabIndex = 6;
            lbLeftProductMeasure.Text = "Medida";
            // 
            // lbProdMeasure2
            // 
            lbRightProductMeasure.AutoSize = true;
            lbRightProductMeasure.BorderStyle = BorderStyle.Fixed3D;
            lbRightProductMeasure.Location = new Point(312, 159);
            lbRightProductMeasure.Name = "lbProdMeasure2";
            lbRightProductMeasure.Size = new Size(49, 17);
            lbRightProductMeasure.TabIndex = 13;
            lbRightProductMeasure.Text = "Medida";
            // 
            // lbProdAmount2
            // 
            lbRightProductAmount.AutoSize = true;
            lbRightProductAmount.BorderStyle = BorderStyle.Fixed3D;
            lbRightProductAmount.Location = new Point(312, 142);
            lbRightProductAmount.Name = "lbProdAmount2";
            lbRightProductAmount.Size = new Size(27, 17);
            lbRightProductAmount.TabIndex = 12;
            lbRightProductAmount.Text = "000";
            // 
            // lbProdBrand2
            // 
            lbRightProductBrand.AutoSize = true;
            lbRightProductBrand.BorderStyle = BorderStyle.Fixed3D;
            lbRightProductBrand.Location = new Point(312, 125);
            lbRightProductBrand.Name = "lbProdBrand2";
            lbRightProductBrand.Size = new Size(42, 17);
            lbRightProductBrand.TabIndex = 11;
            lbRightProductBrand.Text = "Marca";
            // 
            // lbProdName2
            // 
            lbRightProductName.AutoSize = true;
            lbRightProductName.BorderStyle = BorderStyle.Fixed3D;
            lbRightProductName.Location = new Point(312, 108);
            lbRightProductName.Name = "lbProdName2";
            lbRightProductName.Size = new Size(42, 17);
            lbRightProductName.TabIndex = 10;
            lbRightProductName.Text = "Nome";
            // 
            // lbProdCode2
            // 
            lbRightProductCode.AutoSize = true;
            lbRightProductCode.BorderStyle = BorderStyle.Fixed3D;
            lbRightProductCode.Location = new Point(312, 91);
            lbRightProductCode.Name = "lbProdCode2";
            lbRightProductCode.Size = new Size(33, 17);
            lbRightProductCode.TabIndex = 9;
            lbRightProductCode.Text = "0000";
            // 
            // lbInfoProdCode2
            // 
            lbRightProductCodeInfo.AutoSize = true;
            lbRightProductCodeInfo.Location = new Point(312, 38);
            lbRightProductCodeInfo.Name = "lbInfoProdCode2";
            lbRightProductCodeInfo.Size = new Size(109, 15);
            lbRightProductCodeInfo.TabIndex = 8;
            lbRightProductCodeInfo.Text = "Código do produto";
            // 
            // txtBoxProd2
            // 
            txtBoxRightProduct.Location = new Point(312, 56);
            txtBoxRightProduct.Name = "txtBoxProd2";
            txtBoxRightProduct.Size = new Size(109, 23);
            txtBoxRightProduct.TabIndex = 7;
            txtBoxRightProduct.TextChanged += txtBoxProdRight_TextChanged;
            // 
            // toolStrip1
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip1";
            toolStrip.Size = new Size(704, 25);
            toolStrip.TabIndex = 14;
            toolStrip.Text = "tooStrip";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { btnMovOptions });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(60, 22);
            toolStripDropDownButton1.Text = "Opções";
            // 
            // btnMovOptions
            // 
            btnMovOptions.DropDownItems.AddRange(new ToolStripItem[] { btnMovProdByProd, btnMovProdByAddress });
            btnMovOptions.Name = "btnMovOptions";
            btnMovOptions.Size = new Size(159, 22);
            btnMovOptions.Text = "Movimentações";
            // 
            // btnMovProdByProd
            // 
            btnMovProdByProd.Name = "btnMovProdByProd";
            btnMovProdByProd.Size = new Size(195, 22);
            btnMovProdByProd.Text = "Produto para Produto";
            btnMovProdByProd.Click += btnMovProdByProd_Click;
            // 
            // btnMovProdByAddress
            // 
            btnMovProdByAddress.Name = "btnMovProdByAddress";
            btnMovProdByAddress.Size = new Size(195, 22);
            btnMovProdByAddress.Text = "Produto para Endereço";
            btnMovProdByAddress.Click += btnMovProdByAddress_Click;
            // 
            // picBoxArrows
            // 
            picBoxArrows.BorderStyle = BorderStyle.Fixed3D;
            picBoxArrows.Image = (Image)resources.GetObject("picBoxArrows.Image");
            picBoxArrows.Location = new Point(209, 106);
            picBoxArrows.Name = "picBoxArrows";
            picBoxArrows.Size = new Size(36, 36);
            picBoxArrows.SizeMode = PictureBoxSizeMode.AutoSize;
            picBoxArrows.TabIndex = 15;
            picBoxArrows.TabStop = false;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToOrderColumns = true;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.BorderStyle = BorderStyle.Fixed3D;
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Location = new Point(312, 59);
            dataGrid.MultiSelect = false;
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.Size = new Size(380, 160);
            dataGrid.TabIndex = 16;
            // 
            // picBoxSearch
            // 
            picBoxSearch.BackColor = SystemColors.Info;
            picBoxSearch.BorderStyle = BorderStyle.Fixed3D;
            picBoxSearch.Image = (Image)resources.GetObject("picBoxSearch.Image");
            picBoxSearch.Location = new Point(312, 37);
            picBoxSearch.Name = "picBoxSearch";
            picBoxSearch.Size = new Size(31, 22);
            picBoxSearch.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxSearch.TabIndex = 18;
            picBoxSearch.TabStop = false;
            // 
            // maskTxtBoxSearchAddress
            // 
            maskTxtBoxSearchAddress.BackColor = SystemColors.Info;
            maskTxtBoxSearchAddress.BorderStyle = BorderStyle.FixedSingle;
            maskTxtBoxSearchAddress.Location = new Point(343, 36);
            maskTxtBoxSearchAddress.Mask = "00-00-00-00";
            maskTxtBoxSearchAddress.Name = "maskTxtBoxSearchAddress";
            maskTxtBoxSearchAddress.Size = new Size(78, 23);
            maskTxtBoxSearchAddress.TabIndex = 19;
            maskTxtBoxSearchAddress.TextChanged += maskTxtBoxSearchAddress_TextChanged;
            // 
            // btnMoveConfirm
            // 
            btnMoveConfirm.FlatStyle = FlatStyle.System;
            btnMoveConfirm.Location = new Point(12, 196);
            btnMoveConfirm.Name = "btnMoveConfirm";
            btnMoveConfirm.Size = new Size(89, 23);
            btnMoveConfirm.TabIndex = 20;
            btnMoveConfirm.Text = "Movimentar";
            btnMoveConfirm.UseVisualStyleBackColor = true;
            btnMoveConfirm.Click += btnMoveConfirm_Click;
            // 
            // MoveProdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(704, 231);
            Controls.Add(btnMoveConfirm);
            Controls.Add(maskTxtBoxSearchAddress);
            Controls.Add(picBoxSearch);
            Controls.Add(dataGrid);
            Controls.Add(picBoxArrows);
            Controls.Add(toolStrip);
            Controls.Add(lbRightProductMeasure);
            Controls.Add(lbRightProductAmount);
            Controls.Add(lbRightProductBrand);
            Controls.Add(lbRightProductName);
            Controls.Add(lbRightProductCode);
            Controls.Add(lbRightProductCodeInfo);
            Controls.Add(txtBoxRightProduct);
            Controls.Add(lbLeftProductMeasure);
            Controls.Add(lbLeftProductAmount);
            Controls.Add(lbLeftProductBrand);
            Controls.Add(lbLeftProductName);
            Controls.Add(lbLeftProductCode);
            Controls.Add(lbInfoProductCode);
            Controls.Add(txtBoxLeftProduct);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveProdForm";
            Text = "Movimentar";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArrows).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxLeftProduct;
        private Label lbInfoProductCode;
        private Label lbLeftProductCode;
        private Label lbLeftProductName;
        private Label lbLeftProductBrand;
        private Label lbLeftProductAmount;
        private Label lbLeftProductMeasure;
        private Label lbRightProductMeasure;
        private Label lbRightProductAmount;
        private Label lbRightProductBrand;
        private Label lbRightProductName;
        private Label lbRightProductCode;
        private Label lbRightProductCodeInfo;
        private TextBox txtBoxRightProduct;
        private ToolStrip toolStrip;
        private PictureBox picBoxArrows;
        private DataGridView dataGrid;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem btnMovOptions;
        private ToolStripMenuItem btnMovProdByProd;
        private ToolStripMenuItem btnMovProdByAddress;
        private PictureBox picBoxSearch;
        private MaskedTextBox maskTxtBoxSearchAddress;
        private Button btnMoveConfirm;
    }
}