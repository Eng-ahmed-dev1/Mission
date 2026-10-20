namespace SMS.DAL
{
    public interface ISubjectRepository
    {
        void Add(Subject subject);
        Task<int> SaveChangeAsync();
    }
}
