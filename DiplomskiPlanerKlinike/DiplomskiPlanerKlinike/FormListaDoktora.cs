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
    public partial class FormListaDoktora : Form
    {
        public FormListaDoktora()
        {
            InitializeComponent();
        }

        private FormPlanerKlinike mainForm = null;

        public FormListaDoktora(Form callingForm)
        {
            mainForm = callingForm as FormPlanerKlinike;
            InitializeComponent();
        }       

        DataTable dtable;

        private void FormListaDoktora_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            String querry = "SELECT * FROM doctors;";
            MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
            dtable = new DataTable();
            msda.Fill(dtable);

            dataGridViewDoctors.DataSource = dtable;
            dataGridViewDoctors.Columns["username"].Visible = false;
            dataGridViewDoctors.Columns["password"].Visible = false;
        }

        private void buttonSelectPagesListDoc_Click(object sender, EventArgs e)
        {
            if (panelSelectPagesListDoc.Height == 159)
            {
                panelSelectPagesListDoc.Height = 42;
            }
            else
            {
                panelSelectPagesListDoc.Height = 159;
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

        private void buttonSchedulerListDoc_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mainForm.Show();
        }

        private void buttonListPatientsListDoc_Click(object sender, EventArgs e)
        {
            FormListaPacijenata formListPat = new FormListaPacijenata(this.mainForm);
            formListPat.Show();
            this.Dispose();
        }

        private void buttonClinicStatisticListDoc_Click(object sender, EventArgs e)
        {
            FormStatistika formStat = new FormStatistika(this.mainForm);
            formStat.Show();
            this.Dispose();
        }

        private void textBoxListDocName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = "name LIKE '" + textBoxListDocName.Text + "%'";
            dataGridViewDoctors.DataSource = dv;
        }

        private void textBoxListDocSpec_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = "specialization LIKE '" + textBoxListDocSpec.Text + "%'";
            dataGridViewDoctors.DataSource = dv;
        }

        private void textBoxListDocID_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(id, System.String) like '%{0}%'", textBoxListDocID.Text);
            dataGridViewDoctors.DataSource = dv;
        }

        private void checkBoxSurgery_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dtable.DefaultView;
            dv.RowFilter = string.Format("CONVERT(surgery, System.String) like '%{0}%'", checkBoxSurgery.Checked);
            dataGridViewDoctors.DataSource = dv;
        }
    }
}
