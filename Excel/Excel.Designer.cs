namespace Excel
{
    partial class Excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Excel));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.addColumnBtn = new System.Windows.Forms.Button();
            this.deleteColumnBtn = new System.Windows.Forms.Button();
            this.deleteRowBtn = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.columnsLabel = new System.Windows.Forms.Label();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.enterBtn = new System.Windows.Forms.Button();
            this.textboxPanel = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableContainer = new System.Windows.Forms.DataGridView();
            this.menu.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.textboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1332, 38);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip2";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked_1);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem,
            this.saveItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(81, 34);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // openItem
            // 
            this.openItem.Image = ((System.Drawing.Image)(resources.GetObject("openItem.Image")));
            this.openItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openItem.Name = "openItem";
            this.openItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openItem.Size = new System.Drawing.Size(284, 38);
            this.openItem.Text = "&Відкрити";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // saveItem
            // 
            this.saveItem.Image = ((System.Drawing.Image)(resources.GetObject("saveItem.Image")));
            this.saveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveItem.Name = "saveItem";
            this.saveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveItem.Size = new System.Drawing.Size(284, 38);
            this.saveItem.Text = "&Зберегти";
            this.saveItem.Click += new System.EventHandler(this.saveItem_Click);
            // 
            // helpItem
            // 
            this.helpItem.Name = "helpItem";
            this.helpItem.Size = new System.Drawing.Size(108, 34);
            this.helpItem.Text = "&Довідка";
            this.helpItem.Click += new System.EventHandler(this.helpItem_Click);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.addColumnBtn);
            this.controlsPanel.Controls.Add(this.deleteColumnBtn);
            this.controlsPanel.Controls.Add(this.deleteRowBtn);
            this.controlsPanel.Controls.Add(this.addRowBtn);
            this.controlsPanel.Controls.Add(this.columnsLabel);
            this.controlsPanel.Controls.Add(this.rowsLabel);
            this.controlsPanel.Controls.Add(this.enterBtn);
            this.controlsPanel.Controls.Add(this.textboxPanel);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsPanel.Location = new System.Drawing.Point(0, 38);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(1332, 63);
            this.controlsPanel.TabIndex = 3;
            // 
            // addColumnBtn
            // 
            this.addColumnBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addColumnBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addColumnBtn.Location = new System.Drawing.Point(1189, 16);
            this.addColumnBtn.Name = "addColumnBtn";
            this.addColumnBtn.Size = new System.Drawing.Size(42, 34);
            this.addColumnBtn.TabIndex = 5;
            this.addColumnBtn.Text = "+";
            this.addColumnBtn.UseVisualStyleBackColor = false;
            this.addColumnBtn.Click += new System.EventHandler(this.addColumnBtn_Click);
            // 
            // deleteColumnBtn
            // 
            this.deleteColumnBtn.BackColor = System.Drawing.SystemColors.Control;
            this.deleteColumnBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteColumnBtn.Location = new System.Drawing.Point(1237, 17);
            this.deleteColumnBtn.Name = "deleteColumnBtn";
            this.deleteColumnBtn.Size = new System.Drawing.Size(43, 34);
            this.deleteColumnBtn.TabIndex = 6;
            this.deleteColumnBtn.Text = "-";
            this.deleteColumnBtn.UseVisualStyleBackColor = false;
            this.deleteColumnBtn.Click += new System.EventHandler(this.deleteColumnBtn_Click);
            // 
            // deleteRowBtn
            // 
            this.deleteRowBtn.BackColor = System.Drawing.SystemColors.Control;
            this.deleteRowBtn.Font = new System.Drawing.Font("Yu Gothic UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.deleteRowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteRowBtn.Location = new System.Drawing.Point(995, 16);
            this.deleteRowBtn.Name = "deleteRowBtn";
            this.deleteRowBtn.Size = new System.Drawing.Size(43, 34);
            this.deleteRowBtn.TabIndex = 6;
            this.deleteRowBtn.Text = "-";
            this.deleteRowBtn.UseVisualStyleBackColor = false;
            this.deleteRowBtn.Click += new System.EventHandler(this.deleteRowBtn_Click);
            // 
            // addRowBtn
            // 
            this.addRowBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addRowBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addRowBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addRowBtn.Location = new System.Drawing.Point(947, 16);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(42, 34);
            this.addRowBtn.TabIndex = 5;
            this.addRowBtn.Text = "+";
            this.addRowBtn.UseVisualStyleBackColor = false;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.columnsLabel.Location = new System.Drawing.Point(1060, 18);
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(123, 30);
            this.columnsLabel.TabIndex = 4;
            this.columnsLabel.Text = "Стовпчики";
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rowsLabel.Location = new System.Drawing.Point(869, 18);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(72, 30);
            this.rowsLabel.TabIndex = 3;
            this.rowsLabel.Text = "Рядки";
            // 
            // enterBtn
            // 
            this.enterBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.enterBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.enterBtn.FlatAppearance.BorderSize = 3;
            this.enterBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enterBtn.Location = new System.Drawing.Point(701, 17);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(112, 34);
            this.enterBtn.TabIndex = 2;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = false;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // textboxPanel
            // 
            this.textboxPanel.Controls.Add(this.textBox);
            this.textboxPanel.Location = new System.Drawing.Point(0, 0);
            this.textboxPanel.Name = "textboxPanel";
            this.textboxPanel.Padding = new System.Windows.Forms.Padding(0, 15, 1, 0);
            this.textboxPanel.Size = new System.Drawing.Size(704, 63);
            this.textboxPanel.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(20, 14);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(660, 37);
            this.textBox.TabIndex = 0;
            // 
            // tableContainer
            // 
            this.tableContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableContainer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableContainer.Location = new System.Drawing.Point(0, 107);
            this.tableContainer.MultiSelect = false;
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.ReadOnly = true;
            this.tableContainer.RowHeadersWidth = 62;
            this.tableContainer.Size = new System.Drawing.Size(1332, 667);
            this.tableContainer.TabIndex = 4;
            this.tableContainer.Text = "dataGridView1";
            this.tableContainer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableContainer_CellClick);
            // 
            // Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 777);
            this.Controls.Add(this.tableContainer);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.menu);
            this.Name = "Excel";
            this.Text = "Excel";
            this.Load += new System.EventHandler(this.Excel_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.textboxPanel.ResumeLayout(false);
            this.textboxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem helpItem;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Panel textboxPanel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.DataGridView tableContainer;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Button addColumnBtn;
        private System.Windows.Forms.Button deleteColumnBtn;
        private System.Windows.Forms.Button deleteRowBtn;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Label columnsLabel;
        private System.Windows.Forms.Label rowsLabel;
    }
}