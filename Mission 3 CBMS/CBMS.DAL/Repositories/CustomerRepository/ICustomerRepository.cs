namespace CBMS.DAL.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<Customer?> GetById(int id);
        Task<int> SaveChangesAsync();
    }
}
