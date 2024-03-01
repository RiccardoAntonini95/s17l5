﻿namespace PoliceData.Models
{
    public class Anagrafiche
    {
        public int? Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string CodiceFiscale { get; set; }
    }
}