using MyChest.Data.DAO;
using MyChest.Extensions;
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

                // Adiciona os valores da linha do DataGridView selecionado ao objeto Address
                address.Corridor = dataGrid.SelectedRows[0].Cells[0].Value.ToString().ConvertToInt32();
                address.Column = dataGrid.SelectedRows[0].Cells[1].Value.ToString().ConvertToInt32();
                address.Level = dataGrid.SelectedRows[0].Cells[2].Value.ToString().ConvertToInt32();
                address.Hall = dataGrid.SelectedRows[0].Cells[3].Value.ToString().ConvertToInt32();

                addressDAO.MoveProdForAddress(codeProd, address);
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
                productDao.MoveProductForProduct(firstCodeProd, secondCodeProd);
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
            ProductDAO productDao = new ProductDAO();

            lbProdCode.Text = productDao.GetByCode(code).Code.ToString();
            lbProdName.Text = productDao.GetByCode(code).Name;
            lbProdBrand.Text = productDao.GetByCode(code).Brand;
            lbProdAmount.Text = productDao.GetByCode(code).Amount.ToString();
            lbProdMeasure.Text = productDao.GetByCode(code).Measure;
        }

        /// <summary>
        /// Atualiza as informações dos campos de exibição com com o produto pesquisado pelo código.
        /// </summary>
        /// <param name="code">Código usado como parâmetro de pesquisa</param>
        private void UpdateRightProductInfo(int code)
        {
            ProductDAO productDao = new ProductDAO();

            lbProdCode2.Text = productDao.GetByCode(code).Code.ToString();
            lbProdName2.Text = productDao.GetByCode(code).Name;
            lbProdBrand2.Text = productDao.GetByCode(code).Brand;
            lbProdAmount2.Text = productDao.GetByCode(code).Amount.ToString();
            lbProdMeasure2.Text = productDao.GetByCode(code).Measure;
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

            // Adiciona as colunas ao DataGridView com seu nome e texto visivel
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

            // Preenche o DataGridView com os dados dos endereços retornados pela DAO
            foreach (var item in address.GetAllData())
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
            lbInfoProdCode2.Enabled = true;
            lbProdCode2.Enabled = true;
            lbProdName2.Enabled = true;
            lbProdBrand2.Enabled = true;
            lbProdAmount2.Enabled = true;
            lbProdMeasure2.Enabled = true;
            txtBoxProd2.Enabled = true;
            lbInfoProdCode2.Show();
            lbProdCode2.Show();
            lbProdName2.Show();
            lbProdBrand2.Show();
            lbProdAmount2.Show();
            lbProdMeasure2.Show();
            txtBoxProd2.Show();
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
            lbInfoProdCode2.Enabled = false;
            lbProdCode2.Enabled = false;
            lbProdName2.Enabled = false;
            lbProdBrand2.Enabled = false;
            lbProdAmount2.Enabled = false;
            lbProdMeasure2.Enabled = false;
            txtBoxProd2.Enabled = false;
            lbInfoProdCode2.Hide();
            lbProdCode2.Hide();
            lbProdName2.Hide();
            lbProdBrand2.Hide();
            lbProdAmount2.Hide();
            lbProdMeasure2.Hide();
            txtBoxProd2.Hide();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveProdForm));
            txtBoxProd = new TextBox();
            lbInfoProdCode = new Label();
            lbProdCode = new Label();
            lbProdName = new Label();
            lbProdBrand = new Label();
            lbProdAmount = new Label();
            lbProdMeasure = new Label();
            lbProdMeasure2 = new Label();
            lbProdAmount2 = new Label();
            lbProdBrand2 = new Label();
            lbProdName2 = new Label();
            lbProdCode2 = new Label();
            lbInfoProdCode2 = new Label();
            txtBoxProd2 = new TextBox();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            btnMovOptions = new ToolStripMenuItem();
            btnMovProdByProd = new ToolStripMenuItem();
            btnMovProdByAddress = new ToolStripMenuItem();
            picBoxArrows = new PictureBox();
            dataGrid = new DataGridView();
            picBoxSearch = new PictureBox();
            maskTxtBoxSearchAddress = new MaskedTextBox();
            btnMoveConfirm = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArrows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).BeginInit();
            SuspendLayout();
            // 
            // txtBoxProd
            // 
            txtBoxProd.Location = new Point(12, 56);
            txtBoxProd.Name = "txtBoxProd";
            txtBoxProd.Size = new Size(109, 23);
            txtBoxProd.TabIndex = 0;
            txtBoxProd.TextChanged += textBox1_TextChanged;
            // 
            // lbInfoProdCode
            // 
            lbInfoProdCode.AutoSize = true;
            lbInfoProdCode.Location = new Point(12, 38);
            lbInfoProdCode.Name = "lbInfoProdCode";
            lbInfoProdCode.Size = new Size(109, 15);
            lbInfoProdCode.TabIndex = 1;
            lbInfoProdCode.Text = "Código do produto";
            // 
            // lbProdCode
            // 
            lbProdCode.AutoSize = true;
            lbProdCode.BorderStyle = BorderStyle.Fixed3D;
            lbProdCode.Location = new Point(12, 91);
            lbProdCode.Name = "lbProdCode";
            lbProdCode.Size = new Size(33, 17);
            lbProdCode.TabIndex = 2;
            lbProdCode.Text = "0000";
            // 
            // lbProdName
            // 
            lbProdName.AutoSize = true;
            lbProdName.BorderStyle = BorderStyle.Fixed3D;
            lbProdName.Location = new Point(12, 108);
            lbProdName.Name = "lbProdName";
            lbProdName.Size = new Size(105, 17);
            lbProdName.TabIndex = 3;
            lbProdName.Text = "Nome do produto";
            // 
            // lbProdBrand
            // 
            lbProdBrand.AutoSize = true;
            lbProdBrand.BorderStyle = BorderStyle.Fixed3D;
            lbProdBrand.Location = new Point(12, 125);
            lbProdBrand.Name = "lbProdBrand";
            lbProdBrand.Size = new Size(42, 17);
            lbProdBrand.TabIndex = 4;
            lbProdBrand.Text = "Marca";
            // 
            // lbProdAmount
            // 
            lbProdAmount.AutoSize = true;
            lbProdAmount.BorderStyle = BorderStyle.Fixed3D;
            lbProdAmount.Location = new Point(12, 142);
            lbProdAmount.Name = "lbProdAmount";
            lbProdAmount.Size = new Size(27, 17);
            lbProdAmount.TabIndex = 5;
            lbProdAmount.Text = "000";
            // 
            // lbProdMeasure
            // 
            lbProdMeasure.AutoSize = true;
            lbProdMeasure.BorderStyle = BorderStyle.Fixed3D;
            lbProdMeasure.Location = new Point(12, 159);
            lbProdMeasure.Name = "lbProdMeasure";
            lbProdMeasure.Size = new Size(49, 17);
            lbProdMeasure.TabIndex = 6;
            lbProdMeasure.Text = "Medida";
            // 
            // lbProdMeasure2
            // 
            lbProdMeasure2.AutoSize = true;
            lbProdMeasure2.BorderStyle = BorderStyle.Fixed3D;
            lbProdMeasure2.Location = new Point(312, 159);
            lbProdMeasure2.Name = "lbProdMeasure2";
            lbProdMeasure2.Size = new Size(49, 17);
            lbProdMeasure2.TabIndex = 13;
            lbProdMeasure2.Text = "Medida";
            // 
            // lbProdAmount2
            // 
            lbProdAmount2.AutoSize = true;
            lbProdAmount2.BorderStyle = BorderStyle.Fixed3D;
            lbProdAmount2.Location = new Point(312, 142);
            lbProdAmount2.Name = "lbProdAmount2";
            lbProdAmount2.Size = new Size(27, 17);
            lbProdAmount2.TabIndex = 12;
            lbProdAmount2.Text = "000";
            // 
            // lbProdBrand2
            // 
            lbProdBrand2.AutoSize = true;
            lbProdBrand2.BorderStyle = BorderStyle.Fixed3D;
            lbProdBrand2.Location = new Point(312, 125);
            lbProdBrand2.Name = "lbProdBrand2";
            lbProdBrand2.Size = new Size(42, 17);
            lbProdBrand2.TabIndex = 11;
            lbProdBrand2.Text = "Marca";
            // 
            // lbProdName2
            // 
            lbProdName2.AutoSize = true;
            lbProdName2.BorderStyle = BorderStyle.Fixed3D;
            lbProdName2.Location = new Point(312, 108);
            lbProdName2.Name = "lbProdName2";
            lbProdName2.Size = new Size(42, 17);
            lbProdName2.TabIndex = 10;
            lbProdName2.Text = "Nome";
            // 
            // lbProdCode2
            // 
            lbProdCode2.AutoSize = true;
            lbProdCode2.BorderStyle = BorderStyle.Fixed3D;
            lbProdCode2.Location = new Point(312, 91);
            lbProdCode2.Name = "lbProdCode2";
            lbProdCode2.Size = new Size(33, 17);
            lbProdCode2.TabIndex = 9;
            lbProdCode2.Text = "0000";
            // 
            // lbInfoProdCode2
            // 
            lbInfoProdCode2.AutoSize = true;
            lbInfoProdCode2.Location = new Point(312, 38);
            lbInfoProdCode2.Name = "lbInfoProdCode2";
            lbInfoProdCode2.Size = new Size(109, 15);
            lbInfoProdCode2.TabIndex = 8;
            lbInfoProdCode2.Text = "Código do produto";
            // 
            // txtBoxProd2
            // 
            txtBoxProd2.Location = new Point(312, 56);
            txtBoxProd2.Name = "txtBoxProd2";
            txtBoxProd2.Size = new Size(109, 23);
            txtBoxProd2.TabIndex = 7;
            txtBoxProd2.TextChanged += txtBoxProd2_TextChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(704, 25);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "tooStrip";
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
            Controls.Add(toolStrip1);
            Controls.Add(lbProdMeasure2);
            Controls.Add(lbProdAmount2);
            Controls.Add(lbProdBrand2);
            Controls.Add(lbProdName2);
            Controls.Add(lbProdCode2);
            Controls.Add(lbInfoProdCode2);
            Controls.Add(txtBoxProd2);
            Controls.Add(lbProdMeasure);
            Controls.Add(lbProdAmount);
            Controls.Add(lbProdBrand);
            Controls.Add(lbProdName);
            Controls.Add(lbProdCode);
            Controls.Add(lbInfoProdCode);
            Controls.Add(txtBoxProd);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MoveProdForm";
            Text = "Movimentar";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBoxArrows).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxProd;
        private Label lbInfoProdCode;
        private Label lbProdCode;
        private Label lbProdName;
        private Label lbProdBrand;
        private Label lbProdAmount;
        private Label lbProdMeasure;
        private Label lbProdMeasure2;
        private Label lbProdAmount2;
        private Label lbProdBrand2;
        private Label lbProdName2;
        private Label lbProdCode2;
        private Label lbInfoProdCode2;
        private TextBox txtBoxProd2;
        private ToolStrip toolStrip1;
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