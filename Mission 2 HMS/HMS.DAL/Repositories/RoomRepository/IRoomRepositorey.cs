namespace HMS.DAL
{
    public interface IRoomRepositorey
    {
        void Add(Room room);
        Task<int> SaveChangesAsync();
    }
}
