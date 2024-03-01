using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PoliceData.Models;

namespace PoliceData.Controllers
{
    public class AnagrafeController : Controller
    {
        public IActionResult AggiungiAnagrafe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AggiungiAnagrafe(Anagrafiche nuovaAnagrafe)
        {
            try
            {
              ConnDb.conn.Open();

                var command = new SqlCommand(@"INSERT INTO Anagrafiche
              (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES
              (@cognome, @nome, @indirizzo, @citta, @cap, @codiceFiscale)", ConnDb.conn);
                command.Parameters.AddWithValue("@cognome", nuovaAnagrafe.Cognome);
                command.Parameters.AddWithValue("@nome", nuovaAnagrafe.Nome);
                command.Parameters.AddWithValue("@indirizzo", nuovaAnagrafe.Indirizzo);
                command.Parameters.AddWithValue("@citta", nuovaAnagrafe.Citta);
                command.Parameters.AddWithValue("@cap", nuovaAnagrafe.CAP);
                command.Parameters.AddWithValue("@codiceFiscale", nuovaAnagrafe.CodiceFiscale);
                var nRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { ConnDb.conn.Close(); }
            return RedirectToAction("Index", "Home"); //aggiungere feedback riuscita
        }
    }
}
