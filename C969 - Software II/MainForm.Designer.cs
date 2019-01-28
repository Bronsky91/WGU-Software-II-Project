namespace C969___Software_II
{
    partial class MainForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.createCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.appointmentCalendar = new System.Windows.Forms.DataGridView();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.addAppointment = new System.Windows.Forms.Button();
            this.updateAppointment = new System.Windows.Forms.Button();
            this.deleteAppointment = new System.Windows.Forms.Button();
            this.numberOfApps = new System.Windows.Forms.Button();
            this.userSchedules = new System.Windows.Forms.Button();
            this.customerReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(298, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(118, 26);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Acces";
            // 
            // createCustomerButton
            // 
            this.createCustomerButton.Location = new System.Drawing.Point(74, 136);
            this.createCustomerButton.Name = "createCustomerButton";
            this.createCustomerButton.Size = new System.Drawing.Size(81, 23);
            this.createCustomerButton.TabIndex = 2;
            this.createCustomerButton.Text = "Create";
            this.createCustomerButton.UseVisualStyleBackColor = true;
            this.createCustomerButton.Click += new System.EventHandler(this.createCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Location = new System.Drawing.Point(74, 184);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(81, 23);
            this.updateCustomerButton.TabIndex = 3;
            this.updateCustomerButton.Text = "Update";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(74, 233);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(81, 23);
            this.deleteCustomerButton.TabIndex = 4;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appointment Calendar";
            // 
            // appointmentCalendar
            // 
            this.appointmentCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentCalendar.Location = new System.Drawing.Point(419, 171);
            this.appointmentCalendar.Name = "appointmentCalendar";
            this.appointmentCalendar.Size = new System.Drawing.Size(452, 177);
            this.appointmentCalendar.TabIndex = 6;
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Location = new System.Drawing.Point(525, 134);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(80, 17);
            this.weekRadioButton.TabIndex = 7;
            this.weekRadioButton.Text = "Week View";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            this.weekRadioButton.CheckedChanged += new System.EventHandler(this.weekRadioButton_CheckedChanged);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Checked = true;
            this.monthRadioButton.Location = new System.Drawing.Point(644, 134);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(81, 17);
            this.monthRadioButton.TabIndex = 8;
            this.monthRadioButton.TabStop = true;
            this.monthRadioButton.Text = "Month View";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reports";
            // 
            // addAppointment
            // 
            this.addAppointment.Location = new System.Drawing.Point(488, 377);
            this.addAppointment.Name = "addAppointment";
            this.addAppointment.Size = new System.Drawing.Size(75, 23);
            this.addAppointment.TabIndex = 10;
            this.addAppointment.Text = "Add";
            this.addAppointment.UseVisualStyleBackColor = true;
            this.addAppointment.Click += new System.EventHandler(this.addAppointment_Click);
            // 
            // updateAppointment
            // 
            this.updateAppointment.Location = new System.Drawing.Point(599, 377);
            this.updateAppointment.Name = "updateAppointment";
            this.updateAppointment.Size = new System.Drawing.Size(75, 23);
            this.updateAppointment.TabIndex = 11;
            this.updateAppointment.Text = "Update";
            this.updateAppointment.UseVisualStyleBackColor = true;
            this.updateAppointment.Click += new System.EventHandler(this.updateAppointment_Click);
            // 
            // deleteAppointment
            // 
            this.deleteAppointment.Location = new System.Drawing.Point(704, 377);
            this.deleteAppointment.Name = "deleteAppointment";
            this.deleteAppointment.Size = new System.Drawing.Size(75, 23);
            this.deleteAppointment.TabIndex = 12;
            this.deleteAppointment.Text = "Delete";
            this.deleteAppointment.UseVisualStyleBackColor = true;
            this.deleteAppointment.Click += new System.EventHandler(this.deleteAppointment_Click);
            // 
            // numberOfApps
            // 
            this.numberOfApps.Location = new System.Drawing.Point(227, 133);
            this.numberOfApps.Name = "numberOfApps";
            this.numberOfApps.Size = new System.Drawing.Size(148, 23);
            this.numberOfApps.TabIndex = 13;
            this.numberOfApps.Text = "Number of Appointments";
            this.numberOfApps.UseVisualStyleBackColor = true;
            this.numberOfApps.Click += new System.EventHandler(this.numberOfApps_Click);
            // 
            // userSchedules
            // 
            this.userSchedules.Location = new System.Drawing.Point(227, 184);
            this.userSchedules.Name = "userSchedules";
            this.userSchedules.Size = new System.Drawing.Size(148, 23);
            this.userSchedules.TabIndex = 14;
            this.userSchedules.Text = "Consultant Schedules";
            this.userSchedules.UseVisualStyleBackColor = true;
            this.userSchedules.Click += new System.EventHandler(this.userSchedules_Click);
            // 
            // customerReport
            // 
            this.customerReport.Location = new System.Drawing.Point(227, 233);
            this.customerReport.Name = "customerReport";
            this.customerReport.Size = new System.Drawing.Size(148, 23);
            this.customerReport.TabIndex = 15;
            this.customerReport.Text = "Customer Report";
            this.customerReport.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 454);
            this.Controls.Add(this.customerReport);
            this.Controls.Add(this.userSchedules);
            this.Controls.Add(this.numberOfApps);
            this.Controls.Add(this.deleteAppointment);
            this.Controls.Add(this.updateAppointment);
            this.Controls.Add(this.addAppointment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.appointmentCalendar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.createCustomerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "MainForm";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView appointmentCalendar;
        private System.Windows.Forms.RadioButton weekRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addAppointment;
        private System.Windows.Forms.Button updateAppointment;
        private System.Windows.Forms.Button deleteAppointment;
        private System.Windows.Forms.Button numberOfApps;
        private System.Windows.Forms.Button userSchedules;
        private System.Windows.Forms.Button customerReport;
    }
}