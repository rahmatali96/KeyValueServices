using KeyValueServices.Models;

namespace KeyValueServices.Data
{
    public interface IKeyRepository
    {
        // General 
        void Add<K>(K entity) where K : class;
        void Delete<K>(K entity) where K : class;
        Task<bool> SaveChangesAsync();

        // Camps
        Task<Key[]> GetAllKeysAsync();
        Task<Key> GetKeyAsync(string key);
    }
}
