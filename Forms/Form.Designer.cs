namespace Военный_округ_Final_
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.lblSlPage = new System.Windows.Forms.Label();
            this.btnSlNextPage = new System.Windows.Forms.Button();
            this.btnSlPreviousPage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTable);
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 63);
            this.panel1.TabIndex = 2;
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(195, 17);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(217, 24);
            this.cbTable.TabIndex = 88;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(821, 13);
            this.btnList.Margin = new System.Windows.Forms.Padding(4);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(205, 28);
            this.btnList.TabIndex = 87;
            this.btnList.Text = "Прочитать из БД";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1199, 546);
            this.panel2.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1199, 546);
            this.dgv.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveChanges);
            this.panel3.Controls.Add(this.lblPage);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPreviousPage);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.lblSlPage);
            this.panel3.Controls.Add(this.btnSlNextPage);
            this.panel3.Controls.Add(this.btnSlPreviousPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 546);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1199, 63);
            this.panel3.TabIndex = 4;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(895, 12);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 28);
            this.btnSaveChanges.TabIndex = 86;
            this.btnSaveChanges.Text = "Сохранить";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(573, 23);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(0, 17);
            this.lblPage.TabIndex = 85;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(644, 20);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 84;
            this.btnNextPage.Text = "->";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(479, 20);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 83;
            this.btnPreviousPage.Text = "<-";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(666, 106);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 17);
            this.label26.TabIndex = 82;
            // 
            // lblSlPage
            // 
            this.lblSlPage.AutoSize = true;
            this.lblSlPage.Location = new System.Drawing.Point(657, 103);
            this.lblSlPage.Name = "lblSlPage";
            this.lblSlPage.Size = new System.Drawing.Size(0, 17);
            this.lblSlPage.TabIndex = 81;
            // 
            // btnSlNextPage
            // 
            this.btnSlNextPage.Location = new System.Drawing.Point(725, 100);
            this.btnSlNextPage.Name = "btnSlNextPage";
            this.btnSlNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnSlNextPage.TabIndex = 80;
            this.btnSlNextPage.Text = "->";
            this.btnSlNextPage.UseVisualStyleBackColor = true;
            // 
            // btnSlPreviousPage
            // 
            this.btnSlPreviousPage.Location = new System.Drawing.Point(560, 100);
            this.btnSlPreviousPage.Name = "btnSlPreviousPage";
            this.btnSlPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnSlPreviousPage.TabIndex = 79;
            this.btnSlPreviousPage.Text = "<-";
            this.btnSlPreviousPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Просмотр и редактирование";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblSlPage;
        private System.Windows.Forms.Button btnSlNextPage;
        private System.Windows.Forms.Button btnSlPreviousPage;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.ComboBox cbTable;
    }
}

