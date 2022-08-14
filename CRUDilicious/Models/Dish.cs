#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUDilicious.Models;

public class Dish {

    [Key]
    public int DishId { get; set; }

    [Required]
    [MinLength(3, ErrorMessage ="must be at least 3 characters.")]
    [MaxLength(45, ErrorMessage ="must be 45 characters or less.")]
    public string Name { get; set; }

    [Required]
    [MinLength(3, ErrorMessage ="must be at least 3 characters.")]
    [MaxLength(45, ErrorMessage ="must be 45 characters or less.")]
    public string Chef { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage ="must be between 1 and 5.")]
    public int Tastiness { get; set; }

    [Required]
    [GreaterThanZero]
    public int Calories { get; set; }

    [Required]
    public string Description { get; set; }

    
    public DateTime CreatedAt { get; set; } = DateTime.Now;



    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}