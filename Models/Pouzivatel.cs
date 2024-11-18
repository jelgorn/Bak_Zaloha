using ASP_NET_Bakalarka.Models;
using EvidenciaStudentov.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Pouzivatel
{
    [Key]
    public int PouzivatelId { get; set; }

    [Required]
    [StringLength(50)]
    public string Meno { get; set; }

    [Required]
    [StringLength(50)]
    public string Priezvisko { get; set; }

    [DataType(DataType.Date)]
    public DateTime DatumNarodenia { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string HesloHash { get; set; }

    [Required]
    public int RolaId { get; set; } // Cudzí kľúč na tabuľku `Roly`
    public Rola Rola { get; set; }

    public ICollection<PriradeniePredmetovUcitelom> PriradenePredmetyUcitelom { get; set; }
    public ICollection<PriradeniePredmetovZiakom> PriradenePredmetyZiakom { get; set; }

    public Pouzivatel()
    {
        PriradenePredmetyUcitelom = new HashSet<PriradeniePredmetovUcitelom>();
        PriradenePredmetyZiakom = new HashSet<PriradeniePredmetovZiakom>();
    }
}
