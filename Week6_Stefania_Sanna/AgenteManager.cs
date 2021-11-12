using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Stefania_Sanna
{
    class AgenteManager : IAgenteManager
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      
        public List<Agente> GetAllAgents()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agente";
                SqlDataReader reader = command.ExecuteReader();
                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var codiceFiscale = reader["CodiceFiscale"];
                    var areaGeografica = reader["AreaGeografica"];
                    var annoInizioAttivita = reader["AnnoInizioAttivita"];

                    Agente agentenuovo = new Agente()
                    {
                        Nome = (string)nome,
                        Cognome = (string)cognome,
                        CodiceFiscale = (string)codiceFiscale,
                        AreaGeografica = (string)areaGeografica,
                        AnnoInizioAttivita = (int)annoInizioAttivita
                    };
                    agenti.Add(agentenuovo);
                    if(agenti.Count() == 0)
                    {
                        connection.Close();
                        return null;
                    }
                }
                connection.Close();
                return agenti;              
            }
        }

        public List<Agente> GetByArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agente where AreaGeografica =@a ";
                command.Parameters.AddWithValue("@a", area);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var codiceFiscale = reader["CodiceFiscale"];
                    var areaGeografica = reader["AreaGeografica"];
                    var annoInizioAttivita = reader["AnnoInizioAttivita"];

                    Agente agentenuovo = new Agente()
                    {
                        Nome = (string)nome,
                        Cognome = (string)cognome,
                        CodiceFiscale = (string)codiceFiscale,
                        AreaGeografica = (string)areaGeografica,
                        AnnoInizioAttivita = (int)annoInizioAttivita
                    };
                    agenti.Add(agentenuovo);
                    
                }
                if(agenti.Count() > 0)
                {
                    connection.Close();
                    return agenti;
                }
                connection.Close();
                return null;                             
            }
        }

        public List<Agente> GetByServiceYears(int numeroAnniServizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Agente where (year(getdate())- AnnoInizioAttivita) >= @n"; 
                command.Parameters.AddWithValue("@n", numeroAnniServizio);

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    var nome = reader["Nome"];
                    var cognome = reader["Cognome"];
                    var codiceFiscale = reader["CodiceFiscale"];
                    var areaGeografica = reader["AreaGeografica"];
                    var annoInizioAttivita = reader["AnnoInizioAttivita"];

                    Agente agentenuovo = new Agente()
                    {
                        Nome = (string)nome,
                        Cognome = (string)cognome,
                        CodiceFiscale = (string)codiceFiscale,
                        AreaGeografica = (string)areaGeografica,
                        AnnoInizioAttivita = (int)annoInizioAttivita
                    };
                    agenti.Add(agentenuovo);
                }
                if (agenti.Count() > 0)
                {
                    connection.Close();
                    return agenti;
                }
                connection.Close();
                return null;
            }
        }

        public bool GetByCodiceFiscale(string codiceFiscaleDaVerificare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool isThere = false;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select CodiceFiscale from Agente";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var codiceFiscale = reader["CodiceFiscale"];

                    if((string)codiceFiscale == codiceFiscaleDaVerificare)
                    {
                        isThere = true;
                        connection.Close();
                        return isThere; 
                    }                                
                }               
                connection.Close();
                return isThere ;
            }
        }

        public bool AddAgent(Agente agenteDaAggiungere)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool isAdded = true;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Agente values(@n,@c,@cod,@area,@anno)";
                command.Parameters.AddWithValue("@n", agenteDaAggiungere.Nome);
                command.Parameters.AddWithValue("@c", agenteDaAggiungere.Cognome);
                command.Parameters.AddWithValue("@cod", agenteDaAggiungere.CodiceFiscale);
                command.Parameters.AddWithValue("@area", agenteDaAggiungere.AreaGeografica);
                command.Parameters.AddWithValue("@anno", agenteDaAggiungere.AnnoInizioAttivita);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return isAdded;
                }
                connection.Close();
                isAdded = false;
                return isAdded;
            }
        }

        public List<string> GetAree()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select AreaGeografica from Agente";
                SqlDataReader reader = command.ExecuteReader();
                List<string> aree = new List<string>();

                while (reader.Read())
                {
                    var areaGeografica = reader["AreaGeografica"];                   
                    aree.Add((string)areaGeografica);
                }
                connection.Close();
                return aree;
            }

        }
    }
}
