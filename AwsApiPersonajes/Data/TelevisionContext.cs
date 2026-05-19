using AwsApiPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace AwsApiPersonajes.Data
{
    public class TelevisionContext : DbContext
    {
        public TelevisionContext(DbContextOptions<TelevisionContext> options) : base(options)
        {
        }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
