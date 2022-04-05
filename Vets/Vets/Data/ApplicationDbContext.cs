using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vets.Models;

namespace Vets.Data
{
    /// <summary>
    /// This class connects our project to the database
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){
        }

        //define table on the database
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Animal> Vets { get; set; }
        public DbSet<Animal> Appointments { get; set; }
        public DbSet<Animal> Owners { get; set; }
        public DbSet<Vets.Models.Owner> Owner { get; set; }
        public DbSet<Vets.Models.Vet> Vet { get; set; }
    }
}