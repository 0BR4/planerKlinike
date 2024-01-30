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

namespace DiplomskiPlanerKlinike
{
    public partial class FormSablonLab : Form
    {
        public FormSablonLab()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormSablonLab(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormSablonLab_Load(object sender, EventArgs e)
        {
            //uzimamo dan iz glavne forme
            switch (DataContainer.day.ToString())
            {
                case "Monday":
                case "Ponedeljak":
                case "Monntag":
                    textBoxLabDate.Text = this.mainForm.LabelMondayText;
                    break;
                case "Tuesday":
                case "Utorak":
                case "Dienstag":
                    textBoxLabDate.Text = this.mainForm.LabelTuesdayText;
                    break;
                case "Wednesday":
                case "Sreda":
                case "Mittwoch":
                    textBoxLabDate.Text = this.mainForm.LabelWednesdayText;
                    break;
                case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
                    textBoxLabDate.Text = this.mainForm.LabelThursdayText;
                    break;
                case "Friday":
                case "Petak":
                case "Freitag":
                    textBoxLabDate.Text = this.mainForm.LabelFridayText;
                    break;
                case "Saturday":
                case "Subota":
                case "Samstag":
                    textBoxLabDate.Text = this.mainForm.LabelSaturdayText;
                    break;
                case "Sunday":
                case "Nedelja":
                case "Sonntag":
                    textBoxLabDate.Text = this.mainForm.LabelSundayText;
                    break;
            }

            //uzimamo vreme iz glavne forme
            TimeSpan result = TimeSpan.FromHours(DataContainer.time);
            textBoxLabTime.Text = result.ToString("hh':'mm");

            //uzimamo ulogovanog doktora iz glavne forme
            DBConnect db = new DBConnect();
            String querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            DataRow row = dtable.Rows[0];
            textBoxLabDoctor.Text = row["name"].ToString();
        }

        private void buttonLabClear_Click(object sender, EventArgs e)
        {
            textBoxLabPatient.Clear();
            textBoxLabJMBG.Clear();
            textBoxLabProblem.Clear();
            textBoxLabPatient.Focus();
        }

        private void buttonLabExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
            return;
        }

        private void buttonLabConfirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            //proveravamo da li je pacijent zauzet za navedeno vreme i datum
            //(moguci scenario ako vise doktora pokusavaju da zakazu u isti termin istom pacijentu)
            String querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxLabJMBG.Text + "' AND time = '" + textBoxLabTime.Text + "'";
            MySqlDataAdapter msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            DataTable dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count > 0)
            {
                foreach (DataRow row in dtablePom.Rows)
                {
                    String stringDate = row["date"].ToString();
                    //cid je CultureInfo koji je vazio kada je event bio kreiran
                    CultureInfo cidPom = new CultureInfo(row["cultureInfo"].ToString());
                    DateTime datumEventa = DateTime.ParseExact(stringDate.Substring(1, stringDate.Length - 2), " d. MMMM yyyy. ", cidPom, DateTimeStyles.NoCurrentDateDefault);
                    String datumEventaUCi = datumEventa.ToString(" d. MMMM yyyy. ", ci);
                    datumEventaUCi = "[" + datumEventaUCi + "]";

                    if (datumEventaUCi == textBoxLabDate.Text)
                    {
                        MessageBox.Show("Pacijent je zauzet u datom terminu!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //proveravamo jel je pacijent pregledan
            String querry = "SELECT * FROM patients WHERE name = '" + textBoxLabPatient.Text + "' AND jmbg = '" + textBoxLabJMBG.Text + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                foreach (DataRow row in dtable.Rows)
                {
                    if (!(bool)row["checked"])
                    {
                        MessageBox.Show("Pacijent nije pregledan!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //proveravamo jel je pregled pre laboratorije
            querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxLabJMBG.Text + "' AND service = 'Examination'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            CultureInfo cid = new CultureInfo(dtablePom.Rows[dtablePom.Rows.Count - 1]["cultureInfo"].ToString());

            ////cuvamo vreme
            DateTime examTime = DateTime.ParseExact(dtablePom.Rows[dtablePom.Rows.Count - 1]["time"].ToString(), "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault);

            ////cuvamo datume           
            String strDatumEventa = dtablePom.Rows[dtablePom.Rows.Count - 1]["date"].ToString();
            DateTime examDate = DateTime.ParseExact(strDatumEventa.Substring(1, strDatumEventa.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);

            MessageBox.Show("DEBUG: cid napravljen je: " + cid.ToString() + ", a exam date je: " + examDate.ToString() + ", a string date je: " + strDatumEventa);
            if(examDate > DateTime.ParseExact(textBoxLabDate.Text.Substring(1, textBoxLabDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault) )
            {
                MessageBox.Show("Nemoguce je zakazati laboratoriju na datum koji je pre pregleda!");
                mainForm.Show();
                this.Dispose();
                return;
            }
            else if(examDate == DateTime.ParseExact(textBoxLabDate.Text.Substring(1, textBoxLabDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault) &&
                examTime > DateTime.ParseExact(textBoxLabTime.Text, "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati laboratoriju u vreme koje je pre pregleda!");
                mainForm.Show();
                this.Dispose();
                return;
            }


            //ubacujemo novi event
            MySqlCommand cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
               textBoxLabProblem.Text + "', '" + DataContainer.service + "', '" + "0" + "', '" + textBoxLabPatient.Text + "', '" + textBoxLabDoctor.Text
               + "', '" + textBoxLabTime.Text + "', '" + textBoxLabDate.Text + "', '" + DataContainer.week + "', '" + ci.ToString() + "', '" + textBoxLabJMBG.Text +"');", db.GetConnection());

            cmd.ExecuteNonQuery();

            //apdejtujemo pacijenta, labed = 1
            cmd = new MySqlCommand("UPDATE patients SET labed = '1'" + " WHERE name = '"
                + textBoxLabPatient.Text + "' AND jmbg = '" + textBoxLabJMBG.Text + "';", db.GetConnection());

            cmd.ExecuteNonQuery();


            //ubacujemo nov odnos doktor-pacijent u clients, ako vec ne postoji
            querryPom = "SELECT * FROM clients WHERE doctorID = '" + ActiveDoctor.id + "' AND patientID = '" + textBoxLabJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO clients(patientID, doctorID) VALUES ('" +
                textBoxLabJMBG.Text + "', '" + ActiveDoctor.id + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }

            mainForm.updatePlaner(ci.Calendar);
            mainForm.Show();
            this.Dispose();
            return;
        }
    }
}
