using System;
using System.ComponentModel.DataAnnotations;

public class Dochadzka
{
    [Key]
    public int DochadzkaId { get; set; }

    [Required]
    public int PouzivatelId { get; set; }

    [Required]
    public int PredmetId { get; set; }

    [DataType(DataType.Date)]
    public DateTime Datum { get; set; }

    [Required]
    public string Status { get; set; } // Napr. "pritomny", "nepritomny"
}
