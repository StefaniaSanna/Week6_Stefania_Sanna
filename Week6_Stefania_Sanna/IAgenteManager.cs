using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Stefania_Sanna
{
    public interface IAgenteManager
    {
        public List<Agente> GetAllAgents();
        public List<Agente> GetByArea(string area);
        public List<Agente> GetByServiceYears(int numeroAnniServizio);
        public bool GetByCodiceFiscale(string codiceFiscaleDaVerificare);
        public bool AddAgent(Agente agenteDaAggiungere);
        public List<string> GetAree();
    }
}
