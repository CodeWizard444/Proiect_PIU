using System;
using System.IO;

namespace Proiect_PIU
{
    public class AdministrareInchirieriMasini_FisierText
    {
        private string numeFisier;

        public AdministrareInchirieriMasini_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // Dacă fișierul nu există, acesta va fi creat automat
            if (!File.Exists(numeFisier))
            {
                File.Create(numeFisier).Close(); // Crează fișierul și-l închide imediat
            }
        }

        public void AdaugaInchiriere(InchirieriMasini inchiriere)
        {
            // Folosind StreamWriter cu parametrul true, se deschide fișierul pentru scriere fără a-l șterge
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(inchiriere.Info()); // Se scrie informația despre închiriere în fișier
            }
        }

        public InchirieriMasini[] GetInchirieri(out int nrInchirieri)
        {
            InchirieriMasini[] inchirieri = new InchirieriMasini[0];

            // Instrucțiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrInchirieri = 0;

                // Se citește câte o linie și se crează un obiect de tip InchirieriMasini
                // pe baza datelor din linia citită
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Se desparte linia în componentele corespunzătoare și se creează un obiect InchirieriMasini
                    string[] infoInchiriere = linieFisier.Split(',');
                    if (infoInchiriere.Length == 4)
                    {
                        string numeClient = infoInchiriere[0].Trim();
                        string denumireMasina = infoInchiriere[1].Trim();
                        bool disponibilitate = infoInchiriere[2].Trim().Equals("disponibila", StringComparison.OrdinalIgnoreCase);
                        string dataInchiriere = infoInchiriere[3].Trim();

                        // Se adaugă închirierea în tabloul de închirieri
                        Array.Resize(ref inchirieri, inchirieri.Length + 1);
                        inchirieri[nrInchirieri++] = new InchirieriMasini(numeClient, new Masini(denumireMasina, disponibilitate), dataInchiriere);
                    }
                }
            }

            return inchirieri;
        }
    }
}
