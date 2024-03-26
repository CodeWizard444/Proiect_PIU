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

            return new Masini { Denumire = denumire, Disponibila = disponibila };
        }
    }
}
