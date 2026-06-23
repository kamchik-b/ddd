using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFFilmView.Data;

public class Review
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(300)]
    public string Text { get; set; }
    
    [Range(1,5)]
    public int Rating { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }
    
    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
}
