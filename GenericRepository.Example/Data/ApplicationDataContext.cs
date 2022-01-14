using GenericRepository.Example.Data.Schemas;
using GenericRepository.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Example.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ConfigureWaifuSchema();

        public DbSet<Waifu> Waifu { get; set; }
    }
}
