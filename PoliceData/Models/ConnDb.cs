using Microsoft.Data.SqlClient;

namespace PoliceData.Models
{
    public class ConnDb
    {
        private static string connString = "Server=HP-RIC\\SQLEXPRESS; Initial Catalog=InfrazioniPolizia; Integrated Security=true; TrustServerCertificate=True";
        public static SqlConnection conn = new SqlConnection(connString);
    }
}
