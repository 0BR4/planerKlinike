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
    public partial class FormSablonKontrola : Form
    {
        public FormSablonKontrola()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormSablonKontrola(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormSablonKontrola_Load(object sender, EventArgs e)
        {
            //uzimamo dan iz glavne forme
            switch (DataContainer.day.ToString())
            {
                case "Monday":
                case "Ponedeljak":
                case "Monntag":
                    textBoxCheckupDate.Text = this.mainForm.LabelMondayText;
                    break;
                case "Tuesday":
                case "Utorak":
                case "Dienstag":
                    textBoxCheckupDate.Text = this.mainForm.LabelTuesdayText;
                    break;
                case "Wednesday":
                case "Sreda":
                case "Mittwoch":
                    textBoxCheckupDate.Text = this.mainForm.LabelWednesdayText;
                    break;
                case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
                    textBoxCheckupDate.Text = this.mainForm.LabelThursdayText;
                    break;
                case "Friday":
                case "Petak":
                case "Freitag":
                    textBoxCheckupDate.Text = this.mainForm.LabelFridayText;
                    break;
                case "Saturday":
                case "Subota":
                case "Samstag":
                    textBoxCheckupDate.Text = this.mainForm.LabelSaturdayText;
                    break;
                case "Sunday":
                case "Nedelja":
                case "Sonntag":
                    textBoxCheckupDate.Text = this.mainForm.LabelSundayText;
                    break;
            }

            //uzimamo vreme iz glavne forme
            TimeSpan result = TimeSpan.FromHours(DataContainer.time);
            textBoxCheckupTime.Text = result.ToString("hh':'mm");

            //uzimamo ulogovanog doktora iz glavne forme
            DBConnect db = new DBConnect();
            String querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            DataRow row = dtable.Rows[0];
            textBoxCheckupDoctor.Text = row["name"].ToString();
        }

        private void buttonCheckupClear_Click(object sender, EventArgs e)
        {
            textBoxCheckupPatient.Clear();
            textBoxCheckupJMBG.Clear();
            textBoxCheckupProblem.Clear();
            textBoxCheckupNumber.Clear();
            textBoxCheckupPeriod.Clear();
            textBoxCheckupPatient.Focus();
        }

        private void buttonCheckupConfirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            //proveravamo dal je pacijent prevashodno imao operaciju ili terapiju
            String querry = "SELECT * FROM patients WHERE name = '" + textBoxCheckupPatient.Text + "' AND jmbg = '" + textBoxCheckupJMBG.Text + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                foreach (DataRow row in dtable.Rows)
                {
                    if (!((bool)row["operated"] || (bool)row["therapied"]))
                    {
                        MessageBox.Show("Pacijent nije ni operisan niti bio na terapiju!");
                        return;
                    }
                }
            }

            //proveravamo da li je pacijent zauzet za navedeno vreme i datum
            //(moguci scenario ako vise doktora pokusavaju da zakazu u isti termin istom pacijentu)
            String querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxCheckupJMBG.Text + "' AND time = '" + textBoxCheckupTime.Text + "'";
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

                    if (datumEventaUCi == textBoxCheckupDate.Text)
                    {
                        MessageBox.Show("Pacijent je zauzet u datom terminu!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //proveravamo jel operacija il terapija pre nove kontrole
            querry = "SELECT * FROM events WHERE patientId = '" + textBoxCheckupJMBG.Text + "' AND service IN ('Therapy', 'Operation');";
            msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);
            CultureInfo cid = new CultureInfo(dtable.Rows[dtable.Rows.Count - 1]["cultureInfo"].ToString());

            ////cuvamo vreme
            DateTime eventTime = DateTime.ParseExact(dtable.Rows[dtable.Rows.Count - 1]["time"].ToString(), "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault);

            ////cuvamo datum           
            String strDatumEventa = dtable.Rows[dtable.Rows.Count - 1]["date"].ToString();
            DateTime eventDate = DateTime.ParseExact(strDatumEventa.Substring(1, strDatumEventa.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);

            if (eventDate > DateTime.ParseExact(textBoxCheckupDate.Text.Substring(1, textBoxCheckupDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati operaciju na datum koji je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }
            else if (eventDate == DateTime.ParseExact(textBoxCheckupDate.Text.Substring(1, textBoxCheckupDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault) &&
                eventTime > DateTime.ParseExact(textBoxCheckupTime.Text, "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati operaciju u vreme koje je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }


            //ubacujemo novi event          
            MySqlCommand cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
            textBoxCheckupProblem.Text + "', '" + DataContainer.service + "', '" + "0" + "', '" + textBoxCheckupPatient.Text
            + "', '" + textBoxCheckupDoctor.Text + "', '" + textBoxCheckupTime.Text + "', '" + textBoxCheckupDate.Text + "', '" + DataContainer.week
            + "', '" + ci.ToString() + "', '" + textBoxCheckupJMBG.Text +"');", db.GetConnection());

            cmd.ExecuteNonQuery();

            //ubacujemo i ostale kontrole
            int weekToAdd = DataContainer.week;
            String dateToAdd = textBoxCheckupDate.Text;
            for (int i = 0; i < Int16.Parse(textBoxCheckupNumber.Text); i++)
            {
                //datum prepravljamo
                DateTime dateToAddDT = DateTime.Parse(dateToAdd.Substring(1, dateToAdd.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
                var novDatum = dateToAddDT.AddDays(7 * Int16.Parse(textBoxCheckupPeriod.Text)).ToString(" d. MMMM yyyy. ", ci);
                dateToAdd = "[" + novDatum + "]";
                //nedelju prepravljamo
                weekToAdd += Int16.Parse(textBoxCheckupPeriod.Text);

                cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
                    textBoxCheckupProblem.Text + "', '" + DataContainer.service + "', '" + "0" + "', '" + textBoxCheckupPatient.Text
                    + "', '" + textBoxCheckupDoctor.Text + "', '" + textBoxCheckupTime.Text + "', '" + dateToAdd + "', '" + weekToAdd
                    + "', '" + ci.ToString() + "', '" + textBoxCheckupJMBG.Text + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }


            //apdejtujemo pacijenta, controled = 1
            cmd = new MySqlCommand("UPDATE patients SET controled = '1' WHERE name = '"
                + textBoxCheckupPatient.Text + "' AND jmbg = '" + textBoxCheckupJMBG.Text + "';", db.GetConnection());

            cmd.ExecuteNonQuery();


            //ubacujemo nov odnos doktor-pacijent u clients, ako vec ne postoji
            querryPom = "SELECT * FROM clients WHERE doctorID = '" + ActiveDoctor.id + "' AND patientID = '" + textBoxCheckupJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO clients(patientID, doctorID) VALUES ('" +
                textBoxCheckupJMBG.Text + "', '" + ActiveDoctor.id + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }

            mainForm.updatePlaner(ci.Calendar);
            mainForm.Show();
            this.Dispose();
            return;
        }

        private void buttonCheckupExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
            return;
        }
    }
}
