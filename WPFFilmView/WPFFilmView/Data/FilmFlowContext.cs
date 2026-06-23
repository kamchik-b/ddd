using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFilmView.Data;

public class FilmFlowContext : DbContext
{
    public DbSet<User> Users {get;set;}
    public DbSet<Movie> Movies {get;set;}
    public DbSet<Review> Reviews {get;set;}
    public DbSet<UserMovieLike>  UserMovieLikes {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=filmflow.db");
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<UserMovieLike>(ur =>
        {
            ur.HasKey(x => new { x.UserId, x.MovieId });

            ur.HasOne(ur => ur.Movie)
                .WithMany(r => r.UserMovieLikes)
                .HasForeignKey(r => r.MovieId)
                .IsRequired();

            ur.HasOne(ur => ur.User)
                .WithMany(r => r.UserMovieLikes)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
        });
        builder.Entity<Review>(r =>
        {
            r.HasOne(x => x.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            r.HasOne(x => x.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(x => x.MovieId)
                .IsRequired();

        });
    }
    
}
