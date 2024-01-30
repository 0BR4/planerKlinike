using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DiplomskiPlanerKlinike
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //TODO: Dodaj gde se gasi konekcija prema bazi

        public void buttonSelectLanguage_Click(object sender, EventArgs e)
        {
            if (panelSelectLanguage.Height == 144)
            {
                panelSelectLanguage.Height = 39;
            }
            else
            {
                panelSelectLanguage.Height = 144;
            }
        }

        public void buttonSerbian_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn-CS");
            this.Controls.Clear();
            InitializeComponent();

        }

        public void buttonEnglish_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
        }

        public void buttonGerman_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            this.Controls.Clear();
            InitializeComponent();
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            //String username, password;
            ActiveDoctor.username = textBoxUserName.Text;
            ActiveDoctor.password = textBoxPassword.Text;

            try
            {
                String querry = "SELECT * FROM doctors WHERE username = '" + ActiveDoctor.username + "' AND password = '" + ActiveDoctor.password + "'";
                MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());

                DataTable dtable = new DataTable();
                msda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    foreach (DataRow row in dtable.Rows)
                    {
                        ActiveDoctor.name = row["name"].ToString();
                        ActiveDoctor.specialization = row["specialization"].ToString();
                        ActiveDoctor.surgery = (bool)(row["surgery"]);
                        ActiveDoctor.id = Int16.Parse(row["id"].ToString());
                    }
                        
                    FormPlanerKlinike formPlanerKlinike = new FormPlanerKlinike();
                    formPlanerKlinike.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBoxUserName.Clear();
                    textBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                //TODO: mozda ovde mogu da zatvorim konekciju?
            }
        }

        public void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxUserName.Focus();
        }

        public void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                this.Show();
            }
        }

        //enter je login
        public void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }

        //enter je login
        public void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }

        //prikazi sifru
        public void buttonShowPassword_Click(object sender, EventArgs e)
        {
            buttonHidePassword.BringToFront();
            textBoxPassword.UseSystemPasswordChar = false;
        }

        //sakrij sifru
        public void buttonHidePassword_Click(object sender, EventArgs e)
        {
            buttonShowPassword.BringToFront();
            textBoxPassword.UseSystemPasswordChar = true;
             
        }
    }

    public static class ActiveDoctor
    {
        public static int id;
        public static String username;
        public static String password;
        public static String name;
        public static String specialization;
        public static bool surgery; //moze da bude i int
    }
}
