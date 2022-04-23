namespace FuelStation.Win
{
    partial class NewTransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTransactionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.spinNetPrice = new DevExpress.XtraEditors.SpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.spinDiscountPercent = new DevExpress.XtraEditors.SpinEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.spinDiscountValue = new DevExpress.XtraEditors.SpinEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.CustCard = new System.Windows.Forms.Label();
            this.bsTline = new System.Windows.Forms.BindingSource(this.components);
            this.grdTLine = new DevExpress.XtraGrid.GridControl();
            this.grvTLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this.bsTransaction = new System.Windows.Forms.BindingSource(this.components);
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.bsTLines = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddLine = new DevExpress.XtraEditors.SimpleButton();
            this.spinTotal = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPay = new System.Windows.Forms.ComboBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.spinQty = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinNetPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiscountPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiscountValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQty.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Customer";
            // 
            // comboEmployee
            // 
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(81, 10);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(138, 23);
            this.comboEmployee.TabIndex = 8;
            // 
            // spinNetPrice
            // 
            this.spinNetPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinNetPrice.Location = new System.Drawing.Point(105, 49);
            this.spinNetPrice.Name = "spinNetPrice";
            this.spinNetPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinNetPrice.Size = new System.Drawing.Size(114, 20);
            this.spinNetPrice.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Net Price";
            // 
            // spinDiscountPercent
            // 
            this.spinDiscountPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spinDiscountPercent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDiscountPercent.Location = new System.Drawing.Point(351, 11);
            this.spinDiscountPercent.Name = "spinDiscountPercent";
            this.spinDiscountPercent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinDiscountPercent.Size = new System.Drawing.Size(61, 20);
            this.spinDiscountPercent.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Discount%";
            // 
            // spinDiscountValue
            // 
            this.spinDiscountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spinDiscountValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDiscountValue.Location = new System.Drawing.Point(341, 50);
            this.spinDiscountValue.Name = "spinDiscountValue";
            this.spinDiscountValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinDiscountValue.Size = new System.Drawing.Size(81, 20);
            this.spinDiscountValue.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Discount Value";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(573, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "A-1804220892731209";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.Location = new System.Drawing.Point(465, 131);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(125, 50);
            this.simpleButton1.TabIndex = 22;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Location = new System.Drawing.Point(597, 131);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(125, 50);
            this.simpleButton2.TabIndex = 23;
            this.simpleButton2.Text = "Exit";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // CustCard
            // 
            this.CustCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CustCard.AutoSize = true;
            this.CustCard.Location = new System.Drawing.Point(457, 24);
            this.CustCard.Name = "CustCard";
            this.CustCard.Size = new System.Drawing.Size(117, 15);
            this.CustCard.TabIndex = 26;
            this.CustCard.Text = "Customers Card:";
            // 
            // grdTLine
            // 
            this.grdTLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdTLine.BackgroundImage")));
            this.grdTLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdTLine.Location = new System.Drawing.Point(0, 182);
            this.grdTLine.MainView = this.grvTLine;
            this.grdTLine.Name = "grdTLine";
            this.grdTLine.Size = new System.Drawing.Size(735, 302);
            this.grdTLine.TabIndex = 29;
            this.grdTLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTLine});
            // 
            // grvTLine
            // 
            this.grvTLine.GridControl = this.grdTLine;
            this.grvTLine.Name = "grvTLine";
            this.grvTLine.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTLine_CellValueChanged);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtCustomer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomer.Location = new System.Drawing.Point(531, 48);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(173, 22);
            this.txtCustomer.TabIndex = 30;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDate.Location = new System.Drawing.Point(531, 77);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(174, 20);
            this.txtDate.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(489, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Date";
            // 
            // btnAddLine
            // 
            this.btnAddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLine.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddLine.Appearance.Options.UseFont = true;
            this.btnAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLine.Location = new System.Drawing.Point(7, 131);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(97, 50);
            this.btnAddLine.TabIndex = 28;
            this.btnAddLine.Text = "ADD";
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // spinTotal
            // 
            this.spinTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinTotal.Location = new System.Drawing.Point(284, 156);
            this.spinTotal.Name = "spinTotal";
            this.spinTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinTotal.Size = new System.Drawing.Size(138, 20);
            this.spinTotal.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Payment Method";
            // 
            // comboPay
            // 
            this.comboPay.FormattingEnabled = true;
            this.comboPay.Location = new System.Drawing.Point(284, 110);
            this.comboPay.Name = "comboPay";
            this.comboPay.Size = new System.Drawing.Size(138, 23);
            this.comboPay.TabIndex = 37;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton3.Location = new System.Drawing.Point(122, 131);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(97, 50);
            this.simpleButton3.TabIndex = 38;
            this.simpleButton3.Text = "Delete";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // spinQty
            // 
            this.spinQty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinQty.Location = new System.Drawing.Point(119, 77);
            this.spinQty.Name = "spinQty";
            this.spinQty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinQty.Size = new System.Drawing.Size(100, 20);
            this.spinQty.TabIndex = 39;
            this.spinQty.EditValueChanged += new System.EventHandler(this.spinQty_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(64, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 14);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "Quantity";
            // 
            // NewTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(735, 484);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spinQty);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.comboPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spinTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.grdTLine);
            this.Controls.Add(this.btnAddLine);
            this.Controls.Add(this.CustCard);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.spinDiscountValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.spinDiscountPercent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spinNetPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewTransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewTransaction";
            this.Load += new System.EventHandler(this.NewTransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinNetPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiscountPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiscountValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinQty.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private ComboBox comboEmployee;
        private DevExpress.XtraEditors.SpinEdit spinNetPrice;
        private Label label5;
        private DevExpress.XtraEditors.SpinEdit spinDiscountPercent;
        private Label label6;
        private DevExpress.XtraEditors.SpinEdit spinDiscountValue;
        private Label label8;
        private Label label9;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private Label CustCard;
        private BindingSource bsTline;
        private DevExpress.XtraGrid.GridControl grdTLine;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTLine;
        private TextBox txtCustomer;
        private BindingSource bsItems;
        private BindingSource bsTransaction;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private Label label11;
        private BindingSource bsTLines;
        private DevExpress.XtraEditors.SimpleButton btnAddLine;
        private DevExpress.XtraEditors.SpinEdit spinTotal;
        private Label label3;
        private Label label4;
        private ComboBox comboPay;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SpinEdit spinQty;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}