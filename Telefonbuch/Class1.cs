using System;

namespace Telefonbuch
{
    internal class Kontakt
    {
        public string Name { get; set; }
        public string Telefonnummer { get; set; }
        public string EMail { get; set; }

        public Kontakt(string name, string telefonnummer, string eMail)
        {
            Name = name;
            Telefonnummer = telefonnummer;
            EMail = eMail;
        }
    }
}

