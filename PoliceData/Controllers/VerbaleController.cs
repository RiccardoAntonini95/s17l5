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
