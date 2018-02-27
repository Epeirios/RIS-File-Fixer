namespace WindowsFormsApp1
{
    partial class Form1
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.cbxProcessMethod = new System.Windows.Forms.ComboBox();
            this.cbxSpaceBetweenRecord = new System.Windows.Forms.CheckBox();
            this.cbxSpaceInRecord = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(260, 311);
            this.treeView.TabIndex = 0;
            // 
            // cbxProcessMethod
            // 
            this.cbxProcessMethod.Enabled = false;
            this.cbxProcessMethod.FormattingEnabled = true;
            this.cbxProcessMethod.Location = new System.Drawing.Point(278, 12);
            this.cbxProcessMethod.Name = "cbxProcessMethod";
            this.cbxProcessMethod.Size = new System.Drawing.Size(170, 21);
            this.cbxProcessMethod.TabIndex = 1;
            // 
            // cbxSpaceBetweenRecord
            // 
            this.cbxSpaceBetweenRecord.AutoSize = true;
            this.cbxSpaceBetweenRecord.Location = new System.Drawing.Point(278, 254);
            this.cbxSpaceBetweenRecord.Name = "cbxSpaceBetweenRecord";
            this.cbxSpaceBetweenRecord.Size = new System.Drawing.Size(172, 17);
            this.cbxSpaceBetweenRecord.TabIndex = 2;
            this.cbxSpaceBetweenRecord.Text = "Allow Space between Records";
            this.cbxSpaceBetweenRecord.UseVisualStyleBackColor = true;
            this.cbxSpaceBetweenRecord.Visible = false;
            // 
            // cbxSpaceInRecord
            // 
            this.cbxSpaceInRecord.AutoSize = true;
            this.cbxSpaceInRecord.Location = new System.Drawing.Point(278, 277);
            this.cbxSpaceInRecord.Name = "cbxSpaceInRecord";
            this.cbxSpaceInRecord.Size = new System.Drawing.Size(158, 17);
            this.cbxSpaceInRecord.TabIndex = 3;
            this.cbxSpaceInRecord.Text = "Allow Space whitin Records";
            this.cbxSpaceInRecord.UseVisualStyleBackColor = true;
            this.cbxSpaceInRecord.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(278, 300);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import .ris file";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(454, 300);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(454, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 335);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbxSpaceInRecord);
            this.Controls.Add(this.cbxSpaceBetweenRecord);
            this.Controls.Add(this.cbxProcessMethod);
            this.Controls.Add(this.treeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox cbxProcessMethod;
        private System.Windows.Forms.CheckBox cbxSpaceBetweenRecord;
        private System.Windows.Forms.CheckBox cbxSpaceInRecord;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnProcess;
    }
}

