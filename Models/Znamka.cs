using System;
using System.ComponentModel.DataAnnotations;

public class Znamka
{
    [Key]
    public int ZnamkaId { get; set; }

    [Required]
    public int PouzivatelId { get; set; }

    [Required]
    public int PredmetId { get; set; }

    [Required]
    public int Hodnota { get; set; } // Napr. 1 až 5

    [DataType(DataType.Date)]
    public DateTime Datum { get; set; }
}
