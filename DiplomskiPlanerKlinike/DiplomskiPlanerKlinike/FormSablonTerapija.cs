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
    public partial class FormSablonTerapija : Form
    {
        List<String> codes = new List<String>();

        public FormSablonTerapija()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormSablonTerapija(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormSablonTerapija_Load(object sender, EventArgs e)
        {
            //kod da predlaze sifre
            DBConnect db = new DBConnect();
            String querry = "SELECT * FROM codebook";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());

            DataTable dtable = new DataTable();
            msda.Fill(dtable);

            foreach (DataRow r in dtable.Rows)
                codes.Add(r["code"].ToString());

            AutoCompleteStringCollection codeSuggestion = new AutoCompleteStringCollection();

            foreach (string c in codes)
                codeSuggestion.Add(c);

            textBoxTherapyCode.AutoCompleteCustomSource = codeSuggestion;
            textBoxTherapyCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxTherapyCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //uzimamo dan iz glavne forme
            switch (DataContainer.day.ToString())
            {
                case "Monday":
                case "Ponedeljak":
                case "Monntag":
                    textBoxTherapyDate.Text = this.mainForm.LabelMondayText;
                    break;
                case "Tuesday":
                case "Utorak":
                case "Dienstag":
                    textBoxTherapyDate.Text = this.mainForm.LabelTuesdayText;
                    break;
                case "Wednesday":
                case "Sreda":
                case "Mittwoch":
                    textBoxTherapyDate.Text = this.mainForm.LabelWednesdayText;
                    break;
                case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
                    textBoxTherapyDate.Text = this.mainForm.LabelThursdayText;
                    break;
                case "Friday":
                case "Petak":
                case "Freitag":
                    textBoxTherapyDate.Text = this.mainForm.LabelFridayText;
                    break;
                case "Saturday":
                case "Subota":
                case "Samstag":
                    textBoxTherapyDate.Text = this.mainForm.LabelSaturdayText;
                    break;
                case "Sunday":
                case "Nedelja":
                case "Sonntag":
                    textBoxTherapyDate.Text = this.mainForm.LabelSundayText;
                    break;
            }

            //uzimamo vreme iz glavne forme
            TimeSpan result = TimeSpan.FromHours(DataContainer.time);
            textBoxTherapyTime.Text = result.ToString("hh':'mm");

            //uzimamo ulogovanog doktora iz glavne forme
            db = new DBConnect();
            querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
            msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);
            DataRow row = dtable.Rows[0];
            textBoxTherapyDoctor.Text = row["name"].ToString();
        }

        //cisti sva polja u pregled formi
        private void buttonTherapyClear_Click(object sender, EventArgs e)
        {
            textBoxTherapyPatient.Clear();
            textBoxTherapyJMBG.Clear();
            textBoxTherapyProblem.Clear();
            textBoxTherapyPatient.Focus();
        }

        //gasi pregled formu
        private void buttonTherapyExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
            return;
        }

        //ubacuje nov event "pregled" u planer i gasi pregled formu
        private void buttonTherapyConfirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            //proveravamo dal je pacijent prevashodno zavrsio laboratoriju
            String querry = "SELECT * FROM patients WHERE name = '" + textBoxTherapyPatient.Text + "' AND jmbg = '" + textBoxTherapyJMBG.Text + "'";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            DataTable dtable = new DataTable();
            msda.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                foreach (DataRow row in dtable.Rows)
                {
                    if (!(bool)row["labed"])
                    {
                        MessageBox.Show("Pacijent nije odradio laboratoriju!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //proveravamo jel laboratorija pre nove terapije
            querry = "SELECT * FROM events WHERE patientId = '" + textBoxTherapyJMBG.Text + "' AND service = 'Laboratory'";
            msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);
            CultureInfo cid = new CultureInfo(dtable.Rows[dtable.Rows.Count - 1]["cultureInfo"].ToString());

            ////cuvamo vreme
            DateTime labTime = DateTime.ParseExact(dtable.Rows[dtable.Rows.Count - 1]["time"].ToString(), "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault);

            ////cuvamo datum           
            String strDatumEventa = dtable.Rows[dtable.Rows.Count - 1]["date"].ToString();
            DateTime labDate = DateTime.ParseExact(strDatumEventa.Substring(1, strDatumEventa.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);

            if (labDate > DateTime.ParseExact(textBoxTherapyDate.Text.Substring(1, textBoxTherapyDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati terapiju na datum koji je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }
            else if (labDate == DateTime.ParseExact(textBoxTherapyDate.Text.Substring(1, textBoxTherapyDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault) &&
                labTime > DateTime.ParseExact(textBoxTherapyTime.Text, "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati terapiju u vreme koje je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }

            //proveravamo da li je pacijent zauzet za navedeno vreme i datum
            //(moguci scenario ako vise doktora pokusavaju da zakazu u isti termin istom pacijentu)
            String querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxTherapyJMBG.Text + "' AND time = '" + textBoxTherapyTime.Text + "'";
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

                    if (datumEventaUCi == textBoxTherapyDate.Text)
                    {
                        MessageBox.Show("Pacijent je zauzet u datom terminu!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }


            //proveravamo jel dobra sifra
            if (!codes.Contains(textBoxTherapyCode.Text))
            {
                MessageBox.Show("Pogresna sifra bolesti, probaj ponovo!");
                textBoxTherapyCode.Clear();
                return;
            }

            //ubacujemo novi event
            MySqlCommand cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
            textBoxTherapyProblem.Text + "', '" + DataContainer.service + "', '" + textBoxTherapyRevisits.Text + "', '" + textBoxTherapyPatient.Text
            + "', '" + textBoxTherapyDoctor.Text + "', '" + textBoxTherapyTime.Text + "', '" + textBoxTherapyDate.Text + "', '" + DataContainer.week
            + "', '" + ci.ToString() + "', '" + textBoxTherapyJMBG.Text + "');", db.GetConnection());

            cmd.ExecuteNonQuery();



            //apdejtujemo pacijenta, therapied = 1
            cmd = new MySqlCommand("UPDATE patients SET therapied = '1', code = '" + textBoxTherapyCode.Text + "' WHERE name = '" 
                + textBoxTherapyPatient.Text + "' AND jmbg = '" + textBoxTherapyJMBG.Text + "';", db.GetConnection());

            cmd.ExecuteNonQuery();

            //ubacujemo nov odnos doktor-pacijent u clients, ako vec ne postoji
            querryPom = "SELECT * FROM clients WHERE doctorID = '" + ActiveDoctor.id + "' AND patientID = '" + textBoxTherapyJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO clients(patientID, doctorID) VALUES ('" +
                textBoxTherapyJMBG.Text + "', '" + ActiveDoctor.id + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }

            //ubacujemo nov podatak za pacijenta u history
            cmd = new MySqlCommand("INSERT INTO history(patientID, code, service, time, date) VALUES ('" + textBoxTherapyJMBG.Text + "', '" + 
                textBoxTherapyCode.Text + "', 'Therapy', '"+ textBoxTherapyTime.Text + "', '" + textBoxTherapyDate.Text + "');", db.GetConnection());

            cmd.ExecuteNonQuery();


            mainForm.updatePlaner(ci.Calendar);
            mainForm.Show();
            this.Dispose();
            return;
        }

    }    
}
