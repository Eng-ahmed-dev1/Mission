namespace HMS.DAL
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        void Update(Guest guest);
        void Delete(Guest guest);
        void Add(Guest guest);
        Task<Guest?> GetById (int id);
        Task<int> SaveChangesAsync();


    }
}
