using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PoliceData.Models;

namespace PoliceData.Controllers
{
    public class VerbaleController : Controller
    {
        [HttpGet]
        public IActionResult AggiungiVerbale()
        {
            List<TipiViolazione> listaViolazioni = [];
            List<Anagrafiche> listaAnagrafiche = [];
            try
            {
              ConnDb.conn.Open();
                var command = new SqlCommand("SELECT * from TipiViolazione", ConnDb.conn);
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var violazione = new TipiViolazione()
                        {
                            Id = (int)reader["IdViolazione"],
                            TipoViolazione = (string)reader["Descrizione"]
                        };
                        listaViolazioni.Add(violazione);
                    }
                    ViewBag.listaViolazioni = listaViolazioni;
                    ConnDb.conn.Close(); //è necessario chiudere la connessione per fare un'altra query
                }

                ConnDb.conn.Open();
                var command2 = new SqlCommand("SELECT * from Anagrafiche", ConnDb.conn);
                var reader2 = command2.ExecuteReader();

                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        var trasgressore = new Anagrafiche()
                        {
                            Id = (int)reader2["IdAnagrafica"],
                            Cognome = (string)reader2["Cognome"],
                            Nome = (string)reader2["Nome"],
                            Indirizzo = (string)reader2["Indirizzo"],
                            Citta = (string)reader2["Città"],
                            CAP = (string)reader2["CAP"],
                            CodiceFiscale = (string)reader2["Cod_Fisc"]
                        };
                        listaAnagrafiche.Add(trasgressore);
                    }
                    ViewBag.listaAnagrafiche = listaAnagrafiche;
                }
            }
            catch (Exception ex)
            {

            }
            finally { ConnDb.conn.Close(); }
            return View();
        }

    }
}
