namespace DiplomskiPlanerKlinike
{
    partial class FormSablonLab
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
            this.buttonLabClear = new System.Windows.Forms.Button();
            this.buttonLabConfirm = new System.Windows.Forms.Button();
            this.buttonLabExit = new System.Windows.Forms.Button();
            this.textBoxLabJMBG = new System.Windows.Forms.TextBox();
            this.labelLabJMBG = new System.Windows.Forms.Label();
            this.labelLabDoctor = new System.Windows.Forms.Label();
            this.textBoxLabDoctor = new System.Windows.Forms.TextBox();
            this.textBoxLabDate = new System.Windows.Forms.TextBox();
            this.textBoxLabTime = new System.Windows.Forms.TextBox();
            this.textBoxLabProblem = new System.Windows.Forms.TextBox();
            this.textBoxLabPatient = new System.Windows.Forms.TextBox();
            this.labelLabDate = new System.Windows.Forms.Label();
            this.labelLabTime = new System.Windows.Forms.Label();
            this.labelLabProblem = new System.Windows.Forms.Label();
            this.labelLabPatient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLabClear
            // 
            this.buttonLabClear.Location = new System.Drawing.Point(118, 322);
            this.buttonLabClear.Name = "buttonLabClear";
            this.buttonLabClear.Size = new System.Drawing.Size(94, 23);
            this.buttonLabClear.TabIndex = 29;
            this.buttonLabClear.Text = "Clear";
            this.buttonLabClear.UseVisualStyleBackColor = true;
            this.buttonLabClear.Click += new System.EventHandler(this.buttonLabClear_Click);
            // 
            // buttonLabConfirm
            // 
            this.buttonLabConfirm.Location = new System.Drawing.Point(269, 322);
            this.buttonLabConfirm.Name = "buttonLabConfirm";
            this.buttonLabConfirm.Size = new System.Drawing.Size(98, 23);
            this.buttonLabConfirm.TabIndex = 28;
            this.buttonLabConfirm.Text = "Confirm";
            this.buttonLabConfirm.UseVisualStyleBackColor = true;
            this.buttonLabConfirm.Click += new System.EventHandler(this.buttonLabConfirm_Click);
            // 
            // buttonLabExit
            // 
            this.buttonLabExit.Location = new System.Drawing.Point(15, 362);
            this.buttonLabExit.Name = "buttonLabExit";
            this.buttonLabExit.Size = new System.Drawing.Size(86, 23);
            this.buttonLabExit.TabIndex = 27;
            this.buttonLabExit.Text = "Exit";
            this.buttonLabExit.UseVisualStyleBackColor = true;
            this.buttonLabExit.Click += new System.EventHandler(this.buttonLabExit_Click);
            // 
            // textBoxLabJMBG
            // 
            this.textBoxLabJMBG.Location = new System.Drawing.Point(118, 68);
            this.textBoxLabJMBG.Name = "textBoxLabJMBG";
            this.textBoxLabJMBG.Size = new System.Drawing.Size(249, 20);
            this.textBoxLabJMBG.TabIndex = 26;
            // 
            // labelLabJMBG
            // 
            this.labelLabJMBG.AutoSize = true;
            this.labelLabJMBG.Location = new System.Drawing.Point(12, 71);
            this.labelLabJMBG.Name = "labelLabJMBG";
            this.labelLabJMBG.Size = new System.Drawing.Size(59, 13);
            this.labelLabJMBG.TabIndex = 25;
            this.labelLabJMBG.Text = "ID number:";
            // 
            // labelLabDoctor
            // 
            this.labelLabDoctor.AutoSize = true;
            this.labelLabDoctor.Location = new System.Drawing.Point(12, 275);
            this.labelLabDoctor.Name = "labelLabDoctor";
            this.labelLabDoctor.Size = new System.Drawing.Size(42, 13);
            this.labelLabDoctor.TabIndex = 24;
            this.labelLabDoctor.Text = "Doctor:";
            // 
            // textBoxLabDoctor
            // 
            this.textBoxLabDoctor.Location = new System.Drawing.Point(118, 272);
            this.textBoxLabDoctor.Name = "textBoxLabDoctor";
            this.textBoxLabDoctor.ReadOnly = true;
            this.textBoxLabDoctor.Size = new System.Drawing.Size(249, 20);
            this.textBoxLabDoctor.TabIndex = 23;
            // 
            // textBoxLabDate
            // 
            this.textBoxLabDate.Location = new System.Drawing.Point(118, 221);
            this.textBoxLabDate.Name = "textBoxLabDate";
            this.textBoxLabDate.ReadOnly = true;
            this.textBoxLabDate.Size = new System.Drawing.Size(249, 20);
            this.textBoxLabDate.TabIndex = 22;
            // 
            // textBoxLabTime
            // 
            this.textBoxLabTime.Location = new System.Drawing.Point(118, 176);
            this.textBoxLabTime.Name = "textBoxLabTime";
            this.textBoxLabTime.ReadOnly = true;
            this.textBoxLabTime.Size = new System.Drawing.Size(249, 20);
            this.textBoxLabTime.TabIndex = 21;
            // 
            // textBoxLabProblem
            // 
            this.textBoxLabProblem.Location = new System.Drawing.Point(118, 104);
            this.textBoxLabProblem.Multiline = true;
            this.textBoxLabProblem.Name = "textBoxLabProblem";
            this.textBoxLabProblem.Size = new System.Drawing.Size(249, 60);
            this.textBoxLabProblem.TabIndex = 20;
            // 
            // textBoxLabPatient
            // 
            this.textBoxLabPatient.Location = new System.Drawing.Point(118, 28);
            this.textBoxLabPatient.Name = "textBoxLabPatient";
            this.textBoxLabPatient.Size = new System.Drawing.Size(249, 20);
            this.textBoxLabPatient.TabIndex = 19;
            // 
            // labelLabDate
            // 
            this.labelLabDate.AutoSize = true;
            this.labelLabDate.Location = new System.Drawing.Point(12, 224);
            this.labelLabDate.Name = "labelLabDate";
            this.labelLabDate.Size = new System.Drawing.Size(84, 13);
            this.labelLabDate.TabIndex = 18;
            this.labelLabDate.Text = "Laboratory date:";
            // 
            // labelLabTime
            // 
            this.labelLabTime.AutoSize = true;
            this.labelLabTime.Location = new System.Drawing.Point(12, 183);
            this.labelLabTime.Name = "labelLabTime";
            this.labelLabTime.Size = new System.Drawing.Size(82, 13);
            this.labelLabTime.TabIndex = 17;
            this.labelLabTime.Text = "Laboratory time:";
            // 
            // labelLabProblem
            // 
            this.labelLabProblem.AutoSize = true;
            this.labelLabProblem.Location = new System.Drawing.Point(12, 132);
            this.labelLabProblem.Name = "labelLabProblem";
            this.labelLabProblem.Size = new System.Drawing.Size(48, 13);
            this.labelLabProblem.TabIndex = 16;
            this.labelLabProblem.Text = "Problem:";
            // 
            // labelLabPatient
            // 
            this.labelLabPatient.AutoSize = true;
            this.labelLabPatient.Location = new System.Drawing.Point(12, 31);
            this.labelLabPatient.Name = "labelLabPatient";
            this.labelLabPatient.Size = new System.Drawing.Size(72, 13);
            this.labelLabPatient.TabIndex = 15;
            this.labelLabPatient.Text = "Patient name:";
            // 
            // FormSablonLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 401);
            this.Controls.Add(this.buttonLabClear);
            this.Controls.Add(this.buttonLabConfirm);
            this.Controls.Add(this.buttonLabExit);
            this.Controls.Add(this.textBoxLabJMBG);
            this.Controls.Add(this.labelLabJMBG);
            this.Controls.Add(this.labelLabDoctor);
            this.Controls.Add(this.textBoxLabDoctor);
            this.Controls.Add(this.textBoxLabDate);
            this.Controls.Add(this.textBoxLabTime);
            this.Controls.Add(this.textBoxLabProblem);
            this.Controls.Add(this.textBoxLabPatient);
            this.Controls.Add(this.labelLabDate);
            this.Controls.Add(this.labelLabTime);
            this.Controls.Add(this.labelLabProblem);
            this.Controls.Add(this.labelLabPatient);
            this.Name = "FormSablonLab";
            this.Text = "Appoint Lab Testing";
            this.Load += new System.EventHandler(this.FormSablonLab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLabClear;
        private System.Windows.Forms.Button buttonLabConfirm;
        private System.Windows.Forms.Button buttonLabExit;
        private System.Windows.Forms.TextBox textBoxLabJMBG;
        private System.Windows.Forms.Label labelLabJMBG;
        private System.Windows.Forms.Label labelLabDoctor;
        private System.Windows.Forms.TextBox textBoxLabDoctor;
        private System.Windows.Forms.TextBox textBoxLabDate;
        private System.Windows.Forms.TextBox textBoxLabTime;
        private System.Windows.Forms.TextBox textBoxLabProblem;
        private System.Windows.Forms.TextBox textBoxLabPatient;
        private System.Windows.Forms.Label labelLabDate;
        private System.Windows.Forms.Label labelLabTime;
        private System.Windows.Forms.Label labelLabProblem;
        private System.Windows.Forms.Label labelLabPatient;
    }
}