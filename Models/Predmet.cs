using EvidenciaStudentov.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Predmet
{
    [Key]
    public int PredmetId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nazov { get; set; }

    [StringLength(500)]
    public string Popis { get; set; }

    public ICollection<PriradeniePredmetovUcitelom> PriradeneUcitelom { get; set; }
    public ICollection<PriradeniePredmetovZiakom> PriradeneZiakom { get; set; }

    public Predmet()
    {
        PriradeneUcitelom = new HashSet<PriradeniePredmetovUcitelom>();
        PriradeneZiakom = new HashSet<PriradeniePredmetovZiakom>();
    }
}