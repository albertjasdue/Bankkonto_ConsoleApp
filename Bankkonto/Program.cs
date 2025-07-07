namespace BankkontoKonsolenApp
{
    public class Bankkonto
    {
        public string Kontonummer { get; }
        public string Kontoinhaber { get; }
        public decimal Kontostand { get; private set; }

        public Bankkonto(string kontonummer, string kontoinhaber, decimal anfangsBetrag)
        {
            Kontonummer = kontonummer;
            Kontoinhaber = kontoinhaber;
            Kontostand = anfangsBetrag;
        }

        public void Einzahlen(decimal betrag)
        {
            if (betrag <= 0)
                throw new ArgumentException("Der Betrag muss größer als 0 sein.");
            Kontostand += betrag;
            Kontostand = Math.Round(Kontostand, 2, MidpointRounding.ToEven);
        }

        public void Abheben(decimal betrag)
        {
            if (betrag <= 0)
                throw new ArgumentException("Der Betrag muss größer als 0 sein.");
            if (betrag > Kontostand)
                throw new InvalidOperationException("Nicht genügend Guthaben.");
            Kontostand -= betrag;
            Kontostand = Math.Round(Kontostand, 2, MidpointRounding.ToEven);
        }
    }

    public class Programm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Willkommen im Bankkonto-Programm!");
            Console.WriteLine("Bitte geben Sie die folgenden Informationen ein, um ein neues Bankkonto zu erstellen:");

            Console.Write("Name: ");
            string kontoinhaber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(kontoinhaber))
            {
                Console.WriteLine("Der Name darf nicht leer sein.");
                return;
            }

            Console.Write("Kontonummer (10-stellig): ");
            string kontonummer = Console.ReadLine();

            if (kontonummer.Length != 10)
            {
                Console.WriteLine("Deutsche Kontonummern müssen 10-stellig sein.");
                return;
            }

            Console.Write("Anfangsbetrag: ");
            string eingabe = Console.ReadLine();
            decimal anfangsBetrag;

            if (!decimal.TryParse(eingabe, out anfangsBetrag) || anfangsBetrag < 0)
            {
                Console.WriteLine("Ungültiger Anfangsbetrag.");
                return;
            }

            Bankkonto konto = new Bankkonto(kontonummer, kontoinhaber, anfangsBetrag);
            Console.WriteLine($"Bankkonto für {konto.Kontoinhaber} mit Kontonummer {konto.Kontonummer} und Anfangsbetrag {konto.Kontostand} € wurde erfolgreich erstellt.");

            while (true)
            {
                Console.WriteLine("\nWas möchten Sie tun?");
                Console.WriteLine("1. Einzahlen");
                Console.WriteLine("2. Abheben");
                Console.WriteLine("3. Kontostand anzeigen");
                Console.WriteLine("4. Beenden");
                Console.Write("Ihre Wahl: ");
                string wahlText = Console.ReadLine();

                if (!int.TryParse(wahlText, out int wahl) || wahl is < 1 or > 4)
                {
                    Console.WriteLine("Bitte wählen Sie eine gültige Option (1–4).");
                    continue;
                }

                switch (wahl)
                {
                    case 1:
                        Console.Write("Betrag zum Einzahlen: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal einzahlenBetrag))
                        {
                            try
                            {
                                konto.Einzahlen(einzahlenBetrag);
                                Console.WriteLine($"Erfolgreich {einzahlenBetrag}€ eingezahlt. Neuer Kontostand: {konto.Kontostand}€");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ungültiger Betrag.");
                        }
                        break;
                    case 2:
                        Console.Write("Betrag zum Abheben: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal abhebenBetrag))
                        {
                            try
                            {
                                konto.Abheben(abhebenBetrag);
                                Console.WriteLine($"Erfolgreich {abhebenBetrag}€ abgehoben. Neuer Kontostand: {konto.Kontostand}€");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ungültiger Betrag.");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Aktueller Kontostand: {konto.Kontostand}€");
                        break;
                    case 4:
                        Console.WriteLine("Programm wird beendet.");
                        return;
                }
            }
        }
    }
}
