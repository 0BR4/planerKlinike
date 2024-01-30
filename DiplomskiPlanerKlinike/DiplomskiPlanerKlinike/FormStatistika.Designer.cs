namespace DiplomskiPlanerKlinike
{
    partial class FormStatistika
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.buttonPlanerLogout = new System.Windows.Forms.Button();
            this.panelSelectPagesStat = new System.Windows.Forms.Panel();
            this.buttonSelectPagesStat = new System.Windows.Forms.Button();
            this.buttonListDoctorsStat = new System.Windows.Forms.Button();
            this.buttonSchedulerStat = new System.Windows.Forms.Button();
            this.buttonListPatientsStat = new System.Windows.Forms.Button();
            this.chartStat = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonChartGenerate = new System.Windows.Forms.Button();
            this.textBoxChartYear = new System.Windows.Forms.TextBox();
            this.labelChartYear = new System.Windows.Forms.Label();
            this.checkBoxChartExam = new System.Windows.Forms.CheckBox();
            this.checkBoxChartLab = new System.Windows.Forms.CheckBox();
            this.checkBoxChartTherapy = new System.Windows.Forms.CheckBox();
            this.checkBoxChartOperation = new System.Windows.Forms.CheckBox();
            this.checkBoxChartCheckup = new System.Windows.Forms.CheckBox();
            this.panelSelectPagesStat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStat)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlanerLogout
            // 
            this.buttonPlanerLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonPlanerLogout.Location = new System.Drawing.Point(163, 12);
            this.buttonPlanerLogout.Name = "buttonPlanerLogout";
            this.buttonPlanerLogout.Size = new System.Drawing.Size(136, 42);
            this.buttonPlanerLogout.TabIndex = 47;
            this.buttonPlanerLogout.Text = "Log out";
            this.buttonPlanerLogout.UseVisualStyleBackColor = true;
            this.buttonPlanerLogout.Click += new System.EventHandler(this.buttonPlanerLogout_Click);
            // 
            // panelSelectPagesStat
            // 
            this.panelSelectPagesStat.Controls.Add(this.buttonSelectPagesStat);
            this.panelSelectPagesStat.Controls.Add(this.buttonListDoctorsStat);
            this.panelSelectPagesStat.Controls.Add(this.buttonSchedulerStat);
            this.panelSelectPagesStat.Controls.Add(this.buttonListPatientsStat);
            this.panelSelectPagesStat.Location = new System.Drawing.Point(11, 12);
            this.panelSelectPagesStat.Name = "panelSelectPagesStat";
            this.panelSelectPagesStat.Size = new System.Drawing.Size(136, 42);
            this.panelSelectPagesStat.TabIndex = 46;
            // 
            // buttonSelectPagesStat
            // 
            this.buttonSelectPagesStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectPagesStat.Location = new System.Drawing.Point(0, 0);
            this.buttonSelectPagesStat.Name = "buttonSelectPagesStat";
            this.buttonSelectPagesStat.Size = new System.Drawing.Size(136, 42);
            this.buttonSelectPagesStat.TabIndex = 0;
            this.buttonSelectPagesStat.Text = "Pages";
            this.buttonSelectPagesStat.UseVisualStyleBackColor = true;
            this.buttonSelectPagesStat.Click += new System.EventHandler(this.buttonSelectPagesStat_Click);
            // 
            // buttonListDoctorsStat
            // 
            this.buttonListDoctorsStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonListDoctorsStat.Location = new System.Drawing.Point(0, 117);
            this.buttonListDoctorsStat.Name = "buttonListDoctorsStat";
            this.buttonListDoctorsStat.Size = new System.Drawing.Size(136, 42);
            this.buttonListDoctorsStat.TabIndex = 2;
            this.buttonListDoctorsStat.Text = "List of doctors";
            this.buttonListDoctorsStat.UseVisualStyleBackColor = true;
            this.buttonListDoctorsStat.Click += new System.EventHandler(this.buttonListDoctorsStat_Click);
            // 
            // buttonSchedulerStat
            // 
            this.buttonSchedulerStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSchedulerStat.Location = new System.Drawing.Point(0, 39);
            this.buttonSchedulerStat.Name = "buttonSchedulerStat";
            this.buttonSchedulerStat.Size = new System.Drawing.Size(136, 42);
            this.buttonSchedulerStat.TabIndex = 3;
            this.buttonSchedulerStat.Text = "Scheduler";
            this.buttonSchedulerStat.UseVisualStyleBackColor = true;
            this.buttonSchedulerStat.Click += new System.EventHandler(this.buttonSchedulerStat_Click);
            // 
            // buttonListPatientsStat
            // 
            this.buttonListPatientsStat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonListPatientsStat.Location = new System.Drawing.Point(0, 78);
            this.buttonListPatientsStat.Name = "buttonListPatientsStat";
            this.buttonListPatientsStat.Size = new System.Drawing.Size(136, 42);
            this.buttonListPatientsStat.TabIndex = 1;
            this.buttonListPatientsStat.Text = "List of patients";
            this.buttonListPatientsStat.UseVisualStyleBackColor = true;
            this.buttonListPatientsStat.Click += new System.EventHandler(this.buttonListPatientsStat_Click);
            // 
            // chartStat
            // 
            this.chartStat.BackColor = System.Drawing.Color.Gray;
            this.chartStat.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chartStat.ChartAreas.Add(chartArea1);
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 5F;
            legend1.Position.Width = 20F;
            legend1.Position.X = 80F;
            legend1.Position.Y = 5F;
            legend2.Name = "Legend2";
            legend2.Position.Auto = false;
            legend2.Position.Height = 5F;
            legend2.Position.Width = 20F;
            legend2.Position.X = 80F;
            legend2.Position.Y = 10F;
            legend3.Name = "Legend3";
            legend3.Position.Auto = false;
            legend3.Position.Height = 5F;
            legend3.Position.Width = 20F;
            legend3.Position.X = 80F;
            legend3.Position.Y = 15F;
            legend4.Name = "Legend4";
            legend4.Position.Auto = false;
            legend4.Position.Height = 5F;
            legend4.Position.Width = 20F;
            legend4.Position.X = 80F;
            legend4.Position.Y = 20F;
            legend5.InterlacedRows = true;
            legend5.IsEquallySpacedItems = true;
            legend5.Name = "Legend5";
            legend5.Position.Auto = false;
            legend5.Position.Height = 5F;
            legend5.Position.Width = 20F;
            legend5.Position.X = 80F;
            legend5.Position.Y = 25F;
            this.chartStat.Legends.Add(legend1);
            this.chartStat.Legends.Add(legend2);
            this.chartStat.Legends.Add(legend3);
            this.chartStat.Legends.Add(legend4);
            this.chartStat.Legends.Add(legend5);
            this.chartStat.Location = new System.Drawing.Point(294, 74);
            this.chartStat.Name = "chartStat";
            this.chartStat.Size = new System.Drawing.Size(840, 458);
            this.chartStat.TabIndex = 48;
            this.chartStat.Text = "chart1";
            // 
            // buttonChartGenerate
            // 
            this.buttonChartGenerate.Location = new System.Drawing.Point(1013, 553);
            this.buttonChartGenerate.Name = "buttonChartGenerate";
            this.buttonChartGenerate.Size = new System.Drawing.Size(108, 23);
            this.buttonChartGenerate.TabIndex = 49;
            this.buttonChartGenerate.Text = "Generate Chart";
            this.buttonChartGenerate.UseVisualStyleBackColor = true;
            this.buttonChartGenerate.Click += new System.EventHandler(this.buttonChartGenerate_Click);
            // 
            // textBoxChartYear
            // 
            this.textBoxChartYear.Location = new System.Drawing.Point(924, 555);
            this.textBoxChartYear.Name = "textBoxChartYear";
            this.textBoxChartYear.Size = new System.Drawing.Size(57, 20);
            this.textBoxChartYear.TabIndex = 57;
            // 
            // labelChartYear
            // 
            this.labelChartYear.AutoSize = true;
            this.labelChartYear.Location = new System.Drawing.Point(886, 558);
            this.labelChartYear.Name = "labelChartYear";
            this.labelChartYear.Size = new System.Drawing.Size(32, 13);
            this.labelChartYear.TabIndex = 58;
            this.labelChartYear.Text = "Year:";
            // 
            // checkBoxChartExam
            // 
            this.checkBoxChartExam.AutoSize = true;
            this.checkBoxChartExam.Location = new System.Drawing.Point(46, 318);
            this.checkBoxChartExam.Name = "checkBoxChartExam";
            this.checkBoxChartExam.Size = new System.Drawing.Size(113, 17);
            this.checkBoxChartExam.TabIndex = 60;
            this.checkBoxChartExam.Text = "Show Examination";
            this.checkBoxChartExam.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartLab
            // 
            this.checkBoxChartLab.AutoSize = true;
            this.checkBoxChartLab.Location = new System.Drawing.Point(46, 350);
            this.checkBoxChartLab.Name = "checkBoxChartLab";
            this.checkBoxChartLab.Size = new System.Drawing.Size(106, 17);
            this.checkBoxChartLab.TabIndex = 61;
            this.checkBoxChartLab.Text = "Show Laboratory";
            this.checkBoxChartLab.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartTherapy
            // 
            this.checkBoxChartTherapy.AutoSize = true;
            this.checkBoxChartTherapy.Location = new System.Drawing.Point(46, 383);
            this.checkBoxChartTherapy.Name = "checkBoxChartTherapy";
            this.checkBoxChartTherapy.Size = new System.Drawing.Size(95, 17);
            this.checkBoxChartTherapy.TabIndex = 62;
            this.checkBoxChartTherapy.Text = "Show Therapy";
            this.checkBoxChartTherapy.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartOperation
            // 
            this.checkBoxChartOperation.AutoSize = true;
            this.checkBoxChartOperation.Location = new System.Drawing.Point(46, 416);
            this.checkBoxChartOperation.Name = "checkBoxChartOperation";
            this.checkBoxChartOperation.Size = new System.Drawing.Size(102, 17);
            this.checkBoxChartOperation.TabIndex = 63;
            this.checkBoxChartOperation.Text = "Show Operation";
            this.checkBoxChartOperation.UseVisualStyleBackColor = true;
            // 
            // checkBoxChartCheckup
            // 
            this.checkBoxChartCheckup.AutoSize = true;
            this.checkBoxChartCheckup.Location = new System.Drawing.Point(46, 449);
            this.checkBoxChartCheckup.Name = "checkBoxChartCheckup";
            this.checkBoxChartCheckup.Size = new System.Drawing.Size(102, 17);
            this.checkBoxChartCheckup.TabIndex = 64;
            this.checkBoxChartCheckup.Text = "Show Check-up";
            this.checkBoxChartCheckup.UseVisualStyleBackColor = true;
            // 
            // FormStatistika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 600);
            this.Controls.Add(this.checkBoxChartCheckup);
            this.Controls.Add(this.checkBoxChartOperation);
            this.Controls.Add(this.checkBoxChartTherapy);
            this.Controls.Add(this.checkBoxChartLab);
            this.Controls.Add(this.checkBoxChartExam);
            this.Controls.Add(this.labelChartYear);
            this.Controls.Add(this.textBoxChartYear);
            this.Controls.Add(this.buttonChartGenerate);
            this.Controls.Add(this.chartStat);
            this.Controls.Add(this.buttonPlanerLogout);
            this.Controls.Add(this.panelSelectPagesStat);
            this.Name = "FormStatistika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStatistika";
            this.Load += new System.EventHandler(this.FormStatistika_Load);
            this.panelSelectPagesStat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlanerLogout;
        private System.Windows.Forms.Panel panelSelectPagesStat;
        private System.Windows.Forms.Button buttonSelectPagesStat;
        private System.Windows.Forms.Button buttonSchedulerStat;
        private System.Windows.Forms.Button buttonListDoctorsStat;
        private System.Windows.Forms.Button buttonListPatientsStat;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStat;
        private System.Windows.Forms.Button buttonChartGenerate;
        private System.Windows.Forms.TextBox textBoxChartYear;
        private System.Windows.Forms.Label labelChartYear;
        private System.Windows.Forms.CheckBox checkBoxChartExam;
        private System.Windows.Forms.CheckBox checkBoxChartLab;
        private System.Windows.Forms.CheckBox checkBoxChartTherapy;
        private System.Windows.Forms.CheckBox checkBoxChartOperation;
        private System.Windows.Forms.CheckBox checkBoxChartCheckup;
    }
}