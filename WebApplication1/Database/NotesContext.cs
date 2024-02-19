using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

    [Table("Notes")] 
    public record Note([property: Key]string Title, string note, string dateandtime){}

    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=my_notes;Username=postgres;Password=password");
    }
