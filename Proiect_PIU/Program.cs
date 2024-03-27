using System;

namespace Proiect_PIU
{
    class Program
    {
        static bool[] disponibilitateMasini = new bool[3];
        static void Main()
        {
            Masini[] masini = new Masini[3];
            int nrMasini = 0;
            string numeFisier = "inchirieri_masini.txt"; // Numele fișierului pentru stocarea închirierilor de mașini
            AdministrareInchirieriMasini_FisierText adminInchirieri = new AdministrareInchirieriMasini_FisierText(numeFisier);

            string optiune;
            do
            {
                Console.WriteLine("1. Adaugare masina");
                Console.WriteLine("2. Afisare masini");
                Console.WriteLine("3. Cautare masina");
                Console.WriteLine("4. Adaugare inchiriere masina");
                Console.WriteLine("5. Afisare inchirieri masini");
                Console.WriteLine("6. Iesire");

                Console.WriteLine("Alegeti o optiune:");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Masini masinaNoua = GestionareDateTastatura.CitireMasina();
                        masini[nrMasini++] = masinaNoua;
                        disponibilitateMasini[nrMasini - 1] = masinaNoua.Disponibila;
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
                        // Citirea datelor pentru închiriere
                        Console.WriteLine("Introduceti numele clientului:");
                        string numeClient = Console.ReadLine();
                        Console.WriteLine("Introduceti denumirea masinii:");
                        string denumireMasina = Console.ReadLine();
                        Console.WriteLine("Introduceti data inchirierii :");
                        string dataInchiriere = Console.ReadLine();

                        bool disponibilitate = disponibilitateMasini[Array.FindIndex(masini, m => m.Denumire == denumireMasina)];

                        // Crearea obiectului InchirieriMasini
                        InchirieriMasini inchiriere = new InchirieriMasini(numeClient, new Masini(denumireMasina, disponibilitate), dataInchiriere);

                        // Adăugarea închirierii în fișier
                        adminInchirieri.AdaugaInchiriere(inchiriere);
                        Console.WriteLine("Inchiriere adaugata cu succes.");
                        break;
                    case "5":
                        // Afișarea închirierilor de mașini din fișier
                        Console.WriteLine("Inchirierile de masini sunt:");
                        int nrInchirieri;
                        InchirieriMasini[] inchirieri = adminInchirieri.GetInchirieri(out nrInchirieri);
                        foreach (InchirieriMasini inchiriereTemp in inchirieri)
                        {
                            Console.WriteLine(inchiriereTemp.Info());
                        }
                        break;
                    case "6":
                        Console.WriteLine("Programul se nchide...");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            } while (optiune != "6");

            Console.ReadKey();
        }
    }
}
