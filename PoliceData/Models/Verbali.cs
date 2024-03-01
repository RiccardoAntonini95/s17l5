using System.Data.SqlTypes;

namespace PoliceData.Models
{
    public class Verbali
    {
        public string DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public string DataTrascrizioneVerbale { get; set; }
        public double Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IdAnagrafica { get; set; }
        public int IdViolazione { get; set; }
    }
}
