using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Stefania_Sanna
{
    class AgenteManagerMock : IAgenteManager
    { //ho iniziato ma non ho implementato per il punto 4
        static List<Agente> agenti = new List<Agente>()
        {
            new Agente{Nome="Silvia",Cognome="Scano", CodiceFiscale="SLVSCNG96JF96KGU",AreaGeografica="Porto",AnnoInizioAttivita=2017}

        };
        public bool AddAgent(Agente agenteDaAggiungere)
        {
            throw new NotImplementedException();
        }

        public List<Agente> GetAllAgents()
        {
            return agenti;
        }

        public List<string> GetAree()
        {
            List<string> aree = new List<string>();
            foreach (var item in agenti)
            {
                aree.Add(item.AreaGeografica);         
            }
            return aree;
        }

        public List<Agente> GetByArea(string area)
        {
            List<Agente> agentiPerArea = new List<Agente>();
            foreach (var item in agenti)
            {
                if (area == item.AreaGeografica)
                    agentiPerArea.Add(item);
            }
            return agentiPerArea;
        }

        public bool GetByCodiceFiscale(string codiceFiscaleDaVerificare)
        {
            throw new NotImplementedException();
        }

        public List<Agente> GetByServiceYears(int numeroAnniServizio)
        {
            List<Agente> agentiPerAnniDiServizio = new List<Agente>();
            foreach (var item in agenti)
            {
                int anniServizio = item.CalcolaAnniDiServizio();
                if(anniServizio>= numeroAnniServizio)
                {
                    agentiPerAnniDiServizio.Add(item);
                }
            }
            return agentiPerAnniDiServizio;
        }
    }
}
