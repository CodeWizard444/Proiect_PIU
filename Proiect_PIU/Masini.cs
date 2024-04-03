using System;

namespace Proiect_PIU
{
    public enum Culori
    {
        Rosu,
        Alb,
        Negru,
        Verde,
        Galben,
    }

    [Flags]
    public enum Optiuni
    {
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4,
        HeadUpDisplay=8,
        PanoramicRooftop=16,
        ScauneIncalzite=32,
    }
    public class Masini
    {
        // Proprietăți auto-implemented
        public string Denumire { get; set; }
        public bool Disponibila { get; set; }

        public Culori Culoare { get; set; }
        public Optiuni OptiuniMasina { get; set; }

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
            string infoOptiuni = OptiuniMasina != 0 ? ", Optiuni: " + OptiuniMasina.ToString() : "";
            return $"{Denumire}, Culoare: {Culoare}, {stare}{infoOptiuni}";
        }
    }
}
