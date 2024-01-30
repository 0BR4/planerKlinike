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
    public partial class FormListaPacijenata : Form
    {
        public FormListaPacijenata()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormListaPacijenata(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }

        DataTable dtable;

        private void FormListaPacijenata_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            String querry = "SELECT * FROM patients;";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);

            dataGridViewPatients.DataSource = dtable;
            
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

        private void buttonSelectPagesListPat_Click(object sender, EventArgs e)
        {
            if (panelSelectPagesListPat.Height == 159)
            {
                panelSelectPagesListPat.Height = 42;
            }
            else
            {
                panelSelectPagesListPat.Height = 159;
            }
        }

        private void buttonListPatientsScheduler_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
        }

        private void buttonListDoctorsListPat_Click(object sender, EventArgs e)
        {
            FormListaDoktora formListDoc = new FormListaDoktora(this.mainForm);
            formListDoc.Show();
            this.Dispose();
        }

        private void buttonClinicStatisticListPat_Click(object sender, EventArgs e)
        {
            FormStatistika formStat = new FormStatistika(this.mainForm);
            formStat.Show();
            this.Dispose();
        }

        private void textBoxListDocName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = "name LIKE '" + textBoxListPatName.Text + "%'";
            dataGridViewPatients.DataSource = dv;
        }

        private void textBoxListPatID_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(jmbg, System.String) like '%{0}%'", textBoxListPatID.Text);
            dataGridViewPatients.DataSource = dv;
        }

        private void checkBoxChecked_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(checked, System.String) like '%{0}%'", checkBoxExam.Checked);
            dataGridViewPatients.DataSource = dv;
        }

        private void checkBoxLab_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(labed, System.String) like '%{0}%'", checkBoxLab.Checked);
            dataGridViewPatients.DataSource = dv;
        }

        private void checkBoxTherapy_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(therapied, System.String) like '%{0}%'", checkBoxTherapy.Checked);
            dataGridViewPatients.DataSource = dv;
        }

        private void checkBoxOperation_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(operated, System.String) like '%{0}%'", checkBoxOperation.Checked);
            dataGridViewPatients.DataSource = dv;
        }

        private void checkBoxCheckup_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(controled, System.String) like '%{0}%'", checkBoxCheckup.Checked);
            dataGridViewPatients.DataSource = dv;
        }
    }
}
