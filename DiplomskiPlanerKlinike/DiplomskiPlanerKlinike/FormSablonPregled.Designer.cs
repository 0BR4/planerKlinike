namespace DiplomskiPlanerKlinike
{
    partial class FormSablonPregled
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
            this.labelExamPatient = new System.Windows.Forms.Label();
            this.labelExamProblem = new System.Windows.Forms.Label();
            this.labelExamTime = new System.Windows.Forms.Label();
            this.labelExamDate = new System.Windows.Forms.Label();
            this.textBoxExamPatient = new System.Windows.Forms.TextBox();
            this.textBoxExamProblem = new System.Windows.Forms.TextBox();
            this.textBoxExamTime = new System.Windows.Forms.TextBox();
            this.textBoxExamDate = new System.Windows.Forms.TextBox();
            this.textBoxExamDoctor = new System.Windows.Forms.TextBox();
            this.labelExamDoctor = new System.Windows.Forms.Label();
            this.labelExamJMBG = new System.Windows.Forms.Label();
            this.textBoxExamJMBG = new System.Windows.Forms.TextBox();
            this.buttonExamExit = new System.Windows.Forms.Button();
            this.buttonExamConfirm = new System.Windows.Forms.Button();
            this.buttonExamClear = new System.Windows.Forms.Button();
            this.labelExamPhone = new System.Windows.Forms.Label();
            this.textBoxExamPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelExamPatient
            // 
            this.labelExamPatient.AutoSize = true;
            this.labelExamPatient.Location = new System.Drawing.Point(13, 30);
            this.labelExamPatient.Name = "labelExamPatient";
            this.labelExamPatient.Size = new System.Drawing.Size(72, 13);
            this.labelExamPatient.TabIndex = 0;
            this.labelExamPatient.Text = "Patient name:";
            // 
            // labelExamProblem
            // 
            this.labelExamProblem.AutoSize = true;
            this.labelExamProblem.Location = new System.Drawing.Point(13, 134);
            this.labelExamProblem.Name = "labelExamProblem";
            this.labelExamProblem.Size = new System.Drawing.Size(48, 13);
            this.labelExamProblem.TabIndex = 1;
            this.labelExamProblem.Text = "Problem:";
            // 
            // labelExamTime
            // 
            this.labelExamTime.AutoSize = true;
            this.labelExamTime.Location = new System.Drawing.Point(13, 182);
            this.labelExamTime.Name = "labelExamTime";
            this.labelExamTime.Size = new System.Drawing.Size(89, 13);
            this.labelExamTime.TabIndex = 2;
            this.labelExamTime.Text = "Examination time:";
            // 
            // labelExamDate
            // 
            this.labelExamDate.AutoSize = true;
            this.labelExamDate.Location = new System.Drawing.Point(13, 223);
            this.labelExamDate.Name = "labelExamDate";
            this.labelExamDate.Size = new System.Drawing.Size(91, 13);
            this.labelExamDate.TabIndex = 3;
            this.labelExamDate.Text = "Examination date:";
            // 
            // textBoxExamPatient
            // 
            this.textBoxExamPatient.Location = new System.Drawing.Point(119, 27);
            this.textBoxExamPatient.Name = "textBoxExamPatient";
            this.textBoxExamPatient.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamPatient.TabIndex = 4;
            // 
            // textBoxExamProblem
            // 
            this.textBoxExamProblem.Location = new System.Drawing.Point(119, 131);
            this.textBoxExamProblem.Multiline = true;
            this.textBoxExamProblem.Name = "textBoxExamProblem";
            this.textBoxExamProblem.Size = new System.Drawing.Size(249, 32);
            this.textBoxExamProblem.TabIndex = 5;
            // 
            // textBoxExamTime
            // 
            this.textBoxExamTime.Location = new System.Drawing.Point(119, 175);
            this.textBoxExamTime.Name = "textBoxExamTime";
            this.textBoxExamTime.ReadOnly = true;
            this.textBoxExamTime.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamTime.TabIndex = 6;
            // 
            // textBoxExamDate
            // 
            this.textBoxExamDate.Location = new System.Drawing.Point(119, 220);
            this.textBoxExamDate.Name = "textBoxExamDate";
            this.textBoxExamDate.ReadOnly = true;
            this.textBoxExamDate.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamDate.TabIndex = 7;
            // 
            // textBoxExamDoctor
            // 
            this.textBoxExamDoctor.Location = new System.Drawing.Point(119, 271);
            this.textBoxExamDoctor.Name = "textBoxExamDoctor";
            this.textBoxExamDoctor.ReadOnly = true;
            this.textBoxExamDoctor.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamDoctor.TabIndex = 8;
            // 
            // labelExamDoctor
            // 
            this.labelExamDoctor.AutoSize = true;
            this.labelExamDoctor.Location = new System.Drawing.Point(13, 274);
            this.labelExamDoctor.Name = "labelExamDoctor";
            this.labelExamDoctor.Size = new System.Drawing.Size(42, 13);
            this.labelExamDoctor.TabIndex = 9;
            this.labelExamDoctor.Text = "Doctor:";
            // 
            // labelExamJMBG
            // 
            this.labelExamJMBG.AutoSize = true;
            this.labelExamJMBG.Location = new System.Drawing.Point(13, 66);
            this.labelExamJMBG.Name = "labelExamJMBG";
            this.labelExamJMBG.Size = new System.Drawing.Size(59, 13);
            this.labelExamJMBG.TabIndex = 10;
            this.labelExamJMBG.Text = "ID number:";
            // 
            // textBoxExamJMBG
            // 
            this.textBoxExamJMBG.Location = new System.Drawing.Point(119, 63);
            this.textBoxExamJMBG.Name = "textBoxExamJMBG";
            this.textBoxExamJMBG.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamJMBG.TabIndex = 11;
            // 
            // buttonExamExit
            // 
            this.buttonExamExit.Location = new System.Drawing.Point(16, 361);
            this.buttonExamExit.Name = "buttonExamExit";
            this.buttonExamExit.Size = new System.Drawing.Size(86, 23);
            this.buttonExamExit.TabIndex = 12;
            this.buttonExamExit.Text = "Exit";
            this.buttonExamExit.UseVisualStyleBackColor = true;
            this.buttonExamExit.Click += new System.EventHandler(this.buttonExamExit_Click);
            // 
            // buttonExamConfirm
            // 
            this.buttonExamConfirm.Location = new System.Drawing.Point(270, 321);
            this.buttonExamConfirm.Name = "buttonExamConfirm";
            this.buttonExamConfirm.Size = new System.Drawing.Size(98, 23);
            this.buttonExamConfirm.TabIndex = 13;
            this.buttonExamConfirm.Text = "Confirm";
            this.buttonExamConfirm.UseVisualStyleBackColor = true;
            this.buttonExamConfirm.Click += new System.EventHandler(this.buttonExamConfirm_Click);
            // 
            // buttonExamClear
            // 
            this.buttonExamClear.Location = new System.Drawing.Point(119, 321);
            this.buttonExamClear.Name = "buttonExamClear";
            this.buttonExamClear.Size = new System.Drawing.Size(94, 23);
            this.buttonExamClear.TabIndex = 14;
            this.buttonExamClear.Text = "Clear";
            this.buttonExamClear.UseVisualStyleBackColor = true;
            this.buttonExamClear.Click += new System.EventHandler(this.buttonExamClear_Click);
            // 
            // labelExamPhone
            // 
            this.labelExamPhone.AutoSize = true;
            this.labelExamPhone.Location = new System.Drawing.Point(13, 100);
            this.labelExamPhone.Name = "labelExamPhone";
            this.labelExamPhone.Size = new System.Drawing.Size(79, 13);
            this.labelExamPhone.TabIndex = 15;
            this.labelExamPhone.Text = "Phone number:";
            // 
            // textBoxExamPhone
            // 
            this.textBoxExamPhone.Location = new System.Drawing.Point(119, 97);
            this.textBoxExamPhone.Name = "textBoxExamPhone";
            this.textBoxExamPhone.Size = new System.Drawing.Size(249, 20);
            this.textBoxExamPhone.TabIndex = 16;
            // 
            // FormSablonPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 401);
            this.Controls.Add(this.textBoxExamPhone);
            this.Controls.Add(this.labelExamPhone);
            this.Controls.Add(this.buttonExamClear);
            this.Controls.Add(this.buttonExamConfirm);
            this.Controls.Add(this.buttonExamExit);
            this.Controls.Add(this.textBoxExamJMBG);
            this.Controls.Add(this.labelExamJMBG);
            this.Controls.Add(this.labelExamDoctor);
            this.Controls.Add(this.textBoxExamDoctor);
            this.Controls.Add(this.textBoxExamDate);
            this.Controls.Add(this.textBoxExamTime);
            this.Controls.Add(this.textBoxExamProblem);
            this.Controls.Add(this.textBoxExamPatient);
            this.Controls.Add(this.labelExamDate);
            this.Controls.Add(this.labelExamTime);
            this.Controls.Add(this.labelExamProblem);
            this.Controls.Add(this.labelExamPatient);
            this.Name = "FormSablonPregled";
            this.Text = "Appoint Examination";
            this.Load += new System.EventHandler(this.FormSablonPregled_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExamPatient;
        private System.Windows.Forms.Label labelExamProblem;
        private System.Windows.Forms.Label labelExamTime;
        private System.Windows.Forms.Label labelExamDate;
        private System.Windows.Forms.TextBox textBoxExamPatient;
        private System.Windows.Forms.TextBox textBoxExamProblem;
        private System.Windows.Forms.TextBox textBoxExamTime;
        private System.Windows.Forms.TextBox textBoxExamDate;
        private System.Windows.Forms.TextBox textBoxExamDoctor;
        private System.Windows.Forms.Label labelExamDoctor;
        private System.Windows.Forms.Label labelExamJMBG;
        private System.Windows.Forms.TextBox textBoxExamJMBG;
        private System.Windows.Forms.Button buttonExamExit;
        private System.Windows.Forms.Button buttonExamConfirm;
        private System.Windows.Forms.Button buttonExamClear;
        private System.Windows.Forms.Label labelExamPhone;
        private System.Windows.Forms.TextBox textBoxExamPhone;
    }
}