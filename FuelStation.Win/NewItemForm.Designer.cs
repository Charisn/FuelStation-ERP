namespace FuelStation.Win
{
    partial class NewItemForm
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
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.PriceEdit = new DevExpress.XtraEditors.SpinEdit();
            this.CostEdit = new DevExpress.XtraEditors.SpinEdit();
            this.lblItemType = new DevExpress.XtraEditors.LabelControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblCost = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloseItem = new DevExpress.XtraEditors.SimpleButton();
            this.bsItem = new System.Windows.Forms.BindingSource(this.components);
            this.comboItemType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 430);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(780, 25);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 451);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(781, 25);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 430);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(780, 25);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 20);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCode.EditValue = "";
            this.txtCode.Location = new System.Drawing.Point(102, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(219, 20);
            this.txtCode.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCode.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Location = new System.Drawing.Point(66, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(31, 14);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescription.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Appearance.Options.UseFont = true;
            this.lblDescription.Location = new System.Drawing.Point(34, 54);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 14);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription.EditValue = "";
            this.txtDescription.Location = new System.Drawing.Point(102, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(219, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // PriceEdit
            // 
            this.PriceEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PriceEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PriceEdit.Location = new System.Drawing.Point(102, 106);
            this.PriceEdit.Name = "PriceEdit";
            this.PriceEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PriceEdit.Size = new System.Drawing.Size(104, 20);
            this.PriceEdit.TabIndex = 5;
            // 
            // CostEdit
            // 
            this.CostEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CostEdit.Location = new System.Drawing.Point(102, 132);
            this.CostEdit.Name = "CostEdit";
            this.CostEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CostEdit.Size = new System.Drawing.Size(104, 20);
            this.CostEdit.TabIndex = 6;
            // 
            // lblItemType
            // 
            this.lblItemType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemType.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItemType.Appearance.Options.UseFont = true;
            this.lblItemType.Location = new System.Drawing.Point(42, 82);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(56, 14);
            this.lblItemType.TabIndex = 7;
            this.lblItemType.Text = "ItemType";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrice.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Appearance.Options.UseFont = true;
            this.lblPrice.Location = new System.Drawing.Point(66, 109);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(30, 14);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Price";
            // 
            // lblCost
            // 
            this.lblCost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCost.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCost.Appearance.Options.UseFont = true;
            this.lblCost.Location = new System.Drawing.Point(66, 135);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(28, 14);
            this.lblCost.TabIndex = 9;
            this.lblCost.Text = "Cost";
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveItem.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveItem.Appearance.Options.UseFont = true;
            this.btnSaveItem.Location = new System.Drawing.Point(42, 173);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(121, 40);
            this.btnSaveItem.TabIndex = 10;
            this.btnSaveItem.Text = "Save Item";
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // btnCloseItem
            // 
            this.btnCloseItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseItem.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCloseItem.Appearance.Options.UseFont = true;
            this.btnCloseItem.Location = new System.Drawing.Point(198, 173);
            this.btnCloseItem.Name = "btnCloseItem";
            this.btnCloseItem.Size = new System.Drawing.Size(123, 40);
            this.btnCloseItem.TabIndex = 11;
            this.btnCloseItem.Text = "Close";
            this.btnCloseItem.Click += new System.EventHandler(this.btnCloseItem_Click);
            // 
            // comboItemType
            // 
            this.comboItemType.FormattingEnabled = true;
            this.comboItemType.Location = new System.Drawing.Point(102, 78);
            this.comboItemType.Name = "comboItemType";
            this.comboItemType.Size = new System.Drawing.Size(219, 23);
            this.comboItemType.TabIndex = 12;
            // 
            // NewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(389, 226);
            this.Controls.Add(this.comboItemType);
            this.Controls.Add(this.btnCloseItem);
            this.Controls.Add(this.btnSaveItem);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.CostEdit);
            this.Controls.Add(this.PriceEdit);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Item";
            this.Load += new System.EventHandler(this.NewItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.SpinEdit PriceEdit;
        private DevExpress.XtraEditors.SpinEdit CostEdit;
        private DevExpress.XtraEditors.LabelControl lblItemType;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.LabelControl lblCost;
        private DevExpress.XtraEditors.SimpleButton btnSaveItem;
        private DevExpress.XtraEditors.SimpleButton btnCloseItem;
        private BindingSource bsItem;
        private ComboBox comboItemType;
    }
}