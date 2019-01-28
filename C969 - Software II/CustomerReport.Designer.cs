namespace C969___Software_II
{
    partial class CustomerReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerReportView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerReportView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customers with Appointments";
            // 
            // customerReportView
            // 
            this.customerReportView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerReportView.Location = new System.Drawing.Point(55, 92);
            this.customerReportView.Name = "customerReportView";
            this.customerReportView.Size = new System.Drawing.Size(464, 323);
            this.customerReportView.TabIndex = 1;
            // 
            // CustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 462);
            this.Controls.Add(this.customerReportView);
            this.Controls.Add(this.label1);
            this.Name = "CustomerReport";
            this.Text = "CustomerReport";
            ((System.ComponentModel.ISupportInitialize)(this.customerReportView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView customerReportView;
    }
}