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
    public partial class FormSablonPregled : Form
    {
        public FormSablonPregled()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;
        
        public FormSablonPregled(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormSablonPregled_Load(object sender, EventArgs e)
        {
            //uzimamo dan iz glavne forme
            switch(DataContainer.day.ToString())
            {
                case "Monday":
                case "Ponedeljak":
                case "Monntag":
                    textBoxExamDate.Text = this.mainForm.LabelMondayText;
                    break;
                case "Tuesday":
                case "Utorak":
                case "Dienstag":
                    textBoxExamDate.Text = this.mainForm.LabelTuesdayText;
                    break;
                case "Wednesday":
                case "Sreda":
                case "Mittwoch":
                    textBoxExamDate.Text = this.mainForm.LabelWednesdayText;
                    break;
                case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
                    textBoxExamDate.Text = this.mainForm.LabelThursdayText;
                    break;
                case "Friday":
                case "Petak":
                case "Freitag":
                    textBoxExamDate.Text = this.mainForm.LabelFridayText;
                    break;
                case "Saturday":
                case "Subota":
                case "Samstag":
                    textBoxExamDate.Text = this.mainForm.LabelSaturdayText;
                    break;
                case "Sunday":
                case "Nedelja":
                case "Sonntag":
                    textBoxExamDate.Text = this.mainForm.LabelSundayText;
                    break;
            }

            //uzimamo vreme iz glavne forme
            TimeSpan result = TimeSpan.FromHours(DataContainer.time);
            textBoxExamTime.Text = result.ToString("hh':'mm");

            //uzimamo ulogovanog doktora iz glavne forme
            DBConnect db = new DBConnect();
            String querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            DataRow row = dtable.Rows[0];
            textBoxExamDoctor.Text = row["name"].ToString();
        }

        //cisti sva polja u pregled formi
        private void buttonExamClear_Click(object sender, EventArgs e)
        {
            textBoxExamPatient.Clear();
            textBoxExamJMBG.Clear();
            textBoxExamProblem.Clear();
            textBoxExamPatient.Focus();
        }

        //gasi pregled formu
        private void buttonExamExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
            return;
        }

        //ubacuje nov event "pregled" u planer i gasi pregled formu
        private void buttonExamConfirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            //proveravamo da li je pacijent zauzet za navedeno vreme i datum
            //(moguci scenario ako vise doktora pokusavaju da zakazu u isti termin istom pacijentu)
            String querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxExamJMBG.Text + "' AND time = '" + textBoxExamTime.Text + "'";
            MySqlDataAdapter msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            DataTable dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count > 0)
            {
                foreach (DataRow row in dtablePom.Rows) {
                    String stringDate = row["date"].ToString();
                    //cid je CultureInfo koji je vazio kada je event bio kreiran
                    CultureInfo cid = new CultureInfo(row["cultureInfo"].ToString());                   
                    DateTime datumEventa = DateTime.ParseExact(stringDate.Substring(1, stringDate.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);
                    String datumEventaUCi = datumEventa.ToString(" d. MMMM yyyy. ", ci);
                    datumEventaUCi = "[" + datumEventaUCi + "]";

                    if (datumEventaUCi == textBoxExamDate.Text)
                    {
                        MessageBox.Show("Pacijent je zauzet u datom terminu!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //ubacujemo novi event
            
            MySqlCommand cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
            textBoxExamProblem.Text + "', '" + DataContainer.service + "', '" + "0" + "', '" + textBoxExamPatient.Text
            + "', '" + textBoxExamDoctor.Text + "', '" + textBoxExamTime.Text + "', '" + textBoxExamDate.Text + "', '" + DataContainer.week 
            + "', '" + ci.ToString() + "', '" + textBoxExamJMBG.Text + "');", db.GetConnection());

            cmd.ExecuteNonQuery();

            //ubacujemo novog pacijenta u patients, ako vec ne postoji
            querryPom = "SELECT * FROM patients WHERE name = '" + textBoxExamPatient.Text + "' AND jmbg = '" + textBoxExamJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO patients(jmbg, name, phone, code, checked, labed, operated, therapied, controled) VALUES ('" +
                textBoxExamJMBG.Text + "', '" + textBoxExamPatient.Text + "', '" + textBoxExamPhone.Text + "', '" + "0"
                + "', '" + "1" + "', '" + "0" + "', '" + "0" + "', '" + "0" + "', '" + "0" + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }

            //ubacujemo nov odnos doktor-pacijent u clients, ako vec ne postoji
            querryPom = "SELECT * FROM clients WHERE doctorID = '" + ActiveDoctor.id + "' AND patientID = '" + textBoxExamJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
               cmd = new MySqlCommand("INSERT INTO clients(patientID, doctorID) VALUES ('" +
               textBoxExamJMBG.Text + "', '" + ActiveDoctor.id + "');", db.GetConnection());

               cmd.ExecuteNonQuery();
            }

            mainForm.updatePlaner(ci.Calendar);
            mainForm.Show();
            this.Dispose();
            return;
        }
    }
}
