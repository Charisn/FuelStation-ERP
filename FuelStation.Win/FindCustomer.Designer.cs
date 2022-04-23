namespace FuelStation.Win
{
    partial class FindCustomer
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
            this.components = new System.ComponentModel.Container();
            this.comboCustomerCard = new System.Windows.Forms.ComboBox();
            this.CustomerCard = new System.Windows.Forms.Label();
            this.btnFindCard = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackToList = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bsFindCus = new System.Windows.Forms.BindingSource(this.components);
            this.comboName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsFindCus)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCustomerCard
            // 
            this.comboCustomerCard.FormattingEnabled = true;
            this.comboCustomerCard.Location = new System.Drawing.Point(14, 11);
            this.comboCustomerCard.Name = "comboCustomerCard";
            this.comboCustomerCard.Size = new System.Drawing.Size(221, 22);
            this.comboCustomerCard.TabIndex = 0;
            this.comboCustomerCard.SelectedIndexChanged += new System.EventHandler(this.comboCustomerCard_SelectedIndexChanged);
            // 
            // CustomerCard
            // 
            this.CustomerCard.AutoSize = true;
            this.CustomerCard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CustomerCard.Location = new System.Drawing.Point(14, 78);
            this.CustomerCard.Name = "CustomerCard";
            this.CustomerCard.Size = new System.Drawing.Size(129, 14);
            this.CustomerCard.TabIndex = 2;
            this.CustomerCard.Text = "Type Customer Card";
            // 
            // btnFindCard
            // 
            this.btnFindCard.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFindCard.Appearance.Options.UseFont = true;
            this.btnFindCard.Location = new System.Drawing.Point(14, 133);
            this.btnFindCard.Name = "btnFindCard";
            this.btnFindCard.Size = new System.Drawing.Size(102, 36);
            this.btnFindCard.TabIndex = 3;
            this.btnFindCard.Text = "OKAY";
            this.btnFindCard.Click += new System.EventHandler(this.btnFindCard_Click);
            // 
            // btnBackToList
            // 
            this.btnBackToList.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackToList.Appearance.Options.UseFont = true;
            this.btnBackToList.Location = new System.Drawing.Point(134, 133);
            this.btnBackToList.Name = "btnBackToList";
            this.btnBackToList.Size = new System.Drawing.Size(102, 36);
            this.btnBackToList.TabIndex = 4;
            this.btnBackToList.Text = "BACK TO LIST";
            this.btnBackToList.Click += new System.EventHandler(this.btnBackToList_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 21);
            this.textBox1.TabIndex = 5;
            // 
            // comboName
            // 
            this.comboName.FormattingEnabled = true;
            this.comboName.Location = new System.Drawing.Point(16, 54);
            this.comboName.Name = "comboName";
            this.comboName.Size = new System.Drawing.Size(219, 22);
            this.comboName.TabIndex = 6;
            this.comboName.SelectedIndexChanged += new System.EventHandler(this.comboName_SelectedIndexChanged);
            // 
            // FindCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(255, 175);
            this.ControlBox = false;
            this.Controls.Add(this.comboName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBackToList);
            this.Controls.Add(this.btnFindCard);
            this.Controls.Add(this.CustomerCard);
            this.Controls.Add(this.comboCustomerCard);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindCustomer";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Card";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FindCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsFindCus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboCustomerCard;
        private Label CustomerCard;
        private DevExpress.XtraEditors.SimpleButton btnFindCard;
        private DevExpress.XtraEditors.SimpleButton btnBackToList;
        private TextBox textBox1;
        private BindingSource bsFindCus;
        private ComboBox comboName;
    }
}