using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Stefania_Sanna
{
    public abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        public Persona()
        {

        }
        public Persona(string nome, string cognome, string codicefiscale )
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codicefiscale;
        }

        public override bool Equals(object obj)
        {
            Persona p = (Persona)obj;
            if (p == null)
            {
                return false;
            }
            else
            {
                return CodiceFiscale == p.CodiceFiscale;
            }
        }
    }
}
