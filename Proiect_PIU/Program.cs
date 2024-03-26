using System;

namespace Proiect_PIU
{
    class Program
    {
        static void Main()
        {
            Masini[] masini = new Masini[3];
            int nrMasini = 0;

            string optiune;
            do
            {
                Console.WriteLine("1. Adaugare masina");
                Console.WriteLine("2. Afisare masini");
                Console.WriteLine("3. Cautare masina");
                Console.WriteLine("4. Iesire");

                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        masini[nrMasini++] = GestionareDateTastatura.CitireMasina();
                        break;
                    case "2":
                        Console.WriteLine("Informatii despre masini:");
                        foreach (Masini masina in masini)
                        {
                            if (masina != null)
                                Console.WriteLine(masina.Info());
                        }
                        break;
                    case "3":
                        Console.WriteLine("Introduceti denumirea masinii cautate:");
                        string denumireCautata = Console.ReadLine();
                        bool gasita = false;
                        foreach (Masini masina in masini)
                        {
                            if (masina != null && masina.Denumire.Equals(denumireCautata))
                            {
                                Console.WriteLine("Masina a fost gasita in sistem.");
                                gasita = true;
                                break;
                            }
                        }
                        if (!gasita)
                            Console.WriteLine("Masina nu a fost gasita in sistem.");
                        break;
                    case "4":
                        Console.WriteLine("Programul se închide...");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            } while (optiune != "4");

            Console.ReadKey();
        }
    }
}
