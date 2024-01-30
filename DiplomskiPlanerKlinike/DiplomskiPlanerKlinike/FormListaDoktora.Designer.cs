namespace DiplomskiPlanerKlinike
{
    partial class FormListaDoktora
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
            this.panelSelectPagesListDoc = new System.Windows.Forms.Panel();
            this.buttonSelectPagesListDoc = new System.Windows.Forms.Button();
            this.buttonClinicStatisticListDoc = new System.Windows.Forms.Button();
            this.buttonSchedulerListDoc = new System.Windows.Forms.Button();
            this.buttonListPatientsListDoc = new System.Windows.Forms.Button();
            this.textBoxListDocName = new System.Windows.Forms.TextBox();
            this.labelListDocName = new System.Windows.Forms.Label();
            this.dataGridViewDoctors = new System.Windows.Forms.DataGridView();
            this.textBoxListDocSpec = new System.Windows.Forms.TextBox();
            this.labelListDocSpec = new System.Windows.Forms.Label();
            this.textBoxListDocID = new System.Windows.Forms.TextBox();
            this.labelListDocID = new System.Windows.Forms.Label();
            this.checkBoxSurgery = new System.Windows.Forms.CheckBox();
            this.panelSelectPagesListDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlanerLogout
            // 
            this.buttonPlanerLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPlanerLogout.Location = new System.Drawing.Point(164, 12);
            this.buttonPlanerLogout.Name = "buttonPlanerLogout";
            this.buttonPlanerLogout.Size = new System.Drawing.Size(136, 42);
            this.buttonPlanerLogout.TabIndex = 47;
            this.buttonPlanerLogout.Text = "Log out";
            this.buttonPlanerLogout.UseVisualStyleBackColor = true;
            this.buttonPlanerLogout.Click += new System.EventHandler(this.buttonPlanerLogout_Click);
            // 
            // panelSelectPagesListDoc
            // 
            this.panelSelectPagesListDoc.Controls.Add(this.buttonSelectPagesListDoc);
            this.panelSelectPagesListDoc.Controls.Add(this.buttonClinicStatisticListDoc);
            this.panelSelectPagesListDoc.Controls.Add(this.buttonSchedulerListDoc);
            this.panelSelectPagesListDoc.Controls.Add(this.buttonListPatientsListDoc);
            this.panelSelectPagesListDoc.Location = new System.Drawing.Point(12, 12);
            this.panelSelectPagesListDoc.Name = "panelSelectPagesListDoc";
            this.panelSelectPagesListDoc.Size = new System.Drawing.Size(136, 42);
            this.panelSelectPagesListDoc.TabIndex = 46;
            // 
            // buttonSelectPagesListDoc
            // 
            this.buttonSelectPagesListDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectPagesListDoc.Location = new System.Drawing.Point(0, 0);
            this.buttonSelectPagesListDoc.Name = "buttonSelectPagesListDoc";
            this.buttonSelectPagesListDoc.Size = new System.Drawing.Size(136, 42);
            this.buttonSelectPagesListDoc.TabIndex = 0;
            this.buttonSelectPagesListDoc.Text = "Pages";
            this.buttonSelectPagesListDoc.UseVisualStyleBackColor = true;
            this.buttonSelectPagesListDoc.Click += new System.EventHandler(this.buttonSelectPagesListDoc_Click);
            // 
            // buttonClinicStatisticListDoc
            // 
            this.buttonClinicStatisticListDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClinicStatisticListDoc.Location = new System.Drawing.Point(0, 117);
            this.buttonClinicStatisticListDoc.Name = "buttonClinicStatisticListDoc";
            this.buttonClinicStatisticListDoc.Size = new System.Drawing.Size(136, 42);
            this.buttonClinicStatisticListDoc.TabIndex = 3;
            this.buttonClinicStatisticListDoc.Text = "Clinic statistics";
            this.buttonClinicStatisticListDoc.UseVisualStyleBackColor = true;
            this.buttonClinicStatisticListDoc.Click += new System.EventHandler(this.buttonClinicStatisticListDoc_Click);
            // 
            // buttonSchedulerListDoc
            // 
            this.buttonSchedulerListDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSchedulerListDoc.Location = new System.Drawing.Point(0, 38);
            this.buttonSchedulerListDoc.Name = "buttonSchedulerListDoc";
            this.buttonSchedulerListDoc.Size = new System.Drawing.Size(136, 42);
            this.buttonSchedulerListDoc.TabIndex = 2;
            this.buttonSchedulerListDoc.Text = "Scheduler";
            this.buttonSchedulerListDoc.UseVisualStyleBackColor = true;
            this.buttonSchedulerListDoc.Click += new System.EventHandler(this.buttonSchedulerListDoc_Click);
            // 
            // buttonListPatientsListDoc
            // 
            this.buttonListPatientsListDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonListPatientsListDoc.Location = new System.Drawing.Point(0, 77);
            this.buttonListPatientsListDoc.Name = "buttonListPatientsListDoc";
            this.buttonListPatientsListDoc.Size = new System.Drawing.Size(136, 42);
            this.buttonListPatientsListDoc.TabIndex = 1;
            this.buttonListPatientsListDoc.Text = "List of patients";
            this.buttonListPatientsListDoc.UseVisualStyleBackColor = true;
            this.buttonListPatientsListDoc.Click += new System.EventHandler(this.buttonListPatientsListDoc_Click);
            // 
            // textBoxListDocName
            // 
            this.textBoxListDocName.Location = new System.Drawing.Point(131, 175);
            this.textBoxListDocName.Name = "textBoxListDocName";
            this.textBoxListDocName.Size = new System.Drawing.Size(144, 20);
            this.textBoxListDocName.TabIndex = 54;
            this.textBoxListDocName.TextChanged += new System.EventHandler(this.textBoxListDocName_TextChanged);
            // 
            // labelListDocName
            // 
            this.labelListDocName.AutoSize = true;
            this.labelListDocName.Location = new System.Drawing.Point(25, 178);
            this.labelListDocName.Name = "labelListDocName";
            this.labelListDocName.Size = new System.Drawing.Size(38, 13);
            this.labelListDocName.TabIndex = 53;
            this.labelListDocName.Text = "Name:";
            // 
            // dataGridViewDoctors
            // 
            this.dataGridViewDoctors.AllowUserToAddRows = false;
            this.dataGridViewDoctors.AllowUserToDeleteRows = false;
            this.dataGridViewDoctors.AllowUserToOrderColumns = true;
            this.dataGridViewDoctors.AllowUserToResizeColumns = false;
            this.dataGridViewDoctors.AllowUserToResizeRows = false;
            this.dataGridViewDoctors.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDoctors.Location = new System.Drawing.Point(324, 98);
            this.dataGridViewDoctors.Name = "dataGridViewDoctors";
            this.dataGridViewDoctors.ReadOnly = true;
            this.dataGridViewDoctors.RowHeadersVisible = false;
            this.dataGridViewDoctors.Size = new System.Drawing.Size(537, 474);
            this.dataGridViewDoctors.TabIndex = 52;
            // 
            // textBoxListDocSpec
            // 
            this.textBoxListDocSpec.Location = new System.Drawing.Point(131, 222);
            this.textBoxListDocSpec.Name = "textBoxListDocSpec";
            this.textBoxListDocSpec.Size = new System.Drawing.Size(144, 20);
            this.textBoxListDocSpec.TabIndex = 56;
            this.textBoxListDocSpec.TextChanged += new System.EventHandler(this.textBoxListDocSpec_TextChanged);
            // 
            // labelListDocSpec
            // 
            this.labelListDocSpec.AutoSize = true;
            this.labelListDocSpec.Location = new System.Drawing.Point(25, 225);
            this.labelListDocSpec.Name = "labelListDocSpec";
            this.labelListDocSpec.Size = new System.Drawing.Size(75, 13);
            this.labelListDocSpec.TabIndex = 55;
            this.labelListDocSpec.Text = "Specialization:";
            // 
            // textBoxListDocID
            // 
            this.textBoxListDocID.Location = new System.Drawing.Point(131, 129);
            this.textBoxListDocID.Name = "textBoxListDocID";
            this.textBoxListDocID.Size = new System.Drawing.Size(144, 20);
            this.textBoxListDocID.TabIndex = 58;
            this.textBoxListDocID.TextChanged += new System.EventHandler(this.textBoxListDocID_TextChanged);
            // 
            // labelListDocID
            // 
            this.labelListDocID.AutoSize = true;
            this.labelListDocID.Location = new System.Drawing.Point(25, 132);
            this.labelListDocID.Name = "labelListDocID";
            this.labelListDocID.Size = new System.Drawing.Size(21, 13);
            this.labelListDocID.TabIndex = 57;
            this.labelListDocID.Text = "ID:";
            // 
            // checkBoxSurgery
            // 
            this.checkBoxSurgery.AutoSize = true;
            this.checkBoxSurgery.Location = new System.Drawing.Point(28, 276);
            this.checkBoxSurgery.Name = "checkBoxSurgery";
            this.checkBoxSurgery.Size = new System.Drawing.Size(180, 17);
            this.checkBoxSurgery.TabIndex = 59;
            this.checkBoxSurgery.Text = "Show those who can do Surgery";
            this.checkBoxSurgery.UseVisualStyleBackColor = true;
            this.checkBoxSurgery.CheckedChanged += new System.EventHandler(this.checkBoxSurgery_CheckedChanged);
            // 
            // FormListaDoktora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 600);
            this.Controls.Add(this.checkBoxSurgery);
            this.Controls.Add(this.textBoxListDocID);
            this.Controls.Add(this.labelListDocID);
            this.Controls.Add(this.textBoxListDocSpec);
            this.Controls.Add(this.labelListDocSpec);
            this.Controls.Add(this.textBoxListDocName);
            this.Controls.Add(this.labelListDocName);
            this.Controls.Add(this.dataGridViewDoctors);
            this.Controls.Add(this.buttonPlanerLogout);
            this.Controls.Add(this.panelSelectPagesListDoc);
            this.Name = "FormListaDoktora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormListaDoktora";
            this.Load += new System.EventHandler(this.FormListaDoktora_Load);
            this.panelSelectPagesListDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlanerLogout;
        private System.Windows.Forms.Panel panelSelectPagesListDoc;
        private System.Windows.Forms.Button buttonSelectPagesListDoc;
        private System.Windows.Forms.Button buttonClinicStatisticListDoc;
        private System.Windows.Forms.Button buttonSchedulerListDoc;
        private System.Windows.Forms.Button buttonListPatientsListDoc;
        private System.Windows.Forms.TextBox textBoxListDocName;
        private System.Windows.Forms.Label labelListDocName;
        private System.Windows.Forms.DataGridView dataGridViewDoctors;
        private System.Windows.Forms.TextBox textBoxListDocSpec;
        private System.Windows.Forms.Label labelListDocSpec;
        private System.Windows.Forms.TextBox textBoxListDocID;
        private System.Windows.Forms.Label labelListDocID;
        private System.Windows.Forms.CheckBox checkBoxSurgery;
    }
}