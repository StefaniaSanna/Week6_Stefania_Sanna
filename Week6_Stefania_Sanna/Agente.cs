using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Stefania_Sanna
{
    public class Agente : Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoInizioAttivita { get; set; }

        public Agente()
        {

        }
        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoInizioAttivita): base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizioAttivita = annoInizioAttivita;
        }

        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome} - Cognome: {Cognome} - Anni di servizio: {CalcolaAnniDiServizio()} ";

        }
        public int CalcolaAnniDiServizio()
        {
            return DateTime.Today.Year - AnnoInizioAttivita;

        }      
    }
}
