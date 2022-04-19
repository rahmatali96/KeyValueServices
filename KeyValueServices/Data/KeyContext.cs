using KeyValueServices.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyValueServices.Data
{
    public class KeyContext:DbContext
    {
        public KeyContext(DbContextOptions<KeyContext> options) : base(options)
        {
            
        }
        public DbSet<Key> Keys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>().HasData(
                new Key { key = "temp_dev0", value = "87" }
                );
        }
    }
}
