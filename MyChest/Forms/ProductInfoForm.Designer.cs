using MyChest.Data.DAO;
using MyChest.Models;

namespace MyChest.Forms
{
    partial class ProductInfoForm
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
        /// Insere os dados do produto nas labels representadas
        /// </summary>
        private void LoadLabelsText()
        {
            this.Text = _selectedProduct.Name;
            lbProdCodeInfo.Text = _selectedProduct.Code.ToString();
            lbProdNameInfo.Text = _selectedProduct.Name.ToString();
            lbProdMeasureInfo.Text = _selectedProduct.Measure.ToString();
            lbProdBrandInfo.Text = _selectedProduct.Brand.ToString();
            lbProdAmountInfo.Text = _selectedProduct.Amount.ToString();
            lbProdValidityInfo.Text = _selectedProduct.Validity.HasValue ? _selectedProduct.Validity.ToString() : "Indefinida";
        }

        /// <summary>
        /// Carrega o dataGridView da Form com o endereço do produto selecionado
        /// </summary>
        private void DataGridLoad()
        {
            dataGridAddresses.Columns.Clear();

            dataGridAddresses.Columns.Add("corriorCollum", "Corredor");
            dataGridAddresses.Columns.Add("columnCollum", "Coluna");
            dataGridAddresses.Columns.Add("levelCollum", "Nivel");
            dataGridAddresses.Columns.Add("hallCollum", "Lote");
            ProductDAO product = new ProductDAO();

            dataGridAddresses.Rows.Add(product.GetAddressByProductId(_selectedProduct.Code).Corridor, product.GetAddressByProductId(_selectedProduct.Code).Column, product.GetAddressByProductId(_selectedProduct.Code).Level, product.GetAddressByProductId(_selectedProduct.Code).Hall, product.GetAddressByProductId(_selectedProduct.Code).ProductCode);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfoForm));
            lbProdName = new Label();
            lbProdMeasure = new Label();
            lbProdAmount = new Label();
            lbProdBrand = new Label();
            lbProdCode = new Label();
            lbProdNameInfo = new Label();
            lbProdCodeInfo = new Label();
            lbProdBrandInfo = new Label();
            lbProdMeasureInfo = new Label();
            lbProdAmountInfo = new Label();
            lbAddresses = new Label();
            dataGridAddresses = new DataGridView();
            lbProdValidity = new Label();
            lbProdValidityInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridAddresses).BeginInit();
            SuspendLayout();
            // 
            // lbProdName
            // 
            lbProdName.AutoSize = true;
            lbProdName.BorderStyle = BorderStyle.FixedSingle;
            lbProdName.Location = new Point(12, 9);
            lbProdName.Name = "lbProdName";
            lbProdName.Size = new Size(52, 17);
            lbProdName.TabIndex = 4;
            lbProdName.Text = "Produto";
            // 
            // lbProdMeasure
            // 
            lbProdMeasure.AutoSize = true;
            lbProdMeasure.BorderStyle = BorderStyle.FixedSingle;
            lbProdMeasure.Location = new Point(12, 77);
            lbProdMeasure.Name = "lbProdMeasure";
            lbProdMeasure.Size = new Size(49, 17);
            lbProdMeasure.TabIndex = 10;
            lbProdMeasure.Text = "Medida";
            // 
            // lbProdAmount
            // 
            lbProdAmount.AutoSize = true;
            lbProdAmount.BorderStyle = BorderStyle.FixedSingle;
            lbProdAmount.Location = new Point(12, 111);
            lbProdAmount.Name = "lbProdAmount";
            lbProdAmount.Size = new Size(29, 17);
            lbProdAmount.TabIndex = 9;
            lbProdAmount.Text = "Qtd";
            // 
            // lbProdBrand
            // 
            lbProdBrand.AutoSize = true;
            lbProdBrand.BorderStyle = BorderStyle.FixedSingle;
            lbProdBrand.Location = new Point(143, 43);
            lbProdBrand.Name = "lbProdBrand";
            lbProdBrand.Size = new Size(42, 17);
            lbProdBrand.TabIndex = 8;
            lbProdBrand.Text = "Marca";
            // 
            // lbProdCode
            // 
            lbProdCode.AutoSize = true;
            lbProdCode.BorderStyle = BorderStyle.FixedSingle;
            lbProdCode.Location = new Point(12, 43);
            lbProdCode.Name = "lbProdCode";
            lbProdCode.Size = new Size(71, 17);
            lbProdCode.TabIndex = 7;
            lbProdCode.Text = "Código ERP";
            // 
            // lbProdNameInfo
            // 
            lbProdNameInfo.AutoSize = true;
            lbProdNameInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdNameInfo.Location = new Point(70, 9);
            lbProdNameInfo.Name = "lbProdNameInfo";
            lbProdNameInfo.Size = new Size(115, 17);
            lbProdNameInfo.TabIndex = 11;
            lbProdNameInfo.Text = "\"Nome do produto\"";
            // 
            // lbProdCodeInfo
            // 
            lbProdCodeInfo.AutoSize = true;
            lbProdCodeInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdCodeInfo.Location = new Point(89, 43);
            lbProdCodeInfo.Name = "lbProdCodeInfo";
            lbProdCodeInfo.Size = new Size(39, 17);
            lbProdCodeInfo.TabIndex = 12;
            lbProdCodeInfo.Text = "00000";
            // 
            // lbProdBrandInfo
            // 
            lbProdBrandInfo.AutoSize = true;
            lbProdBrandInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdBrandInfo.Location = new Point(191, 43);
            lbProdBrandInfo.Name = "lbProdBrandInfo";
            lbProdBrandInfo.Size = new Size(94, 17);
            lbProdBrandInfo.TabIndex = 13;
            lbProdBrandInfo.Text = "Nome da Marca";
            // 
            // lbProdMeasureInfo
            // 
            lbProdMeasureInfo.AutoSize = true;
            lbProdMeasureInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdMeasureInfo.Location = new Point(67, 77);
            lbProdMeasureInfo.Name = "lbProdMeasureInfo";
            lbProdMeasureInfo.Size = new Size(101, 17);
            lbProdMeasureInfo.TabIndex = 14;
            lbProdMeasureInfo.Text = "Nome da Medida";
            // 
            // lbProdAmountInfo
            // 
            lbProdAmountInfo.AutoSize = true;
            lbProdAmountInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdAmountInfo.Location = new Point(47, 111);
            lbProdAmountInfo.Name = "lbProdAmountInfo";
            lbProdAmountInfo.Size = new Size(27, 17);
            lbProdAmountInfo.TabIndex = 15;
            lbProdAmountInfo.Text = "000";
            // 
            // lbAddresses
            // 
            lbAddresses.AutoSize = true;
            lbAddresses.BorderStyle = BorderStyle.FixedSingle;
            lbAddresses.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbAddresses.Location = new Point(157, 165);
            lbAddresses.Name = "lbAddresses";
            lbAddresses.Size = new Size(79, 22);
            lbAddresses.TabIndex = 17;
            lbAddresses.Text = "Endereços";
            // 
            // dataGridAddresses
            // 
            dataGridAddresses.AllowUserToAddRows = false;
            dataGridAddresses.AllowUserToDeleteRows = false;
            dataGridAddresses.AllowUserToResizeColumns = false;
            dataGridAddresses.AllowUserToResizeRows = false;
            dataGridAddresses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAddresses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridAddresses.BorderStyle = BorderStyle.Fixed3D;
            dataGridAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAddresses.Location = new Point(12, 190);
            dataGridAddresses.MultiSelect = false;
            dataGridAddresses.Name = "dataGridAddresses";
            dataGridAddresses.ReadOnly = true;
            dataGridAddresses.RowHeadersVisible = false;
            dataGridAddresses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAddresses.Size = new Size(384, 152);
            dataGridAddresses.TabIndex = 20;
            // 
            // lbProdValidity
            // 
            lbProdValidity.AutoSize = true;
            lbProdValidity.BorderStyle = BorderStyle.FixedSingle;
            lbProdValidity.Location = new Point(12, 146);
            lbProdValidity.Name = "lbProdValidity";
            lbProdValidity.Size = new Size(53, 17);
            lbProdValidity.TabIndex = 21;
            lbProdValidity.Text = "Validade";
            // 
            // lbProdValidityInfo
            // 
            lbProdValidityInfo.AutoSize = true;
            lbProdValidityInfo.BorderStyle = BorderStyle.Fixed3D;
            lbProdValidityInfo.Location = new Point(71, 146);
            lbProdValidityInfo.Name = "lbProdValidityInfo";
            lbProdValidityInfo.Size = new Size(67, 17);
            lbProdValidityInfo.TabIndex = 22;
            lbProdValidityInfo.Text = "00/00/0000";
            // 
            // ProductInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 354);
            Controls.Add(lbProdValidityInfo);
            Controls.Add(lbProdValidity);
            Controls.Add(dataGridAddresses);
            Controls.Add(lbAddresses);
            Controls.Add(lbProdAmountInfo);
            Controls.Add(lbProdMeasureInfo);
            Controls.Add(lbProdBrandInfo);
            Controls.Add(lbProdCodeInfo);
            Controls.Add(lbProdNameInfo);
            Controls.Add(lbProdMeasure);
            Controls.Add(lbProdAmount);
            Controls.Add(lbProdBrand);
            Controls.Add(lbProdCode);
            Controls.Add(lbProdName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ProductInfoForm";
            Text = "Nome do produto";
            ((System.ComponentModel.ISupportInitialize)dataGridAddresses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbProdName;
        private Label lbProdMeasure;
        private Label lbProdAmount;
        private Label lbProdBrand;
        private Label lbProdCode;
        private Label lbProdNameInfo;
        private Label lbProdCodeInfo;
        private Label lbProdBrandInfo;
        private Label lbProdMeasureInfo;
        private Label lbProdAmountInfo;
        private Label lbAddresses;
        private DataGridView dataGridAddresses;
        private Label lbProdValidity;
        private Label lbProdValidityInfo;
    }
}