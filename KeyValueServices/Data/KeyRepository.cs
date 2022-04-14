using KeyValueServices.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyValueServices.Data
{
    public class KeyRepository : IKeyRepository
    {
        private KeyContext _context;

        public KeyRepository(KeyContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity); ;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Key[]> GetAllKeysAsync()
        {
            IQueryable<Key> query = _context.Keys;
            return await query.ToArrayAsync();
        }

        public async Task<Key> GetKeyAsync(string key)
        {
            IQueryable<Key> query = _context.Keys;
            query = query.Where(o => o.key == key);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Key> UpdateKey(Key keymodal)
        {
            var exist = _context.Keys.Find(keymodal.key);
            _context.Keys.Update(exist);
            _context.SaveChangesAsync(); 
            return exist;
        }
    }
}
