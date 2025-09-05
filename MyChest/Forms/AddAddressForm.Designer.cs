using MyChest.Data.DAO;
using MyChest.Extensions;
using MyChest.Interfaces;
using MyChest.Models;

namespace MyChest.Forms
{
    partial class AddAddressForm
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

        private void LoadProductsInComboBoxProducts()
        {
            ProductDAO productDAO = new ProductDAO();
            comboBoxProducts.Items.Clear();
            var products = productDAO.GetProductsWithoutAddress();
            foreach (var product in products)
            {
                comboBoxProducts.Items.Add($"{product.Code}-{product.Name}");
            }
        }

        private void AddNewAddress()
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Preencha todos os campos corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ProductDAO productDAO = new ProductDAO();
                Address address = new Address
                {
                    Corridor = txtBoxCorridor.Text.ConvertToInt32(),
                    Column = txtBoxColumn.Text.ConvertToInt32(),
                    Level = txtBoxLevel.Text.ConvertToInt32(),
                    Hall = txtBoxHall.Text.ConvertToInt32(),
                    ProductCode = comboBoxProducts.SelectedItem != null ? Convert.ToInt32(comboBoxProducts.SelectedItem.ToString().Split('-')[0]) : null
                };

                AddressDAO addressDAO = new AddressDAO();
                addressDAO.InsertNewAddress(address);

                ClearFields();
            }
        }
        private bool ValidateFields()
        {
            return txtBoxCorridor.Text.TestConvertToInt32() && txtBoxColumn.Text.TestConvertToInt32() && txtBoxHall.Text.TestConvertToInt32() && txtBoxLevel.Text.TestConvertToInt32();
        }

        private void ClearFields()
        {
            txtBoxCorridor.Clear();
            txtBoxColumn.Clear();
            txtBoxLevel.Clear();
            txtBoxHall.Clear();
            comboBoxProducts.SelectedIndex = -1;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAddressForm));
            lbCorridor = new Label();
            txtBoxCorridor = new TextBox();
            txtBoxColumn = new TextBox();
            lbColumn = new Label();
            txtBoxLevel = new TextBox();
            lbLevel = new Label();
            txtBoxHall = new TextBox();
            lbHall = new Label();
            lbProduct = new Label();
            comboBoxProducts = new ComboBox();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // lbCorridor
            // 
            lbCorridor.AutoSize = true;
            lbCorridor.BorderStyle = BorderStyle.FixedSingle;
            lbCorridor.Location = new Point(38, 9);
            lbCorridor.Name = "lbCorridor";
            lbCorridor.Size = new Size(56, 17);
            lbCorridor.TabIndex = 14;
            lbCorridor.Text = "Corredor";
            // 
            // txtBoxCorridor
            // 
            txtBoxCorridor.Location = new Point(12, 29);
            txtBoxCorridor.Name = "txtBoxCorridor";
            txtBoxCorridor.Size = new Size(109, 23);
            txtBoxCorridor.TabIndex = 18;
            txtBoxCorridor.TextChanged += txtBoxCorridor_TextChanged;
            // 
            // txtBoxColumn
            // 
            txtBoxColumn.Location = new Point(127, 29);
            txtBoxColumn.Name = "txtBoxColumn";
            txtBoxColumn.Size = new Size(109, 23);
            txtBoxColumn.TabIndex = 20;
            txtBoxColumn.TextChanged += txtBoxColumn_TextChanged;
            // 
            // lbColumn
            // 
            lbColumn.AutoSize = true;
            lbColumn.BorderStyle = BorderStyle.FixedSingle;
            lbColumn.Location = new Point(158, 9);
            lbColumn.Name = "lbColumn";
            lbColumn.Size = new Size(47, 17);
            lbColumn.TabIndex = 19;
            lbColumn.Text = "Coluna";
            // 
            // txtBoxLevel
            // 
            txtBoxLevel.Location = new Point(242, 29);
            txtBoxLevel.Name = "txtBoxLevel";
            txtBoxLevel.Size = new Size(109, 23);
            txtBoxLevel.TabIndex = 22;
            txtBoxLevel.TextChanged += txtBoxLevel_TextChanged;
            // 
            // lbLevel
            // 
            lbLevel.AutoSize = true;
            lbLevel.BorderStyle = BorderStyle.FixedSingle;
            lbLevel.Location = new Point(278, 9);
            lbLevel.Name = "lbLevel";
            lbLevel.Size = new Size(36, 17);
            lbLevel.TabIndex = 21;
            lbLevel.Text = "Nivel";
            // 
            // txtBoxHall
            // 
            txtBoxHall.Location = new Point(357, 29);
            txtBoxHall.Name = "txtBoxHall";
            txtBoxHall.Size = new Size(109, 23);
            txtBoxHall.TabIndex = 24;
            txtBoxHall.TextChanged += textBox1_TextChanged;
            // 
            // lbHall
            // 
            lbHall.AutoSize = true;
            lbHall.BorderStyle = BorderStyle.FixedSingle;
            lbHall.Location = new Point(397, 9);
            lbHall.Name = "lbHall";
            lbHall.Size = new Size(28, 17);
            lbHall.TabIndex = 23;
            lbHall.Text = "Vão";
            // 
            // lbProduct
            // 
            lbProduct.AutoSize = true;
            lbProduct.BorderStyle = BorderStyle.FixedSingle;
            lbProduct.Location = new Point(533, 9);
            lbProduct.Name = "lbProduct";
            lbProduct.Size = new Size(52, 17);
            lbProduct.TabIndex = 25;
            lbProduct.Text = "Produto";
            // 
            // comboBoxProducts
            // 
            comboBoxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProducts.FormattingEnabled = true;
            comboBoxProducts.Items.AddRange(new object[] { "TESTE" });
            comboBoxProducts.Location = new Point(472, 29);
            comboBoxProducts.Name = "comboBoxProducts";
            comboBoxProducts.Size = new Size(175, 23);
            comboBoxProducts.TabIndex = 26;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConfirm.Location = new Point(12, 108);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 27;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // AddAddressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(659, 143);
            Controls.Add(btnConfirm);
            Controls.Add(comboBoxProducts);
            Controls.Add(lbProduct);
            Controls.Add(txtBoxHall);
            Controls.Add(lbHall);
            Controls.Add(txtBoxLevel);
            Controls.Add(lbLevel);
            Controls.Add(txtBoxColumn);
            Controls.Add(lbColumn);
            Controls.Add(txtBoxCorridor);
            Controls.Add(lbCorridor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddAddressForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Endereço";
            Load += AddAddressForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCorridor;
        private TextBox txtBoxCorridor;
        private TextBox txtBoxColumn;
        private Label lbColumn;
        private TextBox txtBoxLevel;
        private Label lbLevel;
        private TextBox txtBoxHall;
        private Label lbHall;
        private TextBox textBox2;
        private Label lbProduct;
        private ComboBox comboBoxProducts;
        private Button btnConfirm;
    }
}