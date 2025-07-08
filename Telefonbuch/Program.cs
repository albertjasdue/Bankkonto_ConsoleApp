using System;

namespace Telefonbuch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Telefonbuch meinTelefonbuch = new Telefonbuch();
            string wahl;

            do
            {
                Console.Clear();
                Console.WriteLine("Willkommen im Telefonbuch!");
                Console.WriteLine("1. Kontakt hinzufügen");
                Console.WriteLine("2. Kontakt entfernen");
                Console.WriteLine("3. Kontakt suchen");
                Console.WriteLine("4. Kontakt aktualisieren");
                Console.WriteLine("5. Kontakte anzeigen");
                Console.WriteLine("6. Beenden");
                Console.Write("Ihre Wahl: ");
                wahl = Console.ReadLine();

                switch (wahl)
                {
                    case "1":
                        KontaktHinzufuegen(meinTelefonbuch);
                        break;
                    case "2":
                        KontaktEntfernen(meinTelefonbuch);
                        break;
                    case "3":
                        KontaktSuchen(meinTelefonbuch);
                        break;
                    case "4":
                        KontaktAktualisieren(meinTelefonbuch);
                        break;
                    case "5":
                        meinTelefonbuch.Anzeigen();
                        break;
                    case "6":
                        Beenden();
                        break;
                    default:
                        Console.WriteLine("Ungültige Wahl. Bitte versuchen Sie es erneut.");
                        break;
                }

                if (wahl != "6")
                {
                    Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
                    Console.ReadKey();
                }
            } while (wahl != "6");
        }

        public static void KontaktHinzufuegen(Telefonbuch telefonbuch)
        {
            Console.WriteLine("\nFügen Sie einen neuen Kontakt hinzu:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name darf nicht leer sein.");
                return;
            }
            Console.Write("Telefonnummer: ");
            string telefonnummer = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(telefonnummer))
            {
                Console.WriteLine("Telefonnummer darf nicht leer sein.");
                return;
            }
            Console.Write("E-Mail: ");
            string eMail = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(eMail))
            {
                Console.WriteLine("E-Mail darf nicht leer sein.");
                return;
            }
            Kontakt neuerKontakt = new Kontakt(name, telefonnummer, eMail);
            telefonbuch.Hinzufuegen(neuerKontakt);
            Console.WriteLine("Kontakt hinzugefügt.");
        }

        public static void KontaktEntfernen(Telefonbuch telefonbuch)
        {
            Console.Write("Name des zu entfernenden Kontakts: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name darf nicht leer sein.");
                return;
            }
            Kontakt kontakt = telefonbuch.Suchen(name);
            if (kontakt != null)
            {
                telefonbuch.Entfernen(kontakt);
                Console.WriteLine("Kontakt entfernt.");
            }
            else
            {
                Console.WriteLine("Kontakt nicht gefunden.");
            }
        }

        public static void KontaktSuchen(Telefonbuch telefonbuch)
        {
            Console.Write("Name des zu suchenden Kontakts: ");
            string name = Console.ReadLine();
            Kontakt kontakt = telefonbuch.Suchen(name);
            if (kontakt != null)
            {
                Console.WriteLine($"Name: {kontakt.Name}, Telefonnummer: {kontakt.Telefonnummer}, E-Mail: {kontakt.EMail}");
            }
            else
            {
                Console.WriteLine("Kontakt nicht gefunden.");
            }
        }

        public static void KontaktAktualisieren(Telefonbuch telefonbuch)
        {
            Console.Write("Name des zu aktualisierenden Kontakts: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name darf nicht leer sein.");
                return;
            }
            Kontakt kontakt = telefonbuch.Suchen(name);
            if (kontakt != null)
            {
                Console.Write("Neue Telefonnummer: ");
                string neueTelefonnummer = Console.ReadLine();
                Console.Write("Neue E-Mail: ");
                string neueEMail = Console.ReadLine();
                telefonbuch.Aktualisieren(kontakt, neueTelefonnummer, neueEMail);
                Console.WriteLine("Kontakt aktualisiert.");
            }
            else
            {
                Console.WriteLine("Kontakt nicht gefunden.");
            }
        }

        public static void Beenden()
        {
            Console.WriteLine("Das Programm wird beendet.");
            Environment.Exit(0);
        }
    }
}
