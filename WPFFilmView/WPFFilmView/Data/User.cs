using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFilmView.Data;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    public string AvatarPath { get; set; }
    
    public virtual ICollection<UserMovieLike>? UserMovieLikes { get; set; } 
    public virtual ICollection<Review>? Reviews { get; set; }
}