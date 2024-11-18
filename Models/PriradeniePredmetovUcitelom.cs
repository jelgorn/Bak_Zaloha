using System.ComponentModel.DataAnnotations;

namespace EvidenciaStudentov.Models
{
    public class PriradeniePredmetovUcitelom
    {
        [Key]
        public int PriradenieId { get; set; }
        public int UcitelId { get; set; }
        public int PredmetId { get; set; }

        public Pouzivatel Ucitel { get; set; }
        public Predmet Predmet { get; set; }
    }
}