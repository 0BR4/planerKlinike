namespace DiplomskiPlanerKlinike
{
    partial class FormListaPacijenata
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
            this.buttonPlanerLogout = new System.Windows.Forms.Button();
            this.panelSelectPagesListPat = new System.Windows.Forms.Panel();
            this.buttonSelectPagesListPat = new System.Windows.Forms.Button();
            this.buttonClinicStatisticListPat = new System.Windows.Forms.Button();
            this.buttonListDoctorsListPat = new System.Windows.Forms.Button();
            this.buttonListPatientsScheduler = new System.Windows.Forms.Button();
            this.dataGridViewPatients = new System.Windows.Forms.DataGridView();
            this.labelListPatName = new System.Windows.Forms.Label();
            this.textBoxListPatName = new System.Windows.Forms.TextBox();
            this.textBoxListPatID = new System.Windows.Forms.TextBox();
            this.labelListPatID = new System.Windows.Forms.Label();
            this.checkBoxExam = new System.Windows.Forms.CheckBox();
            this.checkBoxLab = new System.Windows.Forms.CheckBox();
            this.checkBoxTherapy = new System.Windows.Forms.CheckBox();
            this.checkBoxOperation = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckup = new System.Windows.Forms.CheckBox();
            this.panelSelectPagesListPat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlanerLogout
            // 
            this.buttonPlanerLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPlanerLogout.Location = new System.Drawing.Point(165, 12);
            this.buttonPlanerLogout.Name = "buttonPlanerLogout";
            this.buttonPlanerLogout.Size = new System.Drawing.Size(136, 42);
            this.buttonPlanerLogout.TabIndex = 47;
            this.buttonPlanerLogout.Text = "Log out";
            this.buttonPlanerLogout.UseVisualStyleBackColor = true;
            this.buttonPlanerLogout.Click += new System.EventHandler(this.buttonPlanerLogout_Click);
            // 
            // panelSelectPagesListPat
            // 
            this.panelSelectPagesListPat.Controls.Add(this.buttonSelectPagesListPat);
            this.panelSelectPagesListPat.Controls.Add(this.buttonClinicStatisticListPat);
            this.panelSelectPagesListPat.Controls.Add(this.buttonListDoctorsListPat);
            this.panelSelectPagesListPat.Controls.Add(this.buttonListPatientsScheduler);
            this.panelSelectPagesListPat.Location = new System.Drawing.Point(13, 12);
            this.panelSelectPagesListPat.Name = "panelSelectPagesListPat";
            this.panelSelectPagesListPat.Size = new System.Drawing.Size(136, 42);
            this.panelSelectPagesListPat.TabIndex = 46;
            // 
            // buttonSelectPagesListPat
            // 
            this.buttonSelectPagesListPat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectPagesListPat.Location = new System.Drawing.Point(0, 0);
            this.buttonSelectPagesListPat.Name = "buttonSelectPagesListPat";
            this.buttonSelectPagesListPat.Size = new System.Drawing.Size(136, 42);
            this.buttonSelectPagesListPat.TabIndex = 0;
            this.buttonSelectPagesListPat.Text = "Pages";
            this.buttonSelectPagesListPat.UseVisualStyleBackColor = true;
            this.buttonSelectPagesListPat.Click += new System.EventHandler(this.buttonSelectPagesListPat_Click);
            // 
            // buttonClinicStatisticListPat
            // 
            this.buttonClinicStatisticListPat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClinicStatisticListPat.Location = new System.Drawing.Point(0, 117);
            this.buttonClinicStatisticListPat.Name = "buttonClinicStatisticListPat";
            this.buttonClinicStatisticListPat.Size = new System.Drawing.Size(136, 42);
            this.buttonClinicStatisticListPat.TabIndex = 3;
            this.buttonClinicStatisticListPat.Text = "Clinic statistics";
            this.buttonClinicStatisticListPat.UseVisualStyleBackColor = true;
            this.buttonClinicStatisticListPat.Click += new System.EventHandler(this.buttonClinicStatisticListPat_Click);
            // 
            // buttonListDoctorsListPat
            // 
            this.buttonListDoctorsListPat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonListDoctorsListPat.Location = new System.Drawing.Point(0, 78);
            this.buttonListDoctorsListPat.Name = "buttonListDoctorsListPat";
            this.buttonListDoctorsListPat.Size = new System.Drawing.Size(136, 42);
            this.buttonListDoctorsListPat.TabIndex = 2;
            this.buttonListDoctorsListPat.Text = "List of doctors";
            this.buttonListDoctorsListPat.UseVisualStyleBackColor = true;
            this.buttonListDoctorsListPat.Click += new System.EventHandler(this.buttonListDoctorsListPat_Click);
            // 
            // buttonListPatientsScheduler
            // 
            this.buttonListPatientsScheduler.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonListPatientsScheduler.Location = new System.Drawing.Point(0, 39);
            this.buttonListPatientsScheduler.Name = "buttonListPatientsScheduler";
            this.buttonListPatientsScheduler.Size = new System.Drawing.Size(136, 42);
            this.buttonListPatientsScheduler.TabIndex = 1;
            this.buttonListPatientsScheduler.Text = "Scheduler";
            this.buttonListPatientsScheduler.UseVisualStyleBackColor = true;
            this.buttonListPatientsScheduler.Click += new System.EventHandler(this.buttonListPatientsScheduler_Click);
            // 
            // dataGridViewPatients
            // 
            this.dataGridViewPatients.AllowUserToAddRows = false;
            this.dataGridViewPatients.AllowUserToDeleteRows = false;
            this.dataGridViewPatients.AllowUserToOrderColumns = true;
            this.dataGridViewPatients.AllowUserToResizeColumns = false;
            this.dataGridViewPatients.AllowUserToResizeRows = false;
            this.dataGridViewPatients.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatients.Location = new System.Drawing.Point(251, 90);
            this.dataGridViewPatients.Name = "dataGridViewPatients";
            this.dataGridViewPatients.ReadOnly = true;
            this.dataGridViewPatients.RowHeadersVisible = false;
            this.dataGridViewPatients.Size = new System.Drawing.Size(895, 498);
            this.dataGridViewPatients.TabIndex = 49;
            // 
            // labelListPatName
            // 
            this.labelListPatName.AutoSize = true;
            this.labelListPatName.Location = new System.Drawing.Point(25, 178);
            this.labelListPatName.Name = "labelListPatName";
            this.labelListPatName.Size = new System.Drawing.Size(38, 13);
            this.labelListPatName.TabIndex = 50;
            this.labelListPatName.Text = "Name:";
            // 
            // textBoxListPatName
            // 
            this.textBoxListPatName.Location = new System.Drawing.Point(88, 178);
            this.textBoxListPatName.Name = "textBoxListPatName";
            this.textBoxListPatName.Size = new System.Drawing.Size(144, 20);
            this.textBoxListPatName.TabIndex = 51;
            this.textBoxListPatName.TextChanged += new System.EventHandler(this.textBoxListDocName_TextChanged);
            // 
            // textBoxListPatID
            // 
            this.textBoxListPatID.Location = new System.Drawing.Point(88, 218);
            this.textBoxListPatID.Name = "textBoxListPatID";
            this.textBoxListPatID.Size = new System.Drawing.Size(144, 20);
            this.textBoxListPatID.TabIndex = 53;
            this.textBoxListPatID.TextChanged += new System.EventHandler(this.textBoxListPatID_TextChanged);
            // 
            // labelListPatID
            // 
            this.labelListPatID.AutoSize = true;
            this.labelListPatID.Location = new System.Drawing.Point(25, 218);
            this.labelListPatID.Name = "labelListPatID";
            this.labelListPatID.Size = new System.Drawing.Size(21, 13);
            this.labelListPatID.TabIndex = 52;
            this.labelListPatID.Text = "ID:";
            // 
            // checkBoxExam
            // 
            this.checkBoxExam.AutoSize = true;
            this.checkBoxExam.Location = new System.Drawing.Point(28, 264);
            this.checkBoxExam.Name = "checkBoxExam";
            this.checkBoxExam.Size = new System.Drawing.Size(182, 17);
            this.checkBoxExam.TabIndex = 54;
            this.checkBoxExam.Text = "Show those who did Examination";
            this.checkBoxExam.UseVisualStyleBackColor = true;
            this.checkBoxExam.CheckedChanged += new System.EventHandler(this.checkBoxChecked_CheckedChanged);
            // 
            // checkBoxLab
            // 
            this.checkBoxLab.AutoSize = true;
            this.checkBoxLab.Location = new System.Drawing.Point(28, 296);
            this.checkBoxLab.Name = "checkBoxLab";
            this.checkBoxLab.Size = new System.Drawing.Size(175, 17);
            this.checkBoxLab.TabIndex = 55;
            this.checkBoxLab.Text = "Show those who did Laboratory";
            this.checkBoxLab.UseVisualStyleBackColor = true;
            this.checkBoxLab.CheckedChanged += new System.EventHandler(this.checkBoxLab_CheckedChanged);
            // 
            // checkBoxTherapy
            // 
            this.checkBoxTherapy.AutoSize = true;
            this.checkBoxTherapy.Location = new System.Drawing.Point(28, 329);
            this.checkBoxTherapy.Name = "checkBoxTherapy";
            this.checkBoxTherapy.Size = new System.Drawing.Size(164, 17);
            this.checkBoxTherapy.TabIndex = 56;
            this.checkBoxTherapy.Text = "Show those who did Therapy";
            this.checkBoxTherapy.UseVisualStyleBackColor = true;
            this.checkBoxTherapy.CheckedChanged += new System.EventHandler(this.checkBoxTherapy_CheckedChanged);
            // 
            // checkBoxOperation
            // 
            this.checkBoxOperation.AutoSize = true;
            this.checkBoxOperation.Location = new System.Drawing.Point(28, 361);
            this.checkBoxOperation.Name = "checkBoxOperation";
            this.checkBoxOperation.Size = new System.Drawing.Size(171, 17);
            this.checkBoxOperation.TabIndex = 57;
            this.checkBoxOperation.Text = "Show those who did Operation";
            this.checkBoxOperation.UseVisualStyleBackColor = true;
            this.checkBoxOperation.CheckedChanged += new System.EventHandler(this.checkBoxOperation_CheckedChanged);
            // 
            // checkBoxCheckup
            // 
            this.checkBoxCheckup.AutoSize = true;
            this.checkBoxCheckup.Location = new System.Drawing.Point(28, 396);
            this.checkBoxCheckup.Name = "checkBoxCheckup";
            this.checkBoxCheckup.Size = new System.Drawing.Size(171, 17);
            this.checkBoxCheckup.TabIndex = 58;
            this.checkBoxCheckup.Text = "Show those who did Check-up";
            this.checkBoxCheckup.UseVisualStyleBackColor = true;
            this.checkBoxCheckup.CheckedChanged += new System.EventHandler(this.checkBoxCheckup_CheckedChanged);
            // 
            // FormListaPacijenata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 600);
            this.Controls.Add(this.checkBoxCheckup);
            this.Controls.Add(this.checkBoxOperation);
            this.Controls.Add(this.checkBoxTherapy);
            this.Controls.Add(this.checkBoxLab);
            this.Controls.Add(this.checkBoxExam);
            this.Controls.Add(this.textBoxListPatID);
            this.Controls.Add(this.labelListPatID);
            this.Controls.Add(this.textBoxListPatName);
            this.Controls.Add(this.labelListPatName);
            this.Controls.Add(this.dataGridViewPatients);
            this.Controls.Add(this.buttonPlanerLogout);
            this.Controls.Add(this.panelSelectPagesListPat);
            this.Name = "FormListaPacijenata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListaPacijenata";
            this.Load += new System.EventHandler(this.FormListaPacijenata_Load);
            this.panelSelectPagesListPat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlanerLogout;
        private System.Windows.Forms.Panel panelSelectPagesListPat;
        private System.Windows.Forms.Button buttonSelectPagesListPat;
        private System.Windows.Forms.Button buttonClinicStatisticListPat;
        private System.Windows.Forms.Button buttonListDoctorsListPat;
        private System.Windows.Forms.Button buttonListPatientsScheduler;
        private System.Windows.Forms.DataGridView dataGridViewPatients;
        private System.Windows.Forms.Label labelListPatName;
        private System.Windows.Forms.TextBox textBoxListPatName;
        private System.Windows.Forms.TextBox textBoxListPatID;
        private System.Windows.Forms.Label labelListPatID;
        private System.Windows.Forms.CheckBox checkBoxExam;
        private System.Windows.Forms.CheckBox checkBoxLab;
        private System.Windows.Forms.CheckBox checkBoxTherapy;
        private System.Windows.Forms.CheckBox checkBoxOperation;
        private System.Windows.Forms.CheckBox checkBoxCheckup;
    }
}