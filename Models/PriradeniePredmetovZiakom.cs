using System.ComponentModel.DataAnnotations;

namespace EvidenciaStudentov.Models
{
    public class PriradeniePredmetovZiakom
    {
        [Key]
        public int PriradenieId { get; set; }
        public int ZiakId { get; set; }
        public int PredmetId { get; set; }

        public Pouzivatel Ziak { get; set; }
        public Predmet Predmet { get; set; }
    }
}