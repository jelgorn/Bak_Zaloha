using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Bakalarka.Models
{
    public class Rola
    {
        [Key]
        public int RolaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazov { get; set; } // Napr. "Admin", "Učiteľ", "Žiak"

        public ICollection<Pouzivatel> Pouzivatelia { get; set; }

        public Rola()
        {
            Pouzivatelia = new HashSet<Pouzivatel>();
        }
    }
}
