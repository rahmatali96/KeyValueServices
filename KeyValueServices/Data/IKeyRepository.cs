using KeyValueServices.Models;

namespace KeyValueServices.Data
{
    public interface IKeyRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Camps
        Task<Key[]> GetAllKeysAsync();
        Task<Key> GetKeyAsync(string key);
        Task<Key> UpdateKey(Key keymodal);

    }
}
