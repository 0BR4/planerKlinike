using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomskiPlanerKlinike
{
    public partial class FormStatistika : Form
    {
        public FormStatistika()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormStatistika(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormStatistika_Load(object sender, EventArgs e)
        {
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
        }

        private void buttonSelectPagesStat_Click(object sender, EventArgs e)
        {
            if (panelSelectPagesStat.Height == 159)
            {
                panelSelectPagesStat.Height = 42;
            }
            else
            {
                panelSelectPagesStat.Height = 159;
            }
        }

        private void buttonPlanerLogout_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to logout?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //praznimo podatke aktivnog doktora
                ActiveDoctor.username = "";
                ActiveDoctor.password = "";
                ActiveDoctor.id = 0;
                ActiveDoctor.specialization = "";
                ActiveDoctor.surgery = false;
                ActiveDoctor.name = "";

                //vracamo se na Login formu
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();
            }
            else
            {
                return;
                //this.Show();
            }
        }

        private void buttonSchedulerStat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
        }

        private void buttonListPatientsStat_Click(object sender, EventArgs e)
        {
            FormListaPacijenata formListPat = new FormListaPacijenata(this.mainForm);
            formListPat.Show();            
            this.Dispose();
        }

        private void buttonListDoctorsStat_Click(object sender, EventArgs e)
        {
            FormListaDoktora formListDoc = new FormListaDoktora(this.mainForm);
            formListDoc.Show();
            this.Dispose();
        }

        private void buttonChartGenerate_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            var objChart = chartStat.ChartAreas[0];
            
            //x osa su meseci
            objChart.AxisX.IntervalType = DateTimeIntervalType.Number; //bilo je .Number umesto .Months
            objChart.AxisX.Minimum = 0; //ili 1?
            objChart.AxisX.Maximum = 12;

            //y osa je broj usluga
            objChart.AxisY.IntervalType = DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 20; //TODO: promeni na vecu brojku

            chartStat.Series.Clear();

            //brojaci za svaku uslugu, duzine jednake broju meseca u godini
            int examTotal = 0;
            int labTotal = 0;
            int therapyTotal = 0;
            int operationTotal = 0;
            int checkupTotal = 0;
            var examCount = new int[12];
            var labCount = new int[12];
            var therapyCount = new int[12];
            var operationCount = new int[12];
            var checkupCount = new int[12];

            //podesavamo chart
            chartStat.Series.Add("Examination");
            //chartStat.Series["Examination"].Color = Color.AliceBlue;
            chartStat.Series["Examination"].Color = Color.Blue;
            chartStat.Series["Examination"].Legend = "Legend1";
            chartStat.Series["Examination"].ChartArea = "ChartArea1";
            chartStat.Series["Examination"].ChartType = SeriesChartType.Line;

            chartStat.Series.Add("Laboratory");
            chartStat.Series["Laboratory"].Color = Color.GreenYellow;
            chartStat.Series["Laboratory"].Legend = "Legend2";
            chartStat.Series["Laboratory"].ChartArea = "ChartArea1";
            chartStat.Series["Laboratory"].ChartType = SeriesChartType.Line;

            chartStat.Series.Add("Therapy");
            chartStat.Series["Therapy"].Color = Color.LightPink;
            chartStat.Series["Therapy"].Legend = "Legend3";
            chartStat.Series["Therapy"].ChartArea = "ChartArea1";
            chartStat.Series["Therapy"].ChartType = SeriesChartType.Line;

            chartStat.Series.Add("Operation");
            chartStat.Series["Operation"].Color = Color.OrangeRed;
            chartStat.Series["Operation"].Legend = "Legend4";
            chartStat.Series["Operation"].ChartArea = "ChartArea1";
            chartStat.Series["Operation"].ChartType = SeriesChartType.Line;

            chartStat.Series.Add("Check-up");
            chartStat.Series["Check-up"].Color = Color.PowderBlue;
            chartStat.Series["Check-up"].Legend = "Legend5";
            chartStat.Series["Check-up"].ChartArea = "ChartArea1";
            chartStat.Series["Check-up"].ChartType = SeriesChartType.Line;

            //podesavamo da su meseci na x osi
            string[] months = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            Axis axisX = chartStat.ChartAreas[0].AxisX;
            double axisLabelPos = 0.5;
            for(int i = 0; i < months.Length; i++)
            {
                axisX.CustomLabels.Add(axisLabelPos, axisLabelPos + 1, months[i]);
                axisLabelPos = axisLabelPos + 1.0;
            }


            //vadimo eventove da bi imali podatke da crtamo na grafu
            String querry = "SELECT * FROM events";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            if (dtable.Rows.Count > 0) 
            {
                foreach (DataRow row in dtable.Rows)
                {
                    //uzimamo datum iz eventa i proveravamo da li je za aktuelnu godinu
                    //ako jeste, povecavamo brojac za odgovarajucu uslugu
                    String cie = row["cultureInfo"].ToString();
                    CultureInfo cid = new CultureInfo(cie);
                    String stringDate = row["date"].ToString();
                    DateTime holdDate = DateTime.Parse(stringDate.Substring(1, stringDate.Length - 2), cid, DateTimeStyles.NoCurrentDateDefault);

                    if (holdDate.Year.ToString().Equals(""))
                    {
                        MessageBox.Show("Please add a year!");
                        return;
                    }

                    if (holdDate.Year == Int16.Parse(textBoxChartYear.Text))
                    {
                        for (int m = 0; m < 12; m++)
                        {
                            if (holdDate.Month == m + 1)
                            {
                                switch (row["service"].ToString())
                                {
                                    case "Examination":
                                        examCount[m] += 1;
                                        break;
                                    case "Laboratory":
                                        labCount[m] += 1;
                                        break;
                                    case "Therapy":
                                        therapyCount[m] += 1;
                                        break;
                                    case "Operation":
                                        operationCount[m] += 1;
                                        break;
                                    case "Check-up":
                                        checkupCount[m] += 1;
                                        break;
                                }
                            }


                        }
                    }
                }

                //proveravamo i crtamo Examination
                if (checkBoxChartExam.Checked)
                {
                    chartStat.Series["Examination"].Points.AddXY(0, 0);

                    for (int i = 0; i < 12; i++)
                    {
                        examTotal += examCount[i];
                        chartStat.Series["Examination"].Points.AddXY(i + 1, examTotal);
                    }
                }

                //proveravamo i crtamo Laboratory
                    
                if (checkBoxChartLab.Checked)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        labTotal += labCount[i];
                        chartStat.Series["Laboratory"].Points.AddXY(i + 1, labTotal);
                    }
                }

                //proveravamo i crtamo Therapy
                if (checkBoxChartTherapy.Checked)
                {                        
                    for (int i = 0; i < 12; i++)
                    {
                        therapyTotal += therapyCount[i];
                        chartStat.Series["Therapy"].Points.AddXY(i + 1, therapyTotal);
                    }                        
                }

                //proveravamo i crtamo Operation
                if (checkBoxChartOperation.Checked)
                {                       
                    for (int i = 0; i < 12; i++)
                    {
                        operationTotal += operationCount[i];
                        chartStat.Series["Operation"].Points.AddXY(i + 1, operationTotal);
                    }                        
                }

                //proveravamo i crtamo Checkup
                if (checkBoxChartCheckup.Checked)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        checkupTotal += checkupCount[i];
                        chartStat.Series["Check-up"].Points.AddXY(i + 1, checkupTotal);
                    }                       
                }                                   
            }                    
        }
    }
}
