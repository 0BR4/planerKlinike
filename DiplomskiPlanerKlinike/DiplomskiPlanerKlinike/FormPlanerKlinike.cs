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
	public partial class FormPlanerKlinike : Form
	{
        //lista panela
        List<Panel> activePanels = new List<Panel>();

        public FormPlanerKlinike()
		{
			InitializeComponent();

            #region Kreiramo listu panela            
            activePanels.Add(panel8Mon);
            activePanels.Add(panel8Tue);
            activePanels.Add(panel8Wed);
            activePanels.Add(panel8Thu);
            activePanels.Add(panel8Fri);
            activePanels.Add(panel8Sat);
            activePanels.Add(panel8Sun);
            activePanels.Add(panel9Mon);
            activePanels.Add(panel9Tue);
            activePanels.Add(panel9Wed);
            activePanels.Add(panel9Thu);
            activePanels.Add(panel9Fri);
            activePanels.Add(panel9Sat);
            activePanels.Add(panel9Sun);
            activePanels.Add(panel10Mon);
            activePanels.Add(panel10Tue);
            activePanels.Add(panel10Wed);
            activePanels.Add(panel10Thu);
            activePanels.Add(panel10Fri);
            activePanels.Add(panel10Sat);
            activePanels.Add(panel10Sun);
            activePanels.Add(panel11Mon);
            activePanels.Add(panel11Tue);
            activePanels.Add(panel11Wed);
            activePanels.Add(panel11Thu);
            activePanels.Add(panel11Fri);
            activePanels.Add(panel11Sat);
            activePanels.Add(panel11Sun);
            activePanels.Add(panel12Mon);
            activePanels.Add(panel12Tue);
            activePanels.Add(panel12Wed);
            activePanels.Add(panel12Thu);
            activePanels.Add(panel12Fri);
            activePanels.Add(panel12Sat);
            activePanels.Add(panel12Sun);
            activePanels.Add(panel13Mon);
            activePanels.Add(panel13Tue);
            activePanels.Add(panel13Wed);
            activePanels.Add(panel13Thu);
            activePanels.Add(panel13Fri);
            activePanels.Add(panel13Sat);
            activePanels.Add(panel13Sun);
            activePanels.Add(panel14Mon);
            activePanels.Add(panel14Tue);
            activePanels.Add(panel14Wed);
            activePanels.Add(panel14Thu);
            activePanels.Add(panel14Fri);
            activePanels.Add(panel14Sat);
            activePanels.Add(panel14Sun);
            activePanels.Add(panel15Mon);
            activePanels.Add(panel15Tue);
            activePanels.Add(panel15Wed);
            activePanels.Add(panel15Thu);
            activePanels.Add(panel15Fri);
            activePanels.Add(panel15Sat);
            activePanels.Add(panel15Sun);
            activePanels.Add(panel16Mon);
            activePanels.Add(panel16Tue);
            activePanels.Add(panel16Wed);
            activePanels.Add(panel16Thu);
            activePanels.Add(panel16Fri);
            activePanels.Add(panel16Sat);
            activePanels.Add(panel16Sun);
            activePanels.Add(panel17Mon);
            activePanels.Add(panel17Tue);
            activePanels.Add(panel17Wed);
            activePanels.Add(panel17Thu);
            activePanels.Add(panel17Fri);
            activePanels.Add(panel17Sat);
            activePanels.Add(panel17Sun);
            activePanels.Add(panel18Mon);
            activePanels.Add(panel18Tue);
            activePanels.Add(panel18Wed);
            activePanels.Add(panel18Thu);
            activePanels.Add(panel18Fri);
            activePanels.Add(panel18Sat);
            activePanels.Add(panel18Sun);
            activePanels.Add(panel19Mon);
            activePanels.Add(panel19Tue);
            activePanels.Add(panel19Wed);
            activePanels.Add(panel19Thu);
            activePanels.Add(panel19Fri);
            activePanels.Add(panel19Sat);
            activePanels.Add(panel19Sun);
            activePanels.Add(panel20Mon);
            activePanels.Add(panel20Tue);
            activePanels.Add(panel20Wed);
            activePanels.Add(panel20Thu);
            activePanels.Add(panel20Fri);
            activePanels.Add(panel20Sat);
            activePanels.Add(panel20Sun);
            activePanels.Add(panel21Mon);
            activePanels.Add(panel21Tue);
            activePanels.Add(panel21Wed);
            activePanels.Add(panel21Thu);
            activePanels.Add(panel21Fri);
            activePanels.Add(panel21Sat);
            activePanels.Add(panel21Sun);
            #endregion
        }

        private void buttonSelectPagesScheduler_Click(object sender, EventArgs e)
		{
			if (panelSelectPagesScheduler.Height == 159)
			{
				panelSelectPagesScheduler.Height = 42;
			}
			else
			{
				panelSelectPagesScheduler.Height = 159;
			}
		}

		private void FormPlanerKlinike_Load(object sender, EventArgs e)
		{
            
            //popunjava inicijalno datume u planeru
            //na osnovu danasnjeg dana pravilno popuni planer od ponedeljka do nedelje
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
			DayOfWeek today = ci.Calendar.GetDayOfWeek(DateTime.Today);

			//sacuvaj aktuelnu nedelju
			DataContainer.week = ci.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

			//sacuvaj aktuelnu godinu
			DataContainer.year = DateTime.Now.Year;           

            //ucitavamo labele
			switch (today)
			{
				case DayOfWeek.Monday:
					//ponedeljak
					var mondayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					var tuesdayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					var wednesdayDate = DateTime.Now.AddDays(2).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					var thursdayDate = DateTime.Now.AddDays(3).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					var fridayDate = DateTime.Now.AddDays(4).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					var saturdayDate = DateTime.Now.AddDays(5).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					var sundayDate = DateTime.Now.AddDays(6).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Tuesday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.AddDays(2).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.AddDays(3).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.AddDays(4).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.AddDays(5).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Wednesday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-2).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.AddDays(2).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.AddDays(3).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.AddDays(4).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Thursday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-3).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.AddDays(-2).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.AddDays(2).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.AddDays(3).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Friday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-4).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.AddDays(-3).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.AddDays(-2).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.AddDays(2).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Saturday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-5).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.AddDays(-4).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.AddDays(-3).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.AddDays(-2).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.AddDays(1).ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;
				case DayOfWeek.Sunday:
					//ponedeljak
					mondayDate = DateTime.Now.AddDays(-6).ToString(" d. MMMM yyyy. ", ci);
					labelMondayDate.Text = "[" + mondayDate + "]";

					//utorak
					tuesdayDate = DateTime.Now.AddDays(-5).ToString(" d. MMMM yyyy. ", ci);
					labelTuesdayDate.Text = "[" + tuesdayDate + "]";

					//sreda
					wednesdayDate = DateTime.Now.AddDays(-4).ToString(" d. MMMM yyyy. ", ci);
					labelWednesdayDate.Text = "[" + wednesdayDate + "]";

					//cetvrtak
					thursdayDate = DateTime.Now.AddDays(-3).ToString(" d. MMMM yyyy. ", ci);
					labelThursdayDate.Text = "[" + thursdayDate + "]";

					//petak
					fridayDate = DateTime.Now.AddDays(-2).ToString(" d. MMMM yyyy. ", ci);
					labelFridayDate.Text = "[" + fridayDate + "]";

					//subota
					saturdayDate = DateTime.Now.AddDays(-1).ToString(" d. MMMM yyyy. ", ci);
					labelSaturdayDate.Text = "[" + saturdayDate + "]";

					//nedelja
					sundayDate = DateTime.Now.ToString(" d. MMMM yyyy. ", ci);
					labelSundayDate.Text = "[" + sundayDate + "]";
					break;

			}

			this.updatePlaner(ci.Calendar);

			//informacije koje ogranicavaju doktora
			if (!ActiveDoctor.surgery)
				buttonOperation.Draggable(false);

            //ogranicavanje doktora za usluge na osnovu specijalizacije
			switch (ActiveDoctor.specialization)
			{
				case "Laborant":
					buttonExamination.Draggable(false);
					buttonOperation.Draggable(false);
					buttonTherapy.Draggable(false);
					buttonCheckUp.Draggable(false);
					break;
                case "Endokrinolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Internista":
                    buttonLaboratory.Draggable(false);
                    buttonOperation.Draggable(false);
                    break;
                case "Onkolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Infektolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Neurolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Ginekolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Urolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Opsta medicina":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Ortoped":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Kardiolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Oftalmolog":
                    buttonLaboratory.Draggable(false);
                    break;
                case "Radiolog":
                    buttonLaboratory.Draggable(false);
                    buttonOperation.Draggable(false);
                    buttonTherapy.Draggable(false);
                    buttonCheckUp.Draggable(false);
                    break;
            }
		}

		#region datum get/set
		//getteri i setter za labele dana, da preuzimam datume iz drugih formi
		public string LabelMondayText
		{
			get { return labelMondayDate.Text; }
			set { labelMondayDate.Text = value; }
		}
		public string LabelTuesdayText
		{
			get { return labelTuesdayDate.Text; }
			set { labelTuesdayDate.Text = value; }
		}
		public string LabelWednesdayText
		{
			get { return labelWednesdayDate.Text; }
			set { labelWednesdayDate.Text = value; }
		}
		public string LabelThursdayText
		{
			get { return labelThursdayDate.Text; }
			set { labelThursdayDate.Text = value; }
		}
		public string LabelFridayText
		{
			get { return labelFridayDate.Text; }
			set { labelFridayDate.Text = value; }
		}
		public string LabelSaturdayText
		{
			get { return labelSaturdayDate.Text; }
			set { labelSaturdayDate.Text = value; }
		}
		public string LabelSundayText
		{
			get { return labelSundayDate.Text; }
			set { labelSundayDate.Text = value; }
		}
		#endregion

		//prikazuje sledecih nedelju dana u kalendaru
		private void buttonNext_Click(object sender, EventArgs e)
		{
			CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

			//apdejtujemo aktuelnu nedelju
			DataContainer.week += 1;
			if (DataContainer.week > this.getWeeksInYear(DataContainer.year, ci))
			{
				DataContainer.year += 1;
				DataContainer.week = 1;              
			}

			//ponedeljak
			DateTime datum = DateTime.Parse(labelMondayDate.Text.Substring(1, labelMondayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			var novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelMondayDate.Text = "[" + novDatum + "]";

			//utorak
			datum = DateTime.Parse(labelTuesdayDate.Text.Substring(1, labelTuesdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelTuesdayDate.Text = "[" + novDatum + "]";

			//sreda
			datum = DateTime.Parse(labelWednesdayDate.Text.Substring(1, labelWednesdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelWednesdayDate.Text = "[" + novDatum + "]";

			//cetvrtak
			datum = DateTime.Parse(labelThursdayDate.Text.Substring(1, labelThursdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelThursdayDate.Text = "[" + novDatum + "]";

			//petak
			datum = DateTime.Parse(labelFridayDate.Text.Substring(1, labelFridayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelFridayDate.Text = "[" + novDatum + "]";

			//subota
			datum = DateTime.Parse(labelSaturdayDate.Text.Substring(1, labelSaturdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelSaturdayDate.Text = "[" + novDatum + "]";

			//nedelja
			datum = DateTime.Parse(labelSundayDate.Text.Substring(1, labelSundayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(7).ToString(" d. MMMM yyyy. ", ci);
			labelSundayDate.Text = "[" + novDatum + "]";


			this.updatePlaner(ci.Calendar);
		}

		//prikazuje prethodnih nedelju dana u kalendaru
		private void buttonPrevious_Click(object sender, EventArgs e)
		{           
			CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

			//apdejtujemo aktuelnu nedelju
			DataContainer.week -= 1;
			if (DataContainer.week < 1)
			{
				DataContainer.year -= 1;
				DataContainer.week = this.getWeeksInYear(DataContainer.year, ci);
			}

			//ponedeljak
			DateTime datum = DateTime.Parse(labelMondayDate.Text.Substring(1, labelMondayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			var novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelMondayDate.Text = "[" + novDatum + "]";

			//utorak
			datum = DateTime.Parse(labelTuesdayDate.Text.Substring(1, labelTuesdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelTuesdayDate.Text = "[" + novDatum + "]";

			//sreda
			datum = DateTime.Parse(labelWednesdayDate.Text.Substring(1, labelWednesdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelWednesdayDate.Text = "[" + novDatum + "]";

			//cetvrtak
			datum = DateTime.Parse(labelThursdayDate.Text.Substring(1, labelThursdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelThursdayDate.Text = "[" + novDatum + "]";

			//petak
			datum = DateTime.Parse(labelFridayDate.Text.Substring(1, labelFridayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelFridayDate.Text = "[" + novDatum + "]";

			//subota
			datum = DateTime.Parse(labelSaturdayDate.Text.Substring(1, labelSaturdayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelSaturdayDate.Text = "[" + novDatum + "]";

			//nedelja
			datum = DateTime.Parse(labelSundayDate.Text.Substring(1, labelSundayDate.Text.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
			novDatum = datum.AddDays(-7).ToString(" d. MMMM yyyy. ", ci);
			labelSundayDate.Text = "[" + novDatum + "]";


			this.updatePlaner(ci.Calendar);
		}

		//filtrira planer
		private void buttonSchedulerFilter_Click(object sender, EventArgs e)
		{
			CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
			this.updatePlaner(ci.Calendar);
            //MessageBox.Show("DEBUG: Uso sam u filter klik funkciju!");

            foreach(var panel in activePanels)
            {
                //MessageBox.Show("Uso sam u foreach za panel: " + panel.Name + ", TabIndex je: " + panel.TabIndex.ToString());
                #region Na osnovu TabIndexa apdejtujemo panele postujuci filtere
                //pomocne za hvatanje imena pacijenta
                int pFrom, pTo;
                String patientName = "";

                switch (panel.TabIndex)
                {
                    case 1:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                {
                                    patientName = ToolTipsText.Mon8.Substring(pFrom, pTo - pFrom);
                                }
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Mon.BackColor = Color.White;
                            ToolTipsText.Mon8 = "";
                            toolTipMon8.Hide(panel8Mon);
                        }
                        break;
                    case 2:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Tue.BackColor = Color.White;
                            ToolTipsText.Tue8 = "";
                            toolTipTue8.Hide(panel8Tue);
                        }
                        break;
                    case 3:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Wed.BackColor = Color.White;
                            ToolTipsText.Wed8 = "";
                            toolTipWed8.Hide(panel8Wed);
                        }
                        break;
                    case 4:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Thu.BackColor = Color.White;
                            ToolTipsText.Thu8 = "";
                            toolTipThu8.Hide(panel8Thu);
                        }
                        break;
                    case 5:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Fri.BackColor = Color.White;
                            ToolTipsText.Fri8 = "";
                            toolTipFri8.Hide(panel8Fri);
                        }
                        break;
                    case 6:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Sat.BackColor = Color.White;
                            ToolTipsText.Sat8 = "";
                            toolTipSat8.Hide(panel8Sat);
                        }
                        break;
                    case 7:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun8.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun8.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun8.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun8.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun8.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun8.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun8.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun8.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel8Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel8Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel8Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel8Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel8Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel8Sun.BackColor = Color.White;
                            ToolTipsText.Sun8 = "";
                            toolTipSun8.Hide(panel8Sun);
                        }
                        break;
                    case 8:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Mon.BackColor = Color.White;
                            ToolTipsText.Mon9 = "";
                            toolTipMon9.Hide(panel9Mon);
                        }
                        break;
                    case 9:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Tue.BackColor = Color.White;
                            ToolTipsText.Tue9 = "";
                            toolTipTue9.Hide(panel9Tue);
                        }
                        break;
                    case 10:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Wed.BackColor = Color.White;
                            ToolTipsText.Wed9 = "";
                            toolTipWed9.Hide(panel9Wed);
                        }
                        break;
                    case 11:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Thu.BackColor = Color.White;
                            ToolTipsText.Thu9 = "";
                            toolTipThu9.Hide(panel9Thu);
                        }
                        break;
                    case 12:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Fri.BackColor = Color.White;
                            ToolTipsText.Fri9 = "";
                            toolTipFri9.Hide(panel9Fri);
                        }
                        break;
                    case 13:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Sat.BackColor = Color.White;
                            ToolTipsText.Sat9 = "";
                            toolTipSat9.Hide(panel9Sat);
                        }
                        break;
                    case 14:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun9.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun9.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun9.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun9.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun9.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun9.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun9.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun9.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel9Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel9Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel9Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel9Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel9Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel9Sun.BackColor = Color.White;
                            ToolTipsText.Sun9 = "";
                            toolTipSun10.Hide(panel9Sun);
                        }
                        break;
                    case 15:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Mon.BackColor = Color.White;
                            ToolTipsText.Mon10 = "";
                            toolTipMon10.Hide(panel10Mon);
                        }
                        break;
                    case 16:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Tue.BackColor = Color.White;
                            ToolTipsText.Tue10 = "";
                            toolTipTue10.Hide(panel10Tue);
                        }
                        break;
                    case 17:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Wed.BackColor = Color.White;
                            ToolTipsText.Wed10 = "";
                            toolTipWed10.Hide(panel10Wed);
                        }
                        break;
                    case 18:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Thu.BackColor = Color.White;
                            ToolTipsText.Thu10 = "";
                            toolTipThu10.Hide(panel10Thu);
                        }
                        break;
                    case 19:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Fri.BackColor = Color.White;
                            ToolTipsText.Fri10 = "";
                            toolTipFri10.Hide(panel10Fri);
                        }
                        break;
                    case 20:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Sat.BackColor = Color.White;
                            ToolTipsText.Sat10 = "";
                            toolTipSat10.Hide(panel10Sat);
                        }
                        break;
                    case 21:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun10.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun10.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun10.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun10.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun10.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun10.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun10.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun10.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel10Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel10Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel10Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel10Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel10Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel10Sun.BackColor = Color.White;
                            ToolTipsText.Sun10 = "";
                            toolTipSun10.Hide(panel10Sun);
                        }
                        break;
                    case 22:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Mon.BackColor = Color.White;
                            ToolTipsText.Mon11 = "";
                            toolTipMon11.Hide(panel11Mon);
                        }
                        break;
                    case 23:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Tue.BackColor = Color.White;
                            ToolTipsText.Tue11 = "";
                            toolTipTue11.Hide(panel11Tue);
                        }
                        break;
                    case 24:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Wed.BackColor = Color.White;
                            ToolTipsText.Wed11 = "";
                            toolTipWed11.Hide(panel11Wed);
                        }
                        break;
                    case 25:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Thu.BackColor = Color.White;
                            ToolTipsText.Thu11 = "";
                            toolTipThu11.Hide(panel11Thu);
                        }
                        break;
                    case 26:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Fri.BackColor = Color.White;
                            ToolTipsText.Fri11 = "";
                            toolTipFri11.Hide(panel11Fri);
                        }
                        break;
                    case 27:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Sat.BackColor = Color.White;
                            ToolTipsText.Sat11 = "";
                            toolTipSat11.Hide(panel11Sat);
                        }
                        break;
                    case 28:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun11.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun11.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun11.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun11.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun11.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun11.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun11.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun11.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel11Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel11Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel11Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel11Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel11Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel11Sun.BackColor = Color.White;
                            ToolTipsText.Sun11 = "";
                            toolTipSun11.Hide(panel11Sun);
                        }
                        break;
                    case 29:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Mon.BackColor = Color.White;
                            ToolTipsText.Mon12 = "";
                            toolTipMon12.Hide(panel12Mon);
                        }
                        break;
                    case 30:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Tue.BackColor = Color.White;
                            ToolTipsText.Tue12 = "";
                            toolTipTue12.Hide(panel12Tue);
                        }
                        break;
                    case 31:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Wed.BackColor = Color.White;
                            ToolTipsText.Wed12 = "";
                            toolTipWed12.Hide(panel12Wed);
                        }
                        break;
                    case 32:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Thu.BackColor = Color.White;
                            ToolTipsText.Thu12 = "";
                            toolTipThu12.Hide(panel12Thu);
                        }
                        break;
                    case 33:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Fri.BackColor = Color.White;
                            ToolTipsText.Fri12 = "";
                            toolTipFri12.Hide(panel12Fri);
                        }
                        break;
                    case 34:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Sat.BackColor = Color.White;
                            ToolTipsText.Sat12 = "";
                            toolTipSat12.Hide(panel12Sat);
                        }
                        break;
                    case 35:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun12.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun12.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun12.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun12.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun12.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun12.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun12.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun12.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel12Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel12Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel12Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel12Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel12Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel12Sun.BackColor = Color.White;
                            ToolTipsText.Sun12 = "";
                            toolTipSun12.Hide(panel12Sun);
                        }
                        break;
                    case 36:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Mon.BackColor = Color.White;
                            ToolTipsText.Mon13 = "";
                            toolTipMon13.Hide(panel13Mon);
                        }
                        break;
                    case 37:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Tue.BackColor = Color.White;
                            ToolTipsText.Tue13 = "";
                            toolTipTue13.Hide(panel13Tue);
                        }
                        break;
                    case 38:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Wed.BackColor = Color.White;
                            ToolTipsText.Wed13 = "";
                            toolTipWed13.Hide(panel13Wed);
                        }
                        break;
                    case 39:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Thu.BackColor = Color.White;
                            ToolTipsText.Thu13 = "";
                            toolTipThu13.Hide(panel13Thu);
                        }
                        break;
                    case 40:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Fri.BackColor = Color.White;
                            ToolTipsText.Fri13 = "";
                            toolTipFri13.Hide(panel13Fri);
                        }
                        break;
                    case 41:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat13.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel13Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Sat.BackColor = Color.White;
                            ToolTipsText.Sat13 = "";
                            toolTipSat13.Hide(panel13Sat);
                        }
                        break;
                    case 42:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun13.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun13.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun13.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun13.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun13.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun13.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun13.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun13.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel13Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel13Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel13Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel13Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel13Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel13Sun.BackColor = Color.White;
                            ToolTipsText.Sun13 = "";
                            toolTipSun13.Hide(panel13Sun);
                        }
                        break;
                    case 43:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Mon.BackColor = Color.White;
                            ToolTipsText.Mon14 = "";
                            toolTipMon14.Hide(panel14Mon);
                        }
                        break;
                    case 44:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Tue.BackColor = Color.White;
                            ToolTipsText.Tue14 = "";
                            toolTipTue14.Hide(panel14Tue);
                        }
                        break;
                    case 45:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Wed.BackColor = Color.White;
                            ToolTipsText.Wed14 = "";
                            toolTipWed14.Hide(panel14Wed);
                        }
                        break;
                    case 46:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Thu.BackColor = Color.White;
                            ToolTipsText.Thu14 = "";
                            toolTipThu14.Hide(panel14Thu);
                        }
                        break;
                    case 47:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Fri.BackColor = Color.White;
                            ToolTipsText.Fri14 = "";
                            toolTipFri14.Hide(panel14Fri);
                        }
                        break;
                    case 48:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Sat.BackColor = Color.White;
                            ToolTipsText.Sat14 = "";
                            toolTipSat14.Hide(panel14Sat);
                        }
                        break;
                    case 49:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun14.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun14.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun14.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun14.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun14.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun14.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun14.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun14.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel14Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel14Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel14Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel14Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel14Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel14Sun.BackColor = Color.White;
                            ToolTipsText.Sun14 = "";
                            toolTipSun14.Hide(panel14Sun);
                        }
                        break;
                    case 50:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Mon.BackColor = Color.White;
                            ToolTipsText.Mon15 = "";
                            toolTipMon15.Hide(panel15Mon);
                        }
                        break;
                    case 51:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Tue.BackColor = Color.White;
                            ToolTipsText.Tue15 = "";
                            toolTipTue15.Hide(panel15Tue);
                        }
                        break;
                    case 52:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Wed.BackColor = Color.White;
                            ToolTipsText.Wed15 = "";
                            toolTipWed15.Hide(panel15Wed);
                        }
                        break;
                    case 53:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Thu.BackColor = Color.White;
                            ToolTipsText.Thu15 = "";
                            toolTipThu15.Hide(panel15Thu);
                        }
                        break;
                    case 54:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Fri.BackColor = Color.White;
                            ToolTipsText.Fri15 = "";
                            toolTipFri15.Hide(panel15Fri);
                        }
                        break;
                    case 55:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Sat.BackColor = Color.White;
                            ToolTipsText.Sat15 = "";
                            toolTipSat15.Hide(panel15Sat);
                        }
                        break;
                    case 56:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun15.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun15.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun15.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun15.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun15.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun15.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun15.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun15.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel15Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel15Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel15Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel15Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel15Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel15Sun.BackColor = Color.White;
                            ToolTipsText.Sun15 = "";
                            toolTipSun15.Hide(panel15Sun);
                        }
                        break;
                    case 57:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Mon.BackColor = Color.White;
                            ToolTipsText.Mon16 = "";
                            toolTipMon16.Hide(panel16Mon);
                        }
                        break;
                    case 58:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Tue.BackColor = Color.White;
                            ToolTipsText.Tue16 = "";
                            toolTipTue16.Hide(panel16Tue);
                        }
                        break;
                    case 59:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Wed.BackColor = Color.White;
                            ToolTipsText.Wed16 = "";
                            toolTipWed16.Hide(panel16Wed);
                        }
                        break;
                    case 60:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Thu.BackColor = Color.White;
                            ToolTipsText.Thu16 = "";
                            toolTipThu16.Hide(panel16Thu);
                        }
                        break;
                    case 61:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Fri.BackColor = Color.White;
                            ToolTipsText.Fri16 = "";
                            toolTipFri16.Hide(panel16Fri);
                        }
                        break;
                    case 62:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Sat.BackColor = Color.White;
                            ToolTipsText.Sat16 = "";
                            toolTipSat16.Hide(panel16Sat);
                        }
                        break;
                    case 63:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun16.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun16.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun16.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun16.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun16.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun16.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun16.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun16.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel16Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel16Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel16Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel16Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel16Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel16Sun.BackColor = Color.White;
                            ToolTipsText.Sun16 = "";
                            toolTipSun16.Hide(panel16Sun);
                        }
                        break;
                    case 64:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Mon.BackColor = Color.White;
                            ToolTipsText.Mon17 = "";
                            toolTipMon17.Hide(panel17Mon);
                        }
                        break;
                    case 65:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Tue.BackColor = Color.White;
                            ToolTipsText.Tue17 = "";
                            toolTipTue17.Hide(panel17Tue);
                        }
                        break;
                    case 66:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed17.Substring(pFrom, pTo - pFrom);
                                break;
                        }

                        if ((checkBoxExamination.Checked == false && panel17Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Wed.BackColor = Color.White;
                            ToolTipsText.Wed17 = "";
                            toolTipWed17.Hide(panel17Wed);
                        }
                        break;
                    case 67:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Thu.BackColor = Color.White;
                            ToolTipsText.Thu17 = "";
                            toolTipThu17.Hide(panel17Thu);
                        }
                        break;
                    case 68:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Fri.BackColor = Color.White;
                            ToolTipsText.Fri17 = "";
                            toolTipFri17.Hide(panel17Fri);
                        }
                        break;
                    case 69:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Sat.BackColor = Color.White;
                            ToolTipsText.Sat17 = "";
                            toolTipSat17.Hide(panel17Sat);
                        }
                        break;
                    case 70:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun17.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun17.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun17.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun17.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun17.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun17.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun17.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun17.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel17Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel17Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel17Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel17Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel17Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel17Sun.BackColor = Color.White;
                            ToolTipsText.Sun17 = "";
                            toolTipSun17.Hide(panel17Sun);
                        }
                        break;
                    case 71:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Mon.BackColor = Color.White;
                            ToolTipsText.Mon18 = "";
                            toolTipMon18.Hide(panel18Mon);
                        }
                        break;
                    case 72:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Tue.BackColor = Color.White;
                            ToolTipsText.Tue18 = "";
                            toolTipTue18.Hide(panel18Tue);
                        }
                        break;
                    case 73:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Wed.BackColor = Color.White;
                            ToolTipsText.Wed18 = "";
                            toolTipWed18.Hide(panel18Wed);
                        }
                        break;
                    case 74:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Thu.BackColor = Color.White;
                            ToolTipsText.Thu18 = "";
                            toolTipThu18.Hide(panel18Thu);
                        }
                        break;
                    case 75:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Fri.BackColor = Color.White;
                            ToolTipsText.Fri18 = "";
                            toolTipFri18.Hide(panel18Fri);
                        }
                        break;
                    case 76:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Sat.BackColor = Color.White;
                            ToolTipsText.Sat18 = "";
                            toolTipSat18.Hide(panel18Sat);
                        }
                        break;
                    case 77:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun18.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun18.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun18.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun18.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun18.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun18.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun18.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun18.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel18Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel18Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel18Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel18Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel18Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel18Sun.BackColor = Color.White;
                            ToolTipsText.Sun18 = "";
                            toolTipSun18.Hide(panel18Sun);
                        }
                        break;
                    case 78:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Mon.BackColor = Color.White;
                            ToolTipsText.Mon19 = "";
                            toolTipMon19.Hide(panel19Mon);
                        }
                        break;
                    case 79:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Tue.BackColor = Color.White;
                            ToolTipsText.Tue19 = "";
                            toolTipTue19.Hide(panel19Tue);
                        }
                        break;
                    case 80:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Wed.BackColor = Color.White;
                            ToolTipsText.Wed19 = "";
                            toolTipWed19.Hide(panel19Wed);
                        }
                        break;
                    case 81:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Thu.BackColor = Color.White;
                            ToolTipsText.Thu19 = "";
                            toolTipThu19.Hide(panel19Thu);
                        }
                        break;
                    case 82:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Fri.BackColor = Color.White;
                            ToolTipsText.Fri19 = "";
                            toolTipFri19.Hide(panel19Fri);
                        }
                        break;
                    case 83:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Sat.BackColor = Color.White;
                            ToolTipsText.Sat19 = "";
                            toolTipSat19.Hide(panel19Sat);
                        }
                        break;
                    case 84:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun19.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun19.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun19.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun19.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun19.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun19.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun19.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun19.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel19Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel19Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel19Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel19Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel19Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel19Sun.BackColor = Color.White;
                            ToolTipsText.Sun19 = "";
                            toolTipSun19.Hide(panel19Sun);
                        }
                        break;
                    case 85:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Mon.BackColor = Color.White;
                            ToolTipsText.Mon20 = "";
                            toolTipMon20.Hide(panel20Mon);
                        }
                        break;
                    case 86:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Tue.BackColor = Color.White;
                            ToolTipsText.Tue20 = "";
                            toolTipTue20.Hide(panel20Tue);
                        }
                        break;
                    case 87:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Wed.BackColor = Color.White;
                            ToolTipsText.Wed20 = "";
                            toolTipWed20.Hide(panel20Wed);
                        }
                        break;
                    case 88:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Thu.BackColor = Color.White;
                            ToolTipsText.Thu20 = "";
                            toolTipThu20.Hide(panel20Thu);
                        }
                        break;
                    case 89:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Fri.BackColor = Color.White;
                            ToolTipsText.Fri20 = "";
                            toolTipFri20.Hide(panel20Fri);
                        }
                        break;
                    case 90:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Sat.BackColor = Color.White;
                            ToolTipsText.Sat20 = "";
                            toolTipSat20.Hide(panel20Sat);
                        }
                        break;
                    case 91:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun20.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun20.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun20.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun20.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun20.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun20.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun20.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun20.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel20Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel20Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel20Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel20Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel20Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel20Sun.BackColor = Color.White;
                            ToolTipsText.Sun20 = "";
                            toolTipSun20.Hide(panel20Sun);
                        }
                        break;
                    case 92:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Mon21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Mon21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Mon21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Mon21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Mon21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Mon21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Mon.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Mon.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Mon.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Mon.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Mon.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Mon.BackColor = Color.White;
                            ToolTipsText.Mon21 = "";
                            toolTipMon21.Hide(panel21Mon);
                        }
                        break;
                    case 93:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Tue21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Tue21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Tue21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Tue21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Tue21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Tue21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Tue.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Tue.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Tue.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Tue.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Tue.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Tue.BackColor = Color.White;
                            ToolTipsText.Tue21 = "";
                            toolTipTue21.Hide(panel21Tue);
                        }
                        break;
                    case 94:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Wed21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Wed21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Wed21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Wed21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Wed21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Wed21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Wed.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Wed.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Wed.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Wed.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Wed.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Wed.BackColor = Color.White;
                            ToolTipsText.Wed21 = "";
                            toolTipWed21.Hide(panel21Wed);
                        }
                        break;
                    case 95:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Thu21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Thu21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Thu21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Thu21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Thu21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Thu21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Thu.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Thu.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Thu.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Thu.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Thu.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Thu.BackColor = Color.White;
                            ToolTipsText.Thu21 = "";
                            toolTipThu21.Hide(panel21Thu);
                        }
                        break;
                    case 96:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Fri21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Fri21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Fri21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Fri21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Fri21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Fri21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Fri.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Fri.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Fri.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Fri.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Fri.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Fri.BackColor = Color.White;
                            ToolTipsText.Fri21 = "";
                            toolTipFri21.Hide(panel21Fri);
                        }
                        break;
                    case 97:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sat21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sat21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sat21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sat21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sat21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sat21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Sat.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Sat.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Sat.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Sat.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Sat.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Sat.BackColor = Color.White;
                            ToolTipsText.Sat21 = "";
                            toolTipSat21.Hide(panel21Sat);
                        }
                        break;
                    case 98:
                        switch (Thread.CurrentThread.CurrentUICulture.Name)
                        {
                            case "sr - Latn - CS":
                                pFrom = ToolTipsText.Sun21.IndexOf("Pacijent: ") + "Pacijent: ".Length;
                                pTo = ToolTipsText.Sun21.LastIndexOf("\tOpis: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun21.Substring(pFrom, pTo - pFrom);
                                break;
                            case "de-DE":
                                pFrom = ToolTipsText.Sun21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun21.LastIndexOf("\tBeschreibung: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun21.Substring(pFrom, pTo - pFrom);
                                break;
                            default:
                                pFrom = ToolTipsText.Sun21.IndexOf("Patient: ") + "Patient: ".Length;
                                pTo = ToolTipsText.Sun21.LastIndexOf("\tDescription: ");
                                if (pFrom > -1 && pTo > -1)
                                    patientName = ToolTipsText.Sun21.Substring(pFrom, pTo - pFrom);
                                break;
                        }
                        if ((checkBoxExamination.Checked == false && panel21Sun.BackColor == Color.AliceBlue) ||
                            (checkBoxLab.Checked == false && panel21Sun.BackColor == Color.GreenYellow) ||
                            (checkBoxOperation.Checked == false && panel21Sun.BackColor == Color.OrangeRed) ||
                            (checkBoxTherapy.Checked == false && panel21Sun.BackColor == Color.LightPink) ||
                            (checkBoxCheckUp.Checked == false && panel21Sun.BackColor == Color.PowderBlue) ||
                            (!patientName.Contains(textBoxFilterPatient.Text) && !String.IsNullOrEmpty(textBoxFilterPatient.Text)))
                        {
                            panel21Sun.BackColor = Color.White;
                            ToolTipsText.Sun21 = "";
                            toolTipSun21.Hide(panel21Sun);
                        }
                        break;
                }//zatvaramo switch
                #endregion
            }
		}

		//mouse down za Examination
		private void buttonExamination_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonExamination.DoDragDrop(buttonExamination, DragDropEffects.Move);
			}
		}

		//mouse down za Therapy
		private void buttonTherapy_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonTherapy.DoDragDrop(buttonTherapy, DragDropEffects.Move);
			}
		}

		//mouse down za Laboratory
		private void buttonLaboratory_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonLaboratory.DoDragDrop(buttonLaboratory, DragDropEffects.Move);
			}
		}

		//mouse down za Operation
		private void buttonOperation_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonOperation.DoDragDrop(buttonOperation, DragDropEffects.Move);
			}
		}

		//mouse down za CheckUp
		private void buttonCheckUp_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonCheckUp.DoDragDrop(buttonCheckUp, DragDropEffects.Move);
			}
		}

		//mouse down za RemoveEvent
		private void buttonRemoveEvent_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				buttonRemoveEvent.DoDragDrop(buttonRemoveEvent, DragDropEffects.Move);
			}
		}

		//drag enter za panele u kalendaru
		private void panelReplica_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		//drag drop za panele u kalendaru
		private void panelReplica_DragDrop(object sender, DragEventArgs e)
		{
            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

            Button b = (Button)e.Data.GetData(typeof(Button));
			Panel p = (Panel)sender;
            //da ne ostane uokvireno kad se dropuje na njega
            p.BorderStyle = BorderStyle.None;

            //proverava da li vec ima event tu
            if (p.BackColor != Color.White && b.Text != "Remove Event")
			{
				MessageBox.Show("This time slot is already taken by another event, please select another time slot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DataContainer.day = (Day)(p.TabIndex % 7);
            if (DataContainer.day == 0)
                DataContainer.day = Day.Sunday;
			DataContainer.time = p.TabIndex / 7 + 8;

			//preuzmemo datum gde je drag-dropovan button
			String dateDroped = "";
			switch (DataContainer.day.ToString())
			{
				case "Monday":
                case "Ponedeljak":
                case "Montag":
					dateDroped = this.LabelMondayText;
					break;
				case "Tuesday":
                case "Utorak":
                case "Dienstag":
					dateDroped = this.LabelTuesdayText;
					break;
				case "Wednesday":
                case "Sreda":
                case "Mittwoch":
					dateDroped = this.LabelWednesdayText;
					break;
				case "Thursday":
                case "Četvrtak":
                case "Donnerstag":
					dateDroped = this.LabelThursdayText;
					break;
				case "Friday":
                case "Petak":
                case "Freitag":
					dateDroped = this.LabelFridayText;
					break;
				case "Saturday":
                case "Subota":
                case "Samstag":
					dateDroped = this.LabelSaturdayText;
					break;
				case "Sunday":
                case "Nedelja":
                case "Sonntag":
					dateDroped = this.LabelSundayText;
					break;
			}

			//na osnovu dragovane usluge preuzimamo sledecu akciju
			switch (b.Text)
			{
				case "Examination":
					DataContainer.service = "Examination";
					FormSablonPregled formSablonPregled = new FormSablonPregled(this);
					formSablonPregled.Show();
					break;
				case "Laboratory":
					DataContainer.service = "Laboratory";
					FormSablonLab formSablonLab = new FormSablonLab(this);
					formSablonLab.Show();
					break;
				case "Therapy":
					DataContainer.service = "Therapy";
					FormSablonTerapija formSablonTerapija = new FormSablonTerapija(this);
					formSablonTerapija.Show();
					break;
				case "Operation":
					DataContainer.service = "Operation";
					FormSablonOperacija formSablonOperacija = new FormSablonOperacija(this);
					formSablonOperacija.Show();
					break;
				case "Check-up":
					DataContainer.service = "Check-up";
					FormSablonKontrola formSablonKontrola = new FormSablonKontrola(this);
					formSablonKontrola.Show();
					break;
				case "Remove Event":                   
					//proveravamo da li je event reacurring, ako nema u bazi event sa tim vremenom i datumom -> u pitanju je reacuring event
					DBConnect db = new DBConnect();

                    MessageBox.Show("DataContainer.time je: " + TimeSpan.FromHours(DataContainer.time).ToString("hh':'mm") + " , a dateDroped je: " + dateDroped.ToString());

                    String serviceToDelete = "";
                    switch (p.BackColor.ToString())
                    {
                        case "Color [AliceBlue]":
                            serviceToDelete = "Examination";
                            break;
                        case "Color [GreenYellow]":
                            serviceToDelete = "Laboratory";
                            break;
                        case "Color [LightPink]":
                            serviceToDelete = "Therapy";
                            break;
                        case "Color [OrangeRed]":
                            serviceToDelete = "Operation";
                            break;
                        case "Color [PowderBlue]":
                            serviceToDelete = "Check-up";
                            break;
                    }
                    
                    String querry = "SELECT * FROM events WHERE time = '" + TimeSpan.FromHours(DataContainer.time).ToString("hh':'mm")
                        + "' AND doctor = '" + ActiveDoctor.name + "' AND service ='" + serviceToDelete + "'";
					MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());
					DataTable dtable = new DataTable();
					msda.Fill(dtable);

					if (dtable.Rows.Count > 0) //brise event iz baze (ako je reacuring, update planer ga svakako cisti)
					{
                        foreach (DataRow row in dtable.Rows)
                        {                   
                            //pomocna cid da znamo na kom je jeziku event jer ga takvog brisemo
                            String cie = row["cultureInfo"].ToString();
                            CultureInfo cid = new CultureInfo(cie);                      
                            DateTime datumEventa = DateTime.Parse(dateDroped.Substring(1, dateDroped.Length - 2), ci, DateTimeStyles.NoCurrentDateDefault);
                            String datumEventaUCid = datumEventa.ToString(" d. MMMM yyyy. ", cid);
                            dateDroped = "[" + datumEventaUCid + "]";

                            MySqlCommand cmd = new MySqlCommand("DELETE FROM events WHERE time = '" + TimeSpan.FromHours(DataContainer.time).ToString("hh':'mm") + "' AND date = '"
                                + dateDroped + "'", db.GetConnection());
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("The event with this time and date is deleted!");
                            this.updatePlaner(ci.Calendar);

                            if (Int16.Parse(row["reacurring"].ToString()) > 0)
                            {
                                int eventWeek = Int16.Parse((row["week"]).ToString());
                                int reacurring = Int16.Parse((row["reacurring"]).ToString());

                                for (int i = 1; i < reacurring; i++)
                                {
                                    //ako ga nadje onda ga i brise
                                    if (DataContainer.week - i == eventWeek)
                                    {
                                        int eventId = Int16.Parse((row["id"]).ToString());
                                        MySqlCommand cmdR = new MySqlCommand("DELETE FROM events WHERE id = '" + eventId + "'", db.GetConnection());
                                        cmdR.ExecuteNonQuery();

                                        MessageBox.Show("The reacurring event with this time is deleted!");

                                        //CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
                                        this.updatePlaner(ci.Calendar);
                                    }
                                }
                            }

                            //posle brisanja glavnog eventa ili reacurring eventova, imamo brisanje ostalih povezanih kontrola ako je jedna obrisana
                            cmd = new MySqlCommand("DELETE FROM events WHERE description ='" + row["description"].ToString() + "' AND time = '" +
                                TimeSpan.FromHours(DataContainer.time).ToString("hh':'mm") + "' AND patient = '" + row["patient"].ToString() +
                                "' AND doctor = '" + row["doctor"].ToString() + "'", db.GetConnection());
                            cmd.ExecuteNonQuery();

                            this.updatePlaner(ci.Calendar);
                        }
					}
					break;
			}          
		}

		//drag over za panele u kalendaru
		private void panelReplica_DragOver(object sender, DragEventArgs e)
		{
			Panel p = (Panel)sender;
			p.BorderStyle = BorderStyle.FixedSingle;
		}

		//drag leave za panele u kalendaru
		private void panelReplica_DragLeave(object sender, EventArgs e)
		{
			Panel p = (Panel)sender;
			p.BorderStyle = BorderStyle.None;
		}

		#region //mouse hover za svaki panel posebno jer svako ima svoj tooltip
		private void panel8Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon8.Show(ToolTipsText.Mon8, panel8Mon);
		}

		private void panel8Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue8.Show(ToolTipsText.Tue8, panel8Tue);
		}

		private void panel8Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed8.Show(ToolTipsText.Wed8, panel8Wed);
		}

		private void panel8Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu8.Show(ToolTipsText.Thu8, panel8Thu);
		}

		private void panel8Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri8.Show(ToolTipsText.Fri8, panel8Fri);
		}

		private void panel8Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat8.Show(ToolTipsText.Sat8, panel8Sat);
		}

		private void panel8Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun8.Show(ToolTipsText.Sun8, panel8Sun);
		}

		private void panel9Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon9.Show(ToolTipsText.Mon9, panel9Mon);
		}

		private void panel9Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue9.Show(ToolTipsText.Tue9, panel9Tue);
		}

		private void panel9Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed9.Show(ToolTipsText.Wed9, panel9Wed);
		}

		private void panel9Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu9.Show(ToolTipsText.Thu9, panel9Thu);
		}

		private void panel9Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri9.Show(ToolTipsText.Fri9, panel9Fri);
		}

		private void panel9Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat9.Show(ToolTipsText.Sat9, panel9Sat);
		}

		private void panel9Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun9.Show(ToolTipsText.Sun9, panel9Sun);
		}

		private void panel10Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon10.Show(ToolTipsText.Mon10, panel10Mon);
		}

		private void panel10Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue10.Show(ToolTipsText.Tue10, panel10Tue);
		}

		private void panel10Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed10.Show(ToolTipsText.Wed10, panel10Wed);
		}

		private void panel10Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu10.Show(ToolTipsText.Thu10, panel10Thu);
		}

		private void panel10Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri10.Show(ToolTipsText.Fri10, panel10Fri);
		}

		private void panel10Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat10.Show(ToolTipsText.Sat10, panel10Sat);
		}

		private void panel10Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun10.Show(ToolTipsText.Sun10, panel10Sun);
		}

		private void panel11Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon11.Show(ToolTipsText.Mon11, panel11Mon);
		}

		private void panel11Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue11.Show(ToolTipsText.Tue11, panel11Tue);
		}

		private void panel11Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed11.Show(ToolTipsText.Wed11, panel11Wed);
		}

		private void panel11Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu11.Show(ToolTipsText.Thu11, panel11Thu);
		}

		private void panel11Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri11.Show(ToolTipsText.Fri11, panel11Fri);
		}

		private void panel11Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat11.Show(ToolTipsText.Sat11, panel11Sat);
		}

		private void panel11Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun11.Show(ToolTipsText.Sun11, panel11Sun);
		}

		private void panel12Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon12.Show(ToolTipsText.Mon12, panel12Mon);
		}

		private void panel12Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue12.Show(ToolTipsText.Tue12, panel12Tue);
		}

		private void panel12Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed12.Show(ToolTipsText.Wed12, panel12Wed);
		}

		private void panel12Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu12.Show(ToolTipsText.Thu12, panel12Thu);
		}

		private void panel12Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri12.Show(ToolTipsText.Fri12, panel12Fri);
		}

		private void panel12Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat12.Show(ToolTipsText.Sat12, panel12Sat);
		}

		private void panel12Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun12.Show(ToolTipsText.Sun12, panel12Sun);
		}

		private void panel13Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon13.Show(ToolTipsText.Mon13, panel13Mon);
		}

		private void panel13Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue13.Show(ToolTipsText.Tue13, panel13Tue);
		}

		private void panel13Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed13.Show(ToolTipsText.Wed13, panel13Wed);
		}

		private void panel13Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu13.Show(ToolTipsText.Thu13, panel13Thu);
		}

		private void panel13Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri13.Show(ToolTipsText.Fri13, panel13Fri);
		}

		private void panel13Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat13.Show(ToolTipsText.Sat13, panel13Sat);
		}

		private void panel13Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun13.Show(ToolTipsText.Sun13, panel13Sun);
		}

		private void panel14Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon14.Show(ToolTipsText.Mon14, panel14Mon);
		}

		private void panel14Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue14.Show(ToolTipsText.Tue14, panel14Tue);
		}

		private void panel14Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed14.Show(ToolTipsText.Wed14, panel14Wed);
		}

		private void panel14Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu14.Show(ToolTipsText.Thu14, panel14Thu);
		}

		private void panel14Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri14.Show(ToolTipsText.Fri14, panel14Fri);
		}

		private void panel14Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat14.Show(ToolTipsText.Sat14, panel14Sat);
		}

		private void panel14Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun14.Show(ToolTipsText.Sun14, panel14Sun);
		}

		private void panel15Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon15.Show(ToolTipsText.Mon15, panel15Mon);
		}

		private void panel15Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue15.Show(ToolTipsText.Tue15, panel15Tue);
		}

		private void panel15Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed15.Show(ToolTipsText.Wed15, panel15Wed);
		}

		private void panel15Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu15.Show(ToolTipsText.Thu15, panel15Thu);
		}

		private void panel15Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri15.Show(ToolTipsText.Fri15, panel15Fri);
		}

		private void panel15Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat15.Show(ToolTipsText.Sat15, panel15Sat);
		}

		private void panel15Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun15.Show(ToolTipsText.Sun15, panel15Sun);
		}

		private void panel16Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon16.Show(ToolTipsText.Mon16, panel16Mon);
		}

		private void panel16Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue16.Show(ToolTipsText.Tue16, panel16Tue);
		}

		private void panel16Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed16.Show(ToolTipsText.Wed16, panel16Wed);
		}

		private void panel16Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu16.Show(ToolTipsText.Thu16, panel16Thu);
		}

		private void panel16Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri16.Show(ToolTipsText.Fri16, panel16Fri);
		}

		private void panel16Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat16.Show(ToolTipsText.Sat16, panel16Sat);
		}

		private void panel16Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun16.Show(ToolTipsText.Sun16, panel16Sun);
		}

		private void panel17Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon17.Show(ToolTipsText.Mon17, panel17Mon);
		}

		private void panel17Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue17.Show(ToolTipsText.Tue17, panel17Tue);
		}

		private void panel17Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed17.Show(ToolTipsText.Wed17, panel17Wed);
		}

		private void panel17Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu17.Show(ToolTipsText.Thu17, panel17Thu);
		}

		private void panel17Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri17.Show(ToolTipsText.Fri17, panel17Fri);
		}

		private void panel17Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat17.Show(ToolTipsText.Sat17, panel17Sat);
		}

		private void panel17Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun17.Show(ToolTipsText.Sun17, panel17Sun);
		}

		private void panel18Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon18.Show(ToolTipsText.Mon18, panel18Mon);
		}

		private void panel18Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue18.Show(ToolTipsText.Tue18, panel18Tue);
		}

		private void panel18Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed18.Show(ToolTipsText.Wed18, panel18Wed);
		}

		private void panel18Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu18.Show(ToolTipsText.Thu18, panel18Thu);
		}

		private void panel18Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri18.Show(ToolTipsText.Fri18, panel18Fri);
		}

		private void panel18Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat18.Show(ToolTipsText.Sat18, panel18Sat);
		}

		private void panel18Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun18.Show(ToolTipsText.Sun18, panel18Sun);
		}

		private void panel19Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon19.Show(ToolTipsText.Mon19, panel19Mon);
		}

		private void panel19Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue19.Show(ToolTipsText.Tue19, panel19Tue);
		}

		private void panel19Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed19.Show(ToolTipsText.Wed19, panel19Wed);
		}

		private void panel19Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu19.Show(ToolTipsText.Thu19, panel19Thu);
		}

		private void panel19Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri19.Show(ToolTipsText.Fri19, panel19Fri);
		}

		private void panel19Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat19.Show(ToolTipsText.Sat19, panel19Sat);
		}

		private void panel19Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun19.Show(ToolTipsText.Sun19, panel19Sun);
		}

		private void panel20Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon20.Show(ToolTipsText.Mon20, panel20Mon);
		}

		private void panel20Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue20.Show(ToolTipsText.Tue20, panel20Tue);
		}

		private void panel20Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed20.Show(ToolTipsText.Wed20, panel20Wed);
		}

		private void panel20Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu20.Show(ToolTipsText.Thu20, panel20Thu);
		}

		private void panel20Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri20.Show(ToolTipsText.Fri20, panel20Fri);
		}

		private void panel20Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat20.Show(ToolTipsText.Sat20, panel20Sat);
		}

		private void panel20Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun20.Show(ToolTipsText.Sun20, panel20Sun);
		}

		private void panel21Mon_MouseHover(object sender, EventArgs e)
		{
			toolTipMon21.Show(ToolTipsText.Mon21, panel21Mon);
		}

		private void panel21Tue_MouseHover(object sender, EventArgs e)
		{
			toolTipTue21.Show(ToolTipsText.Tue21, panel21Tue);
		}

		private void panel21Wed_MouseHover(object sender, EventArgs e)
		{
			toolTipWed21.Show(ToolTipsText.Wed21, panel21Wed);
		}

		private void panel21Thu_MouseHover(object sender, EventArgs e)
		{
			toolTipThu21.Show(ToolTipsText.Thu21, panel21Thu);
		}

		private void panel21Fri_MouseHover(object sender, EventArgs e)
		{
			toolTipFri21.Show(ToolTipsText.Fri21, panel21Fri);
		}

		private void panel21Sat_MouseHover(object sender, EventArgs e)
		{
			toolTipSat21.Show(ToolTipsText.Sat21, panel21Sat);
		}

		private void panel21Sun_MouseHover(object sender, EventArgs e)
		{
			toolTipSun21.Show(ToolTipsText.Sun21, panel21Sun);
		}
		#endregion

		//funkcija za apdejtovanje panela u planeru
		public void updatePlaner(Calendar cal)
		{
			//ocisti stare eventove iz planera
			#region resetBoje
			//ponedeljak
			panel8Mon.BackColor = Color.White;
			ToolTipsText.Mon8 = "";
            panel9Mon.BackColor = Color.White;
			ToolTipsText.Mon9 = "";
			panel10Mon.BackColor = Color.White;
			ToolTipsText.Mon10 = "";
			panel11Mon.BackColor = Color.White;
			ToolTipsText.Mon11 = "";
			panel12Mon.BackColor = Color.White;
			ToolTipsText.Mon12 = "";
			panel13Mon.BackColor = Color.White;
			ToolTipsText.Mon13 = "";
			panel14Mon.BackColor = Color.White;
			ToolTipsText.Mon14 = "";
			panel15Mon.BackColor = Color.White;
			ToolTipsText.Mon15 = "";
			panel16Mon.BackColor = Color.White;
			ToolTipsText.Mon16 = "";
			panel17Mon.BackColor = Color.White;
			ToolTipsText.Mon17 = "";
			panel18Mon.BackColor = Color.White;
			ToolTipsText.Mon18 = "";
			panel19Mon.BackColor = Color.White;
			ToolTipsText.Mon19 = "";
			panel20Mon.BackColor = Color.White;
			ToolTipsText.Mon20 = "";
			panel21Mon.BackColor = Color.White;
			ToolTipsText.Mon21 = "";
			//utorak
			panel8Tue.BackColor = Color.White;
			ToolTipsText.Tue8 = "";
			panel9Tue.BackColor = Color.White;
			ToolTipsText.Tue9 = "";
			panel10Tue.BackColor = Color.White;
			ToolTipsText.Tue10 = "";
			panel11Tue.BackColor = Color.White;
			ToolTipsText.Tue11 = "";
			panel12Tue.BackColor = Color.White;
			ToolTipsText.Tue12 = "";
			panel13Tue.BackColor = Color.White;
			ToolTipsText.Tue13 = "";
			panel14Tue.BackColor = Color.White;
			ToolTipsText.Tue14 = "";
			panel15Tue.BackColor = Color.White;
			ToolTipsText.Tue15 = "";
			panel16Tue.BackColor = Color.White;
			ToolTipsText.Tue16 = "";
			panel17Tue.BackColor = Color.White;
			ToolTipsText.Tue17 = "";
			panel18Tue.BackColor = Color.White;
			ToolTipsText.Tue18 = "";
			panel19Tue.BackColor = Color.White;
			ToolTipsText.Tue19 = "";
			panel20Tue.BackColor = Color.White;
			ToolTipsText.Tue20 = "";
			panel21Tue.BackColor = Color.White;
			ToolTipsText.Tue21 = "";
			//sreda
			panel8Wed.BackColor = Color.White;
			ToolTipsText.Wed8 = "";
			panel9Wed.BackColor = Color.White;
			ToolTipsText.Wed9 = "";
			panel10Wed.BackColor = Color.White;
			ToolTipsText.Wed10 = "";
			panel11Wed.BackColor = Color.White;
			ToolTipsText.Wed11 = "";
			panel12Wed.BackColor = Color.White;
			ToolTipsText.Wed12 = "";
			panel13Wed.BackColor = Color.White;
			ToolTipsText.Wed13 = "";
			panel14Wed.BackColor = Color.White;
			ToolTipsText.Wed14 = "";
			panel15Wed.BackColor = Color.White;
			ToolTipsText.Wed15 = "";
			panel16Wed.BackColor = Color.White;
			ToolTipsText.Wed16 = "";
			panel17Wed.BackColor = Color.White;
			ToolTipsText.Wed17 = "";
			panel18Wed.BackColor = Color.White;
			ToolTipsText.Wed18 = "";
			panel19Wed.BackColor = Color.White;
			ToolTipsText.Wed19 = "";
			panel20Wed.BackColor = Color.White;
			ToolTipsText.Wed20 = "";
			panel21Wed.BackColor = Color.White;
			ToolTipsText.Wed21 = "";
			//cetvrtak
			panel8Thu.BackColor = Color.White;
			ToolTipsText.Thu8 = "";
			panel9Thu.BackColor = Color.White;
			ToolTipsText.Thu9 = "";
			panel10Thu.BackColor = Color.White;
			ToolTipsText.Thu10 = "";
			panel11Thu.BackColor = Color.White;
			ToolTipsText.Thu11 = "";
			panel12Thu.BackColor = Color.White;
			ToolTipsText.Thu12 = "";
			panel13Thu.BackColor = Color.White;
			ToolTipsText.Thu13 = "";
			panel14Thu.BackColor = Color.White;
			ToolTipsText.Thu14 = "";
			panel15Thu.BackColor = Color.White;
			ToolTipsText.Thu15 = "";
			panel16Thu.BackColor = Color.White;
			ToolTipsText.Thu16 = "";
			panel17Thu.BackColor = Color.White;
			ToolTipsText.Thu17 = "";
			panel18Thu.BackColor = Color.White;
			ToolTipsText.Thu18 = "";
			panel19Thu.BackColor = Color.White;
			ToolTipsText.Thu19 = "";
			panel20Thu.BackColor = Color.White;
			ToolTipsText.Thu20 = "";
			panel21Thu.BackColor = Color.White;
			ToolTipsText.Thu21 = "";
			//petak
			panel8Fri.BackColor = Color.White;
			ToolTipsText.Fri8 = "";
			panel9Fri.BackColor = Color.White;
			ToolTipsText.Fri9 = "";
			panel10Fri.BackColor = Color.White;
			ToolTipsText.Fri10 = "";
			panel11Fri.BackColor = Color.White;
			ToolTipsText.Fri11 = "";
			panel12Fri.BackColor = Color.White;
			ToolTipsText.Fri12 = "";
			panel13Fri.BackColor = Color.White;
			ToolTipsText.Fri13 = "";
			panel14Fri.BackColor = Color.White;
			ToolTipsText.Fri14 = "";
			panel15Fri.BackColor = Color.White;
			ToolTipsText.Fri15 = "";
			panel16Fri.BackColor = Color.White;
			ToolTipsText.Fri16 = "";
			panel17Fri.BackColor = Color.White;
			ToolTipsText.Fri17 = "";
			panel18Fri.BackColor = Color.White;
			ToolTipsText.Fri18 = "";
			panel19Fri.BackColor = Color.White;
			ToolTipsText.Fri19 = "";
			panel20Fri.BackColor = Color.White;
			ToolTipsText.Fri20 = "";
			panel21Fri.BackColor = Color.White;
			ToolTipsText.Fri21 = "";
			//subota
			panel8Sat.BackColor = Color.White;
			ToolTipsText.Sat8 = "";
			panel9Sat.BackColor = Color.White;
			ToolTipsText.Sat9 = "";
			panel10Sat.BackColor = Color.White;
			ToolTipsText.Sat10 = "";
			panel11Sat.BackColor = Color.White;
			ToolTipsText.Sat11 = "";
			panel12Sat.BackColor = Color.White;
			ToolTipsText.Sat12 = "";
			panel13Sat.BackColor = Color.White;
			ToolTipsText.Sat13 = "";
			panel14Sat.BackColor = Color.White;
			ToolTipsText.Sat14 = "";
			panel15Sat.BackColor = Color.White;
			ToolTipsText.Sat15 = "";
			panel16Sat.BackColor = Color.White;
			ToolTipsText.Sat16 = "";
			panel17Sat.BackColor = Color.White;
			ToolTipsText.Sat17 = "";
			panel18Sat.BackColor = Color.White;
			ToolTipsText.Sat18 = "";
			panel19Sat.BackColor = Color.White;
			ToolTipsText.Sat19 = "";
			panel20Sat.BackColor = Color.White;
			ToolTipsText.Sat20 = "";
			panel21Sat.BackColor = Color.White;
			ToolTipsText.Sat21 = "";
			//nedelja
			panel8Sun.BackColor = Color.White;
			ToolTipsText.Sun8 = "";
			panel9Sun.BackColor = Color.White;
			ToolTipsText.Sun9 = "";
			panel10Sun.BackColor = Color.White;
			ToolTipsText.Sun10 = "";
			panel11Sun.BackColor = Color.White;
			ToolTipsText.Sun11 = "";
			panel12Sun.BackColor = Color.White;
			ToolTipsText.Sun12 = "";
			panel13Sun.BackColor = Color.White;
			ToolTipsText.Sun13 = "";
			panel14Sun.BackColor = Color.White;
			ToolTipsText.Sun14 = "";
			panel15Sun.BackColor = Color.White;
			ToolTipsText.Sun15 = "";
			panel16Sun.BackColor = Color.White;
			ToolTipsText.Sun16 = "";
			panel17Sun.BackColor = Color.White;
			ToolTipsText.Sun17 = "";
			panel18Sun.BackColor = Color.White;
			ToolTipsText.Sun18 = "";
			panel19Sun.BackColor = Color.White;
			ToolTipsText.Sun19 = "";
			panel20Sun.BackColor = Color.White;
			ToolTipsText.Sun20 = "";
			panel21Sun.BackColor = Color.White;
			ToolTipsText.Sun21 = "";
			#endregion

			//proveri i dodaj nove eventove u planer na osnovu datuma
			DBConnect db = new DBConnect();
			String querry = "SELECT * FROM events WHERE week = '" + DataContainer.week + "' AND doctor = '" + ActiveDoctor.name +"'";
			MySqlDataAdapter msda = new MySqlDataAdapter(querry, db.GetConnection());

			DataTable dtable = new DataTable();
			msda.Fill(dtable);

			Color serviceClr = Color.White;

			#region Ne-reacurring eventovi

			foreach (DataRow row in dtable.Rows)
			{
				switch (row["service"].ToString())
				{
					case "Examination":
						serviceClr = Color.AliceBlue;
						break;
					case "Laboratory":
						serviceClr = Color.GreenYellow;
						break;
					case "Therapy":
						serviceClr = Color.LightPink;
						break;
					case "Operation":
						serviceClr = Color.OrangeRed;
						break;
					case "Check-up":
						serviceClr = Color.PowderBlue;
						break;
				}

                //MessageBox.Show("DEBUG: Moja boja je: " + serviceClr.ToString() + ", imam vreme :" + row["time"].ToString() + " i datum: " + row["date"].ToString());
               
                String stringDate = row["date"].ToString();
                CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
                //cid je CultureInfo koji je vazio kada je event bio kreiran
                CultureInfo cid = new CultureInfo(row["cultureInfo"].ToString());

                //DateTime datumEventa = DateTime.Parse(stringDate.Substring(1, stringDate.Length - 2), cid, DateTimeStyles.NoCurrentDateDefault);
                DateTime datumEventa = DateTime.ParseExact(stringDate.Substring(1, stringDate.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);

                String datumEventaUCid = datumEventa.ToString(" d. MMMM yyyy. ", ci);
                datumEventaUCid = "[" + datumEventaUCid + "]";

                #region Tooltips tekst

                //ponedeljak                                           //ovaj deo treba da izmenjamo
                if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel8Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}

				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel9Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel10Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel11Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel12Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel13Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel14Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel15Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel16Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel17Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel18Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel19Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel20Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelMondayDate.Text)
				{
					panel21Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//utorak
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel8Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel9Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel10Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel11Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel12Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel13Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel14Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel15Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel16Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel17Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel18Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel19Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel20Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelTuesdayDate.Text)
				{
					panel21Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//sreda
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel8Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel9Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel10Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel11Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel12Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel13Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel14Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel15Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel16Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel17Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel18Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel19Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel20Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelWednesdayDate.Text)
				{
					panel21Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//cetvrtak
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel8Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel9Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel10Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel11Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel12Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel13Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel14Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel15Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel16Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel17Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel18Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel19Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel20Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelThursdayDate.Text)
				{
					panel21Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//petak
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel8Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel9Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel10Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel11Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel12Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel13Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel14Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel15Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel16Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel17Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel18Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel19Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel20Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelFridayDate.Text)
				{
					panel21Fri.BackColor = serviceClr; switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//subota
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel8Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel9Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel10Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel11Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel12Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel13Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel14Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel15Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel16Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel17Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel18Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel19Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel20Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelSaturdayDate.Text)
				{
					panel21Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//nedelja
				if (row["time"].ToString() == labelTime8.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel8Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel9Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel10Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel11Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel12Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel13Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel14Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel15Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel16Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel17Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel18Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel19Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel20Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && datumEventaUCid == labelSundayDate.Text)
				{
					panel21Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
                #endregion //za Tooltips tekstove
            }
            #endregion //za ne-reacurring eventove 

            #region Duplikati reacurring eventova

            querry = "SELECT * FROM events WHERE reacurring != '0' AND doctor = '" + ActiveDoctor.name + "'";
			msda = new MySqlDataAdapter(querry, db.GetConnection());
			dtable = new DataTable();
			msda.Fill(dtable);

			foreach (DataRow row in dtable.Rows)
			{
                switch (row["service"].ToString())
                {
                    case "Therapy":
                        serviceClr = Color.LightPink;
                        break;
                }
                //jedino je Therapy reacurring

				//uzimamo "date" vrednost eventa i dobijamo koji je dan u nedelji
				String eventDate = row["date"].ToString();
				CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
                CultureInfo cid = new CultureInfo(row["cultureInfo"].ToString());
				DateTime datumEventa = DateTime.ParseExact(eventDate.Substring(1, eventDate.Length - 2), " d. MMMM yyyy. ", cid, DateTimeStyles.NoCurrentDateDefault);
				DayOfWeek danEventa = ci.Calendar.GetDayOfWeek(datumEventa);

				//uslov za reacrruing je:
				//-da se vreme poklapa (da bi znali koji panel)
				//-da je odredjeni dan u nedelji (da bi znali koji panel)
				//-da event.week + event.reacurring >= week
				//-da event.week < week

				//ponedeljak              
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}

				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Monday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Mon.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Mon21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Mon21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Mon21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//utorak
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Tuesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Tue.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Tue21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Tue21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Tue21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//sreda
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Wednesday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Wed.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Wed21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Wed21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Wed21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//cetvrtak
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Thursday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Thu.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Thu21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Thu21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Thu21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//petak
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Friday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Fri.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Fri21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Fri21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Fri21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//subota
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat19 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Saturday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Sat.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sat21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sat21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sat21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				//nedelja
				if (row["time"].ToString() == labelTime8.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel8Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun8 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun8 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun8 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime9.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel9Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun9 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun9 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun9 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime10.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel10Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun10 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun10 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun10 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime11.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel11Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun11 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun11 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun11 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime12.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel12Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun12 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun12 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun12 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime13.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel13Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun13 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun13 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun13 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime14.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel14Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun14 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun14 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun14 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime15.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel15Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun15 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun15 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun15 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime16.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel16Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun16 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun16 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun16 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime17.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel17Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun17 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun17 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun17 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime18.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel18Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun18 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime19.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel19Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun19 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun19 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun18 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime20.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel20Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun20 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun20 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun20 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
				if (row["time"].ToString() == labelTime21.Text && danEventa == DayOfWeek.Sunday
					&& (Int16.Parse((row["week"].ToString())) + Int16.Parse((row["reacurring"].ToString())) >= DataContainer.week) && (Int16.Parse((row["week"].ToString())) < DataContainer.week))
				{
					panel21Sun.BackColor = serviceClr;
					switch (Thread.CurrentThread.CurrentUICulture.Name)
					{
						case "sr - Latn - CS":
							ToolTipsText.Sun21 = "Pacijent: " + row["patient"].ToString() + "\tOpis: " + row["description"].ToString();
							break;
						case "de-DE":
							ToolTipsText.Sun21 = "Patient: " + row["patient"].ToString() + "\tBeschreibung: " + row["description"].ToString();
							break;
						default:
							ToolTipsText.Sun21 = "Patient: " + row["patient"].ToString() + "\tDescription: " + row["description"].ToString();
							break;
					}
				}
			}
			#endregion //dupikati reacurring eventova
		}

		//funkcija koja racuna koliko ima nedelja u godini
		public int getWeeksInYear(int year, CultureInfo ci)
		{
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			DateTime date1 = new DateTime(year, 12, 31);
			return ci.Calendar.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
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

        //skakanje na druge stranice
        private void buttonPageListPatients_Click(object sender, EventArgs e)
        {
            FormListaPacijenata formListPat = new FormListaPacijenata(this);
            formListPat.Show();
            this.Hide();
        }

        private void buttonPageListDoctors_Click(object sender, EventArgs e)
        {
            FormListaDoktora formListDoc = new FormListaDoktora(this);
            formListDoc.Show();
            this.Hide();
        }

        private void buttonPageClinicStatistic_Click(object sender, EventArgs e)
        {
            FormStatistika formStat = new FormStatistika(this);
            formStat.Show();
            this.Hide();
        }
    }
    //pomocni enumerator za dane
    public enum Day
	{
		Monday = 1,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	//pomocna klasa koja pamti dan i vreme za aktivni panel
	public static class DataContainer
	{
		public static Day day;
		public static int time;
		public static String service;
		public static int week;
		public static int year;
	}

	public static class ToolTipsText
	{
		public static String Mon8;
		public static String Tue8;
		public static String Wed8;
		public static String Thu8;
		public static String Fri8;
		public static String Sat8;
		public static String Sun8;
		public static String Mon9;
		public static String Tue9;
		public static String Wed9;
		public static String Thu9;
		public static String Fri9;
		public static String Sat9;
		public static String Sun9;
		public static String Mon10;
		public static String Tue10;
		public static String Wed10;
		public static String Thu10;
		public static String Fri10;
		public static String Sat10;
		public static String Sun10;
		public static String Mon11;
		public static String Tue11;
		public static String Wed11;
		public static String Thu11;
		public static String Fri11;
		public static String Sat11;
		public static String Sun11;
		public static String Mon12;
		public static String Tue12;
		public static String Wed12;
		public static String Thu12;
		public static String Fri12;
		public static String Sat12;
		public static String Sun12;
		public static String Mon13;
		public static String Tue13;
		public static String Wed13;
		public static String Thu13;
		public static String Fri13;
		public static String Sat13;
		public static String Sun13;
		public static String Mon14;
		public static String Tue14;
		public static String Wed14;
		public static String Thu14;
		public static String Fri14;
		public static String Sat14;
		public static String Sun14;
		public static String Mon15;
		public static String Tue15;
		public static String Wed15;
		public static String Thu15;
		public static String Fri15;
		public static String Sat15;
		public static String Sun15;
		public static String Mon16;
		public static String Tue16;
		public static String Wed16;
		public static String Thu16;
		public static String Fri16;
		public static String Sat16;
		public static String Sun16;
		public static String Mon17;
		public static String Tue17;
		public static String Wed17;
		public static String Thu17;
		public static String Fri17;
		public static String Sat17;
		public static String Sun17;
		public static String Mon18;
		public static String Tue18;
		public static String Wed18;
		public static String Thu18;
		public static String Fri18;
		public static String Sat18;
		public static String Sun18;
		public static String Mon19;
		public static String Tue19;
		public static String Wed19;
		public static String Thu19;
		public static String Fri19;
		public static String Sat19;
		public static String Sun19;
		public static String Mon20;
		public static String Tue20;
		public static String Wed20;
		public static String Thu20;
		public static String Fri20;
		public static String Sat20;
		public static String Sun20;
		public static String Mon21;
		public static String Tue21;
		public static String Wed21;
		public static String Thu21;
		public static String Fri21;
		public static String Sat21;
		public static String Sun21;
	}
}
