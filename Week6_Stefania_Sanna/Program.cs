using System;
using System.Collections.Generic;

namespace Week6_Stefania_Sanna
{
    class Program
    {
        //Domande di teoria
        //Domanda 1: a, e, g
        //Domanda 2: b,d
        //Domanda 3: a,b,c
        private static AgenteManager agenteManager = new AgenteManager();
        //private static AgenteManagerMock agenteManager = new AgenteManagerMock();
        static void Main(string[] args)
        {
            bool continua = true;
            do
            {
                Console.WriteLine("----------Menù----------");
                Console.WriteLine("[1] Stampa tutti gli agenti di polizia");
                Console.WriteLine("[2] Mostra tutti gli agenti per area geografica");
                Console.WriteLine("[3] Mostra gli agenti con anni di servizio maggiori o uguali a quelli selezionati");
                Console.WriteLine("[4] Inserire un nuovo Agente");
                Console.WriteLine("[0] Esci");
                int scelta;
                do
                {
                    Console.WriteLine("Seleziona un'opzione");
                }
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        MostraTuttiAgenti();
                        break;
                    case 2:
                        StampaPerArea();
                        break;
                    case 3:
                        StampaPerAnniDiServizio();
                        break;
                    case 4:
                        AggiungiAgente();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        break;
                }
            }
            while (continua == true);
        }
        private static void AggiungiAgente()
        {
            bool IsThere = true;
            string codiceFiscaleProva;
            do
            {
                Console.WriteLine("Inserire il codice fiscale dell'agente che si vuole aggiungere");
                codiceFiscaleProva = Console.ReadLine();
                IsThere = agenteManager.GetByCodiceFiscale(codiceFiscaleProva);
                if (IsThere == true)
                {
                    Console.WriteLine("Siamo spiacenti, questo codice fiscale è già presente");
                }
            }
            while (IsThere == true);

            Console.WriteLine("Inserire il nome dell'agente");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserire il cognome dell'agente");
            string nuovoCognome = Console.ReadLine();
            Console.WriteLine("Inserire l'area geografica assegnata all'agente");
            string nuovaArea = Console.ReadLine();
            Console.WriteLine("Inserire l'anno di inizio di attività dell'agente");
            int nuovoAnnoInizioAttivita = CheckNumber();

            Agente nuovoAgente = new Agente(nuovoNome, nuovoCognome, codiceFiscaleProva, nuovaArea, nuovoAnnoInizioAttivita);
            bool isAdded = agenteManager.AddAgent(nuovoAgente);
            if (isAdded == true)
            {
                Console.WriteLine("Agente aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("Qualcosa è andato storto");
            }

        }
        private static void StampaPerAnniDiServizio()
        {
            Console.WriteLine("Selezionare il numero minimo di anni di servizio degli agenti");
            int numeroAnniDiServizio = CheckNumber();
            List<Agente> listaAgenti = agenteManager.GetByServiceYears(numeroAnniDiServizio);
            if (listaAgenti == null)
            {
                Console.WriteLine($"Spiacenti,non è stato identificato alcun agente con {numeroAnniDiServizio} anni di servizio");
            }
            else
            {
                Console.WriteLine($"Gli agenti con un numero di anni uguale o superiore a {numeroAnniDiServizio} sono:");

                foreach (var item in listaAgenti)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }

        }
        private static int CheckNumber()
        {
            int numero;
            while (!(int.TryParse(Console.ReadLine(), out numero) && numero > 0))
            {
                Console.WriteLine("Valore errato, riprova");
            }
            return numero;
        }
        private static void StampaPerArea()
        {
            StampaTutteAree();
            Console.WriteLine("Inserire l'area geografica");
            string areaSelezionata = Console.ReadLine();
            List<string> listaAree = agenteManager.GetAree();
            bool areaCorretta = false;
            foreach (var item in listaAree)
            {
                if (areaSelezionata == item)
                {
                    areaCorretta = true;
                }
            }
            if (areaCorretta == true)
            {
                List<Agente> listaAgenti = agenteManager.GetByArea(areaSelezionata);
                if (listaAgenti == null)
                {
                    Console.WriteLine($"Spiacenti, nell'area {areaSelezionata} non è stato identificato alcun agente");
                }
                else
                {
                    Console.WriteLine($"Nell'area {areaSelezionata} ci sono gli agenti:");

                    foreach (var item in listaAgenti)
                    {
                        Console.WriteLine($"{item.ToString()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Non è disponibile l'area selezionata");
            }
        }
        private static void MostraTuttiAgenti()
        {
            List<Agente> listaAgenti = agenteManager.GetAllAgents();
            if (listaAgenti == null)
            {
                Console.WriteLine("Non è presente alcun agente");
            }
            else
            {
                Console.WriteLine("Gli agenti di polizia sono:");

                foreach (var item in listaAgenti)
                {
                    Console.WriteLine($"{item.ToString()}");
                }
            }
        }
        private static void StampaTutteAree()
        {
            Console.WriteLine("Le aree geografiche disponibili sono");
            List<string> listaAree = agenteManager.GetAree();
            List<string> listaFiltrata = new List<string>(); //per evitare i doppioni nel menù
            bool isAlreadyThere = false;
            foreach (var item in listaAree)
            {
                foreach (var item1 in listaFiltrata)
                {
                    if (item == item1)
                    {
                        isAlreadyThere = true;
                    }
                }
                if (isAlreadyThere != true)
                {
                    listaFiltrata.Add(item);
                }
            }
            foreach (var item in listaFiltrata)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }
    }
}
