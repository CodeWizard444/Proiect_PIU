using System;

namespace Proiect_PIU
{
    public class InchirieriMasini
    {
        // Proprietăți auto-implemented
        public string NumeClient { get; set; }
        public Masini MasinaInchiriata { get; set; }
        public string DataInchiriere { get; set; } 

        // Constructori
        public InchirieriMasini()
        {
            NumeClient = string.Empty;
            MasinaInchiriata = null;
            DataInchiriere = string.Empty; 
        }

        public InchirieriMasini(string numeClient, Masini masina, string dataInchiriere) 
        {
            NumeClient = numeClient;
            MasinaInchiriata = masina;
            DataInchiriere = dataInchiriere;
        }

        // Metodă Info() pentru afișarea informațiilor despre închiriere
        public string Info()
        {
            string infoMasina = MasinaInchiriata != null ? MasinaInchiriata.Info() : "Nedeterminata";
            string disponibilitate = MasinaInchiriata != null && MasinaInchiriata.Disponibila ? "disponibila" : "indisponibila";
            return $"Client: {NumeClient}, {infoMasina}, Stare masina: {disponibilitate}, Data inchiriere: {DataInchiriere}";
        }
    }
}
