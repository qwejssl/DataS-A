namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StylesDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.SortOptionsComboBox = new System.Windows.Forms.ComboBox();
            this.SortDirectionComboBox = new System.Windows.Forms.ComboBox();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.DeleteRowButton = new System.Windows.Forms.Button();
            this.CalculatePriceButton = new System.Windows.Forms.Button();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StylesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StylesDataGridView
            // 
            this.StylesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StylesDataGridView.Location = new System.Drawing.Point(8, 8);
            this.StylesDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StylesDataGridView.Name = "StylesDataGridView";
            this.StylesDataGridView.RowHeadersWidth = 82;
            this.StylesDataGridView.RowTemplate.Height = 33;
            this.StylesDataGridView.Size = new System.Drawing.Size(1191, 410);
            this.StylesDataGridView.TabIndex = 0;
            this.StylesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.StylesDataGridView_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 439);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(252, 437);
            this.IDBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(173, 22);
            this.IDBox.TabIndex = 11;
            // 
            // SortOptionsComboBox
            // 
            this.SortOptionsComboBox.FormattingEnabled = true;
            this.SortOptionsComboBox.Items.AddRange(new object[] {
            "Type",
            "Color",
            "ID",
            "Price",
            "Size"});
            this.SortOptionsComboBox.Location = new System.Drawing.Point(1059, 439);
            this.SortOptionsComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SortOptionsComboBox.Name = "SortOptionsComboBox";
            this.SortOptionsComboBox.Size = new System.Drawing.Size(137, 24);
            this.SortOptionsComboBox.TabIndex = 19;
            // 
            // SortDirectionComboBox
            // 
            this.SortDirectionComboBox.FormattingEnabled = true;
            this.SortDirectionComboBox.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.SortDirectionComboBox.Location = new System.Drawing.Point(1059, 483);
            this.SortDirectionComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SortDirectionComboBox.Name = "SortDirectionComboBox";
            this.SortDirectionComboBox.Size = new System.Drawing.Size(137, 24);
            this.SortDirectionComboBox.TabIndex = 20;
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(449, 439);
            this.AddRowButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(81, 26);
            this.AddRowButton.TabIndex = 21;
            this.AddRowButton.Text = "Add Row";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(1059, 528);
            this.SortButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(135, 29);
            this.SortButton.TabIndex = 22;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // DeleteRowButton
            // 
            this.DeleteRowButton.Location = new System.Drawing.Point(546, 437);
            this.DeleteRowButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteRowButton.Name = "DeleteRowButton";
            this.DeleteRowButton.Size = new System.Drawing.Size(135, 29);
            this.DeleteRowButton.TabIndex = 24;
            this.DeleteRowButton.Text = "Delete Row";
            this.DeleteRowButton.UseVisualStyleBackColor = true;
            this.DeleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // CalculatePriceButton
            // 
            this.CalculatePriceButton.Location = new System.Drawing.Point(17, 483);
            this.CalculatePriceButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CalculatePriceButton.Name = "CalculatePriceButton";
            this.CalculatePriceButton.Size = new System.Drawing.Size(135, 29);
            this.CalculatePriceButton.TabIndex = 25;
            this.CalculatePriceButton.Text = "Calculate Price";
            this.CalculatePriceButton.UseVisualStyleBackColor = true;
            this.CalculatePriceButton.Click += new System.EventHandler(this.CalculatePriceButton_Click);
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(54, 437);
            this.SizeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(137, 22);
            this.SizeBox.TabIndex = 26;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(14, 439);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(33, 16);
            this.label44.TabIndex = 27;
            this.label44.Text = "Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 589);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.CalculatePriceButton);
            this.Controls.Add(this.DeleteRowButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.SortDirectionComboBox);
            this.Controls.Add(this.SortOptionsComboBox);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StylesDataGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.StylesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StylesDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.ComboBox SortOptionsComboBox;
        private System.Windows.Forms.ComboBox SortDirectionComboBox;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button DeleteRowButton;
        private System.Windows.Forms.Button CalculatePriceButton;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.Label label44;
    }
}

