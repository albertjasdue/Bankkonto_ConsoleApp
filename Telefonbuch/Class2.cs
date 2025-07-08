using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Telefonbuch
{
    internal class Telefonbuch
    {
        private const string DateiName = "telefonbuch.json";
        public Telefonbuch() { }

        public List<Kontakt> KontakteListe { get; set; } = new List<Kontakt>();

        public void Hinzufuegen(Kontakt kontakt)
        {
            KontakteListe.Add(kontakt);
            Speichern();
        }

        public void Entfernen(Kontakt kontakt)
        {
            KontakteListe.Remove(kontakt);
            Speichern();
        }

        public Kontakt Suchen(string name)
        {
            return KontakteListe.FirstOrDefault(k => k.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Aktualisieren(Kontakt kontakt, string neueTelefonnummer, string neueEMail)
        {
            var vorhandenerKontakt = Suchen(kontakt.Name);
            if (vorhandenerKontakt != null)
            {
                vorhandenerKontakt.Telefonnummer = neueTelefonnummer;
                vorhandenerKontakt.EMail = neueEMail;
                Speichern();
            }
            else
            {
                Console.WriteLine("Kontakt nicht gefunden.");
            }
        }

        public void Anzeigen()
        {
            if (KontakteListe.Count == 0)
            {
                Console.WriteLine("Keine Kontakte vorhanden.");
                return;
            }

            foreach (var kontakt in KontakteListe)
            {
                Console.WriteLine($"Name: {kontakt.Name}, Telefonnummer: {kontakt.Telefonnummer}, E-Mail: {kontakt.EMail}");
                Console.WriteLine(kontakt.Name);
                Console.WriteLine(kontakt.Telefonnummer);
            }
        }
        public void Speichern()
        {
            try
            {
                string json = JsonSerializer.Serialize(KontakteListe, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(DateiName, json);
                Console.WriteLine("Telefonbuch gespeichert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
            }
        }
    }
}
