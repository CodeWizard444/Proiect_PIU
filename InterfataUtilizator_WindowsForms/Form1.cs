using System;
using Proiect_PIU;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareInchirieriMasini_FisierText adminInchirieri;

        private Label lblNumeClient;
        private Label lblMasina;
        private Label lblCuloare;
        private Label lblDisponibilitate;
        private Label lblDataInchiriere;

        private Label[] lblsNumeClient;
        private Label[] lblsMasina;
        private Label[] lblsCuloare;
        private Label[] lblsDisponibilitate;
        private Label[] lblsDataInchiriere;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        public Form1()
        {
            InitializeComponent();
            string numeFisier = "inchirieri_masini.txt"; // Numele fișierului pentru stocarea închirierilor de mașini
            adminInchirieri = new AdministrareInchirieriMasini_FisierText(numeFisier);

            this.Size = new Size(800, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Evidenta Inchirieri Masini";
            this.Font = new Font("Arial", 9, FontStyle.Regular);

            lblNumeClient = CreateLabel("Nume Client", DIMENSIUNE_PAS_X);
            lblMasina = CreateLabel("Masina", 2 * DIMENSIUNE_PAS_X);
            lblCuloare = CreateLabel("Culoare", 3 * DIMENSIUNE_PAS_X);
            lblDisponibilitate = CreateLabel("Disponibilitate", 4 * DIMENSIUNE_PAS_X);
            lblDataInchiriere = CreateLabel("Data Inchiriere", 5 * DIMENSIUNE_PAS_X);

            this.Controls.Add(lblNumeClient);
            this.Controls.Add(lblMasina);
            this.Controls.Add(lblCuloare);
            this.Controls.Add(lblDisponibilitate);
            this.Controls.Add(lblDataInchiriere);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaInchirieri();
        }

        private void AfiseazaInchirieri()
        {
            // Obține închirierile din fișier
            int nrInchirieri;
            InchirieriMasini[] inchirieri = adminInchirieri.GetInchirieri(out nrInchirieri);

            // Alocă și inițializează controalele de afișare
            lblsNumeClient = new Label[nrInchirieri];
            lblsMasina = new Label[nrInchirieri];
            lblsCuloare = new Label[nrInchirieri];
            lblsDisponibilitate = new Label[nrInchirieri];
            lblsDataInchiriere = new Label[nrInchirieri];

            int i = 0;
            foreach (InchirieriMasini inchiriere in inchirieri)
            {
                lblsNumeClient[i] = CreateLabel(inchiriere.NumeClient, DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsMasina[i] = CreateLabel(inchiriere.MasinaInchiriata.Denumire, 2 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsCuloare[i] = CreateLabel(inchiriere.MasinaInchiriata.Culoare.ToString(), 3 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsDisponibilitate[i] = CreateLabel(inchiriere.MasinaInchiriata.Disponibila ? "Disponibila" : "Indisponibila", 4 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsDataInchiriere[i] = CreateLabel(inchiriere.DataInchiriere, 5 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);

                this.Controls.Add(lblsNumeClient[i]);
                this.Controls.Add(lblsMasina[i]);
                this.Controls.Add(lblsCuloare[i]);
                this.Controls.Add(lblsDisponibilitate[i]);
                this.Controls.Add(lblsDataInchiriere[i]);

                i++;
            }
        }

        private Label CreateLabel(string text, int left, int top = 0)
        {
            Label lbl = new Label();
            lbl.Width = LATIME_CONTROL;
            lbl.Text = text;
            lbl.Left = left;
            lbl.Top = top;
            lbl.ForeColor = Color.Black;
            return lbl;
        }
    }

}

