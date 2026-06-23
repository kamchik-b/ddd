using System.ComponentModel.DataAnnotations;

namespace WPFFilmView.Data;

public class Movie
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int ReleaseYear { get; set; }
    
    public virtual ICollection<UserMovieLike>? UserMovieLikes { get; set; } 
    public virtual ICollection<Review>? Reviews { get; set; }
}