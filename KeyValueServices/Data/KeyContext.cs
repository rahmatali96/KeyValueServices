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
    }
}
