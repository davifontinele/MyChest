namespace MyChest.Forms
{
    partial class ProductInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfo));
            lbProdName = new Label();
            lbProdMeasure = new Label();
            lbProdAmount = new Label();
            lbProdBrand = new Label();
            lbProdCode = new Label();
            SuspendLayout();
            // 
            // lbProdName
            // 
            lbProdName.AutoSize = true;
            lbProdName.BorderStyle = BorderStyle.Fixed3D;
            lbProdName.Location = new Point(12, 9);
            lbProdName.Name = "lbProdName";
            lbProdName.Size = new Size(105, 17);
            lbProdName.TabIndex = 4;
            lbProdName.Text = "Nome do produto";
            // 
            // lbProdMeasure
            // 
            lbProdMeasure.AutoSize = true;
            lbProdMeasure.BorderStyle = BorderStyle.Fixed3D;
            lbProdMeasure.Location = new Point(12, 111);
            lbProdMeasure.Name = "lbProdMeasure";
            lbProdMeasure.Size = new Size(49, 17);
            lbProdMeasure.TabIndex = 10;
            lbProdMeasure.Text = "Medida";
            // 
            // lbProdAmount
            // 
            lbProdAmount.AutoSize = true;
            lbProdAmount.BorderStyle = BorderStyle.Fixed3D;
            lbProdAmount.Location = new Point(12, 145);
            lbProdAmount.Name = "lbProdAmount";
            lbProdAmount.Size = new Size(27, 17);
            lbProdAmount.TabIndex = 9;
            lbProdAmount.Text = "000";
            // 
            // lbProdBrand
            // 
            lbProdBrand.AutoSize = true;
            lbProdBrand.BorderStyle = BorderStyle.Fixed3D;
            lbProdBrand.Location = new Point(12, 77);
            lbProdBrand.Name = "lbProdBrand";
            lbProdBrand.Size = new Size(42, 17);
            lbProdBrand.TabIndex = 8;
            lbProdBrand.Text = "Marca";
            // 
            // lbProdCode
            // 
            lbProdCode.AutoSize = true;
            lbProdCode.BorderStyle = BorderStyle.Fixed3D;
            lbProdCode.Location = new Point(12, 43);
            lbProdCode.Name = "lbProdCode";
            lbProdCode.Size = new Size(33, 17);
            lbProdCode.TabIndex = 7;
            lbProdCode.Text = "0000";
            // 
            // ProductInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 241);
            Controls.Add(lbProdMeasure);
            Controls.Add(lbProdAmount);
            Controls.Add(lbProdBrand);
            Controls.Add(lbProdCode);
            Controls.Add(lbProdName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProductInfo";
            Text = "Detalhes do Produto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbProdName;
        private Label lbProdMeasure;
        private Label lbProdAmount;
        private Label lbProdBrand;
        private Label lbProdCode;
    }
}