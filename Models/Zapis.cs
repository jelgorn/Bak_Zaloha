using System.ComponentModel.DataAnnotations;

public class Zapis
{
    [Key]
    public int ZapisId { get; set; }

    [Required]
    public int PouzivatelId { get; set; }

    [Required]
    public int PredmetId { get; set; }
}
