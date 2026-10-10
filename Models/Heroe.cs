using System.ComponentModel.DataAnnotations;

namespace HeroesMvc.Models;

public class Heroe
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;
}
