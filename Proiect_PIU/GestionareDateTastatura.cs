using System;

namespace Proiect_PIU
{
    public class GestionareDateTastatura
    {
        // Metodă pentru citirea unei mașini de la tastatură
        public static Masini CitireMasina()
        {
            Console.WriteLine("Introduceti denumirea masinii:");
            string denumire = Console.ReadLine();

            Console.WriteLine("Este masina disponibila? (da/nu)");
            bool disponibila = Console.ReadLine().ToLower() == "da";

            Console.WriteLine("Introduceti culoarea masinii (Rosu/Alb/Negru/Verde/Galben):");
            Culori culoare = (Culori)Enum.Parse(typeof(Culori), Console.ReadLine(), true);

            Console.WriteLine("Introduceti optiunile masinii (AerConditionat, Navigatie, CutieAutomata,HeadUpDisplay,PanoramicRooftop,ScauneIncalzite):");
            string[] optiuniString = Console.ReadLine().Split(',');
            Optiuni optiuni = 0;
            foreach (string optiune in optiuniString)
            {
                Optiuni optiuneEnum;
                if (Enum.TryParse(optiune.Trim(), true, out optiuneEnum))
                {
                    optiuni |= optiuneEnum;
                }
            }

            return new Masini { Denumire = denumire, Disponibila = disponibila, Culoare = culoare, OptiuniMasina = optiuni };
        }
    }
    
}
