using MyChest.Data.DAO;
using MyChest.Extensions;
using MyChest.Models;
using System.Text.RegularExpressions;

namespace MyChest.Forms
{
    partial class ReceiptProductForm
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

        private void ReceiptNewProduct()
        {
            if (Regex.IsMatch(txtBoxProductName.Text, "^[a-zA-Z]+$") || Regex.IsMatch(txtBoxProductBrand.Text, "^[a-zA-Z]+$"))
            {
                try
                {
                    ProductDAO productDAO = new ProductDAO();
                    productDAO.InsertProduct(new Models.Product(
                        txtBoxProductId.Text.ConvertToInt32(),
                        txtBoxProductName.Text.ToUpper(),
                        txtBoxProductBrand.Text.ToUpper(),
                        txtBoxProductAmount.Text.ConvertToInt32(),
                        "",
                        comboBoxProductMeasure.SelectedValue.ToString(),
                        DateOnly.Parse(dateTimeProductValidityPicker.Text)));
                    productDAO.InsertProductTags(txtBoxProductId.Text.ConvertToInt32(), checkBoxProductTags.CheckedItems.Cast<Tag>().ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Erro ao inserir produto: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nome do produto ou marca inválido. Use apenas letras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadProductTags()
        {
            checkBoxProductTags.Items.Clear();
            ProductDAO productDAO = new ProductDAO();
            foreach (var tag in productDAO.GetTags())
            {
                checkBoxProductTags.Items.Add(tag, false);
            }
        }

        private void LoadMeasureUnits()
        {
            comboBoxProductMeasure.Items.Clear();
            ProductDAO productDAO = new ProductDAO();
            comboBoxProductMeasure.DataSource = new BindingSource(productDAO.GetMeasures(), null);
            comboBoxProductMeasure.DisplayMember = "Value";
            comboBoxProductMeasure.ValueMember = "Key";
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptProductForm));
            lbProductName = new Label();
            lbProductId = new Label();
            lbProductBrand = new Label();
            txtBoxProductBrand = new TextBox();
            txtBoxProductName = new TextBox();
            txtBoxProductId = new TextBox();
            txtBoxProductAmount = new TextBox();
            lbProductAmount = new Label();
            comboBoxProductMeasure = new ComboBox();
            lbProductMeasure = new Label();
            btnConfirmReceipt = new Button();
            label1 = new Label();
            checkBoxProductTags = new CheckedListBox();
            lbProductValidity = new Label();
            dateTimeProductValidityPicker = new DateTimePicker();
            SuspendLayout();
            // 
            // lbProductName
            // 
            lbProductName.AutoSize = true;
            lbProductName.BorderStyle = BorderStyle.FixedSingle;
            lbProductName.Location = new Point(181, 9);
            lbProductName.Name = "lbProductName";
            lbProductName.Size = new Size(105, 17);
            lbProductName.TabIndex = 5;
            lbProductName.Text = "Nome do produto";
            // 
            // lbProductId
            // 
            lbProductId.AutoSize = true;
            lbProductId.BorderStyle = BorderStyle.FixedSingle;
            lbProductId.Location = new Point(12, 9);
            lbProductId.Name = "lbProductId";
            lbProductId.Size = new Size(48, 17);
            lbProductId.TabIndex = 13;
            lbProductId.Text = "Código";
            // 
            // lbProductBrand
            // 
            lbProductBrand.AutoSize = true;
            lbProductBrand.BorderStyle = BorderStyle.FixedSingle;
            lbProductBrand.Location = new Point(12, 49);
            lbProductBrand.Name = "lbProductBrand";
            lbProductBrand.Size = new Size(42, 17);
            lbProductBrand.TabIndex = 14;
            lbProductBrand.Text = "Marca";
            // 
            // txtBoxProductBrand
            // 
            txtBoxProductBrand.Location = new Point(60, 46);
            txtBoxProductBrand.Name = "txtBoxProductBrand";
            txtBoxProductBrand.Size = new Size(109, 23);
            txtBoxProductBrand.TabIndex = 15;
            // 
            // txtBoxProductName
            // 
            txtBoxProductName.Location = new Point(292, 6);
            txtBoxProductName.Name = "txtBoxProductName";
            txtBoxProductName.Size = new Size(109, 23);
            txtBoxProductName.TabIndex = 16;
            // 
            // txtBoxProductId
            // 
            txtBoxProductId.Location = new Point(66, 6);
            txtBoxProductId.Name = "txtBoxProductId";
            txtBoxProductId.Size = new Size(109, 23);
            txtBoxProductId.TabIndex = 17;
            // 
            // txtBoxProductAmount
            // 
            txtBoxProductAmount.Location = new Point(258, 49);
            txtBoxProductAmount.Name = "txtBoxProductAmount";
            txtBoxProductAmount.Size = new Size(109, 23);
            txtBoxProductAmount.TabIndex = 20;
            // 
            // lbProductAmount
            // 
            lbProductAmount.AutoSize = true;
            lbProductAmount.BorderStyle = BorderStyle.FixedSingle;
            lbProductAmount.Location = new Point(181, 52);
            lbProductAmount.Name = "lbProductAmount";
            lbProductAmount.Size = new Size(71, 17);
            lbProductAmount.TabIndex = 19;
            lbProductAmount.Text = "Quantidade";
            // 
            // comboBoxProductMeasure
            // 
            comboBoxProductMeasure.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductMeasure.FormattingEnabled = true;
            comboBoxProductMeasure.Location = new Point(484, 6);
            comboBoxProductMeasure.Name = "comboBoxProductMeasure";
            comboBoxProductMeasure.Size = new Size(121, 23);
            comboBoxProductMeasure.TabIndex = 21;
            // 
            // lbProductMeasure
            // 
            lbProductMeasure.AutoSize = true;
            lbProductMeasure.BorderStyle = BorderStyle.FixedSingle;
            lbProductMeasure.Location = new Point(407, 9);
            lbProductMeasure.Name = "lbProductMeasure";
            lbProductMeasure.Size = new Size(69, 17);
            lbProductMeasure.TabIndex = 23;
            lbProductMeasure.Text = "Un/Medida";
            // 
            // btnConfirmReceipt
            // 
            btnConfirmReceipt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnConfirmReceipt.Location = new Point(12, 139);
            btnConfirmReceipt.Name = "btnConfirmReceipt";
            btnConfirmReceipt.Size = new Size(75, 23);
            btnConfirmReceipt.TabIndex = 24;
            btnConfirmReceipt.Text = "Confirmar";
            btnConfirmReceipt.UseVisualStyleBackColor = true;
            btnConfirmReceipt.Click += btnConfirmReceipt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(373, 52);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 26;
            label1.Text = "Tags";
            // 
            // checkBoxProductTags
            // 
            checkBoxProductTags.FormattingEnabled = true;
            checkBoxProductTags.Location = new Point(411, 52);
            checkBoxProductTags.Name = "checkBoxProductTags";
            checkBoxProductTags.Size = new Size(194, 112);
            checkBoxProductTags.TabIndex = 27;
            // 
            // lbProductValidity
            // 
            lbProductValidity.AutoSize = true;
            lbProductValidity.BorderStyle = BorderStyle.FixedSingle;
            lbProductValidity.Location = new Point(12, 83);
            lbProductValidity.Name = "lbProductValidity";
            lbProductValidity.Size = new Size(53, 17);
            lbProductValidity.TabIndex = 28;
            lbProductValidity.Text = "Validade";
            // 
            // dateTimeProductValidityPicker
            // 
            dateTimeProductValidityPicker.CustomFormat = "";
            dateTimeProductValidityPicker.Format = DateTimePickerFormat.Short;
            dateTimeProductValidityPicker.Location = new Point(71, 80);
            dateTimeProductValidityPicker.Name = "dateTimeProductValidityPicker";
            dateTimeProductValidityPicker.Size = new Size(98, 23);
            dateTimeProductValidityPicker.TabIndex = 29;
            // 
            // ReceiptProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(622, 174);
            Controls.Add(dateTimeProductValidityPicker);
            Controls.Add(lbProductValidity);
            Controls.Add(checkBoxProductTags);
            Controls.Add(label1);
            Controls.Add(btnConfirmReceipt);
            Controls.Add(lbProductMeasure);
            Controls.Add(comboBoxProductMeasure);
            Controls.Add(txtBoxProductAmount);
            Controls.Add(lbProductAmount);
            Controls.Add(txtBoxProductId);
            Controls.Add(txtBoxProductName);
            Controls.Add(txtBoxProductBrand);
            Controls.Add(lbProductBrand);
            Controls.Add(lbProductId);
            Controls.Add(lbProductName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceiptProductForm";
            Text = "Recebimento";
            Load += ReceiptProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbProductName;
        private Label lbProductId;
        private Label lbProductBrand;
        private TextBox txtBoxProductBrand;
        private TextBox txtBoxProductName;
        private TextBox txtBoxProductId;
        private TextBox txtBoxProductAmount;
        private Label lbProductAmount;
        private ComboBox comboBoxProductMeasure;
        private Label lbProductMeasure;
        private Button btnConfirmReceipt;
        private Label label1;
        private CheckedListBox checkBoxProductTags;
        private Label lbProductValidity;
        private DateTimePicker dateTimeProductValidityPicker;
    }
}