namespace Proiect_PIU
{
    public class Masini
    {
        // Proprietăți auto-implemented
        public string Denumire { get; set; }
        public bool Disponibila { get; set; }

        // Constructori
        public Masini()
        {
            Denumire = string.Empty;
            Disponibila = true;
        }

        public Masini(string _denumire, bool _disponibila)
        {
            Denumire = _denumire;
            Disponibila = _disponibila;
        }

        // Metodă Info() rămâne neschimbată
        public string Info()
        {
            string stare = Disponibila ? "disponibila" : "indisponibila";
            return $"{Denumire}, {stare}";
        }
    }
}
