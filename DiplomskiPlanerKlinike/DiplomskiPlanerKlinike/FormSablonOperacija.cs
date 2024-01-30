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
    public partial class FormSablonOperacija : Form
    {
        List<String> codes = new List<String>();

        public FormSablonOperacija()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormSablonOperacija(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        private void FormSablonOperacija_Load(object sender, EventArgs e)
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

            textBoxOperationCode.AutoCompleteCustomSource = codeSuggestion;
            textBoxOperationCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxOperationCode.AutoCompleteSource = AutoCompleteSource.CustomSource;


            //uzimamo dan iz glavne forme
            switch (DataContainer.day.ToString())
            {
                case "Monday":
                case "Ponedeljak":
                case "Monntag":
                    textBoxOperationDate.Text = this.mainForm.LabelMondayText;
                    break;
                case "Tuesday":
                case "Utorak":
                case "Dienstag":
                    textBoxOperationDate.Text = this.mainForm.LabelTuesdayText;
                    break;
                case "Wednesday":
                case "Sreda":
                case "Mittwoch":
                    textBoxOperationDate.Text = this.mainForm.LabelWednesdayText;
                    break;
                case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
                    textBoxOperationDate.Text = this.mainForm.LabelThursdayText;
                    break;
                case "Friday":
                case "Petak":
                case "Freitag":
                    textBoxOperationDate.Text = this.mainForm.LabelFridayText;
                    break;
                case "Saturday":
                case "Subota":
                case "Samstag":
                    textBoxOperationDate.Text = this.mainForm.LabelSaturdayText;
                    break;
                case "Sunday":
                case "Nedelja":
                case "Sonntag":
                    textBoxOperationDate.Text = this.mainForm.LabelSundayText;
                    break;
            }

            //uzimamo vreme iz glavne forme
            TimeSpan result = TimeSpan.FromHours(DataContainer.time);
            textBoxOperationTime.Text = result.ToString("hh':'mm");

            //uzimamo ulogovanog doktora iz glavne forme
            db = new DBConnect();
            querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
            msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);
            DataRow row = dtable.Rows[0];
            textBoxOperationDoctor.Text = row["name"].ToString();
        }

        private void buttonOperationConfirm_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            //proveravamo dal je pacijent prevashodno zavrsio laboratoriju
            String querry = "SELECT * FROM patients WHERE name = '" + textBoxOperationPatient.Text + "' AND jmbg = '" + textBoxOperationJMBG.Text + "'";
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

            //proveravamo da li je pacijent zauzet za navedeno vreme i datum
            //(moguci scenario ako vise doktora pokusavaju da zakazu u isti termin istom pacijentu)
            String querryPom = "SELECT * FROM events WHERE patientId = '" + textBoxOperationJMBG.Text + "' AND time = '" + textBoxOperationTime.Text + "'";
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

                    if (datumEventaUCi == textBoxOperationDate.Text)
                    {
                        MessageBox.Show("Pacijent je zauzet u datom terminu!");
                        mainForm.Show();
                        this.Dispose();
                        return;
                    }
                }
            }

            //proveravamo jel dobra sifra
            if (!codes.Contains(textBoxOperationCode.Text))
            {
                MessageBox.Show("Pogresna sifra bolesti, probaj ponovo!");
                textBoxOperationCode.Clear();
                return;
            }

            //proveravamo jel laboratorija pre nove operacije
            querry = "SELECT * FROM events WHERE patientId = '" + textBoxOperationJMBG.Text + "' AND service = 'Laboratory'";
            msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);
            CultureInfo cid = new CultureInfo(dtable.Rows[dtable.Rows.Count - 1]["cultureInfo"].ToString());

            ////cuvamo vreme
            DateTime labTime = DateTime.ParseExact(dtable.Rows[dtable.Rows.Count - 1]["time"].ToString(), "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault);

            ////cuvamo datum           
            String strDatumEventa = dtable.Rows[dtable.Rows.Count - 1]["date"].ToString();
            DateTime labDate = DateTime.ParseExact(strDatumEventa.Substring(1, strDatumEventa.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);

            if (labDate > DateTime.ParseExact(textBoxOperationDate.Text.Substring(1, textBoxOperationDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati operaciju na datum koji je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }
            else if (labDate == DateTime.ParseExact(textBoxOperationDate.Text.Substring(1, textBoxOperationDate.Text.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault) &&
                labTime > DateTime.ParseExact(textBoxOperationTime.Text, "HH:mm", cid, DateTimeStyles.NoCurrentDateDefault))
            {
                MessageBox.Show("Nemoguce je zakazati operaciju u vreme koje je pre laboratorije!");
                mainForm.Show();
                this.Dispose();
                return;
            }


            //ubacujemo novi event            
            MySqlCommand cmd = new MySqlCommand("INSERT INTO events(description, service, reacurring, patient, doctor, time, date, week, cultureInfo, patientId) VALUES ('" +
            textBoxOperationProblem.Text + "', '" + DataContainer.service + "', '" + "0" + "', '" + textBoxOperationPatient.Text
            + "', '" + textBoxOperationDoctor.Text + "', '" + textBoxOperationTime.Text + "', '" + textBoxOperationDate.Text + "', '" + DataContainer.week
            + "', '" + ci.ToString() + "', '" + textBoxOperationJMBG.Text + "');", db.GetConnection());

            cmd.ExecuteNonQuery();

            //apdejtujemo pacijenta, operated = 1
            cmd = new MySqlCommand("UPDATE patients SET operated = '1', code = '" + textBoxOperationCode.Text + "' WHERE name = '"
                + textBoxOperationPatient.Text + "' AND jmbg = '" + textBoxOperationJMBG.Text + "';", db.GetConnection());

            cmd.ExecuteNonQuery();


            //ubacujemo nov odnos doktor-pacijent u clients, ako vec ne postoji
            querryPom = "SELECT * FROM clients WHERE doctorID = '" + ActiveDoctor.id + "' AND patientID = '" + textBoxOperationJMBG.Text + "'";
            msdaPom = new MySqlDataAdapter(querryPom, db.GetConnection());
            dtablePom = new DataTable();
            msdaPom.Fill(dtablePom);
            if (dtablePom.Rows.Count == 0)
            {
                cmd = new MySqlCommand("INSERT INTO clients(patientID, doctorID) VALUES ('" +
                textBoxOperationJMBG.Text + "', '" + ActiveDoctor.id + "');", db.GetConnection());

                cmd.ExecuteNonQuery();
            }

            //ubacujemo nov podatak za pacijenta u history
            cmd = new MySqlCommand("INSERT INTO history(patientID, code, service, time, date) VALUES ('" + textBoxOperationJMBG.Text + "', '" +
                textBoxOperationCode.Text + "', 'Operation', '" + textBoxOperationTime.Text + "', '" + textBoxOperationDate.Text + "');", db.GetConnection());

            cmd.ExecuteNonQuery();


            mainForm.updatePlaner(ci.Calendar);
            mainForm.Show();
            this.Dispose();
            return;
        }

        private void buttonOperationClear_Click(object sender, EventArgs e)
        {
            textBoxOperationPatient.Clear();
            textBoxOperationJMBG.Clear();
            textBoxOperationProblem.Clear();
            textBoxOperationCode.Clear();
            textBoxOperationPatient.Focus();
        }

        private void buttonOperationExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
            return;
        }
    }
}
