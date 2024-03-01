using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PoliceData.Models;
using System.Data;

namespace PoliceData.Controllers
{
    public class FunzionalitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TotVerbali()
        {               
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnDb.conn.Open();
                string query = "SELECT Cognome, Nome, COUNT(*) AS TotaleVerbali FROM Verbali AS v  INNER JOIN Anagrafiche AS a ON  v.IdAnagrafica = a.IdAnagrafica  GROUP BY Cognome, Nome";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }            
            }
            catch (Exception ex) { }
            finally { ConnDb.conn.Close(); }
            return View(record); 
        }

        public IActionResult TotPunti()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnDb.conn.Open();
                string query = "SELECT Cognome, Nome, SUM(DecurtamentoPunti) AS PuntiDecurtati FROM Verbali AS v  INNER JOIN Anagrafiche AS a ON  v.IdAnagrafica = a.IdAnagrafica  GROUP BY Cognome, Nome";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnDb.conn.Close(); }
            return View(record);
        }

        public IActionResult Maggiore10Punti()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnDb.conn.Open();
                string query = "SELECT Importo, Cognome, Nome, DataViolazione, DecurtamentoPunti FROM Verbali AS v INNER JOIN Anagrafiche AS a ON v.IdAnagrafica = a.IdAnagrafica WHERE v.DecurtamentoPunti > 10";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnDb.conn.Close(); }
            return View(record);
        }

        public IActionResult Maggiore400Euro()
        {
            DataTable dataTable = new DataTable();
            List<DataRow> record = new List<DataRow>();
            try
            {
                ConnDb.conn.Open();
                string query = "SELECT DataViolazione, Nominativo_Agente, Importo FROM Verbali WHERE Importo > 400";
                SqlDataAdapter adapter = new SqlDataAdapter(query, ConnDb.conn);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    record.Add(row);
                }
            }
            catch (Exception ex) { }
            finally { ConnDb.conn.Close(); }
            return View(record);
        }

    }
    //1) totale verbali trascritti raggruppati per trasgressore
    //2) totale punti decurtati raggruppati per trasgressore
    //3) visualizzare importo, cognome, nome, data di violazione e decurtamento punti delle violazioni che superano 10 punti
    //4) violazioni il cui importo è maggiore di 400 euro
}
