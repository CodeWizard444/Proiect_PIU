using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proiect_PIU;

namespace InterfataUtilizator_WindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crearea și afișarea formularului pentru adăugarea de studenți
            FormularMasini form1 = new FormularMasini();
            form1.Show();

            // Afișarea formularului pentru afișarea și gestionarea studenților
            Application.Run(new Form1());
        }
    }

    public class FormularMasini : Form
    {
        private Label lblNumeClient;
        private TextBox txtNumeClient;

        private Label lblNumeMasina;
        private TextBox txtNumeMasina;

        private Label lblCuloareMasina;
        private TextBox txtCuloareMasina;

        private Label lblDisponibilitate;
        private CheckBox chkDisponibilitate;

        private Label lblDataInchiriere;
        private TextBox txtDataInchiriere;

        private Button btnAdaugaInchiriere;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;

        AdministrareInchirieriMasini_FisierText adminInchirieri;

        public FormularMasini()
        {
            // Configurarea aspectului formularului
            this.Size = new System.Drawing.Size(500, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Formular Adăugare Închiriere";

            // Adăugarea controlului de tip Label pentru 'Nume Client'
            lblNumeClient = new Label();
            lblNumeClient.Width = LATIME_CONTROL;
            lblNumeClient.Text = "Nume Client:";
            lblNumeClient.BackColor = Color.LightYellow;
            this.Controls.Add(lblNumeClient);

            // Adăugarea controlului de tip TextBox pentru 'Nume Client'
            txtNumeClient = new TextBox();
            txtNumeClient.Width = LATIME_CONTROL;
            txtNumeClient.Left = DIMENSIUNE_PAS_X;
            this.Controls.Add(txtNumeClient);

            // Adăugarea controlului de tip Label pentru 'Nume Masina'
            lblNumeMasina = new Label();
            lblNumeMasina.Width = LATIME_CONTROL;
            lblNumeMasina.Text = "Nume Mașină:";
            lblNumeMasina.Top = DIMENSIUNE_PAS_Y;
            lblNumeMasina.BackColor = Color.LightYellow;
            this.Controls.Add(lblNumeMasina);

            // Adăugarea controlului de tip TextBox pentru 'Nume Masina'
            txtNumeMasina = new TextBox();
            txtNumeMasina.Width = LATIME_CONTROL;
            txtNumeMasina.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtNumeMasina);

            // Adăugarea controlului de tip Label pentru 'Culoare Masina'
            lblCuloareMasina = new Label();
            lblCuloareMasina.Width = LATIME_CONTROL;
            lblCuloareMasina.Text = "Culoare Mașină:";
            lblCuloareMasina.Top = 2 * DIMENSIUNE_PAS_Y;
            lblCuloareMasina.BackColor = Color.LightYellow;
            this.Controls.Add(lblCuloareMasina);

            // Adăugarea controlului de tip TextBox pentru 'Culoare Masina'
            txtCuloareMasina = new TextBox();
            txtCuloareMasina.Width = LATIME_CONTROL;
            txtCuloareMasina.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 2 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtCuloareMasina);

            // Adăugarea controlului de tip Label pentru 'Disponibilitate'
            lblDisponibilitate = new Label();
            lblDisponibilitate.Width = LATIME_CONTROL;
            lblDisponibilitate.Text = "Disponibilitate:";
            lblDisponibilitate.Top = 3 * DIMENSIUNE_PAS_Y;
            lblDisponibilitate.BackColor = Color.LightYellow;
            this.Controls.Add(lblDisponibilitate);

            // Adăugarea controlului de tip CheckBox pentru 'Disponibilitate'
            chkDisponibilitate = new CheckBox();
            chkDisponibilitate.Width = LATIME_CONTROL;
            chkDisponibilitate.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(chkDisponibilitate);

            // Adăugarea controlului de tip Label pentru 'Data Inchiriere'
            lblDataInchiriere = new Label();
            lblDataInchiriere.Width = LATIME_CONTROL;
            lblDataInchiriere.Text = "Data Închiriere:";
            lblDataInchiriere.Top = 4 * DIMENSIUNE_PAS_Y;
            lblDataInchiriere.BackColor = Color.LightYellow;
            this.Controls.Add(lblDataInchiriere);

            // Adăugarea controlului de tip TextBox pentru 'Data Inchiriere'
            txtDataInchiriere = new TextBox();
            txtDataInchiriere.Width = LATIME_CONTROL;
            txtDataInchiriere.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtDataInchiriere);

            // Adăugarea controlului de tip Button pentru adăugarea închirierii
            btnAdaugaInchiriere = new Button();
            btnAdaugaInchiriere.Width = LATIME_CONTROL;
            btnAdaugaInchiriere.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 5 * DIMENSIUNE_PAS_Y);
            btnAdaugaInchiriere.Text = "Adaugă Închiriere";
            btnAdaugaInchiriere.Click += OnButtonClicked;
            this.Controls.Add(btnAdaugaInchiriere);
        
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Obține numele fișierului și calea completă către fișier din configurație
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);

            // Inițializează un obiect pentru administrarea închirierilor de mașini cu fișierul specificat
            AdministrareInchirieriMasini_FisierText adminInchirieri = new AdministrareInchirieriMasini_FisierText(caleCompletaFisier);

            // Obține datele introduse de utilizator
            string numeClient = txtNumeClient.Text;
            string numeMasina = txtNumeMasina.Text;
            string culoareMasina = txtCuloareMasina.Text;
            bool disponibilitateMasina = chkDisponibilitate.Checked;
            string dataInchiriere = txtDataInchiriere.Text;

            // Creează un obiect de tipul InchirieriMasini cu datele introduse de utilizator
            InchirieriMasini inchiriere = new InchirieriMasini(numeClient, new Masini(numeMasina, disponibilitateMasina), dataInchiriere);

            // Adaugă închirierea în sistem
            adminInchirieri.AdaugaInchiriere(inchiriere);

            // Afișează un mesaj de confirmare că închirierea a fost adăugată cu succes
            MessageBox.Show("Închirierea a fost adăugată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
