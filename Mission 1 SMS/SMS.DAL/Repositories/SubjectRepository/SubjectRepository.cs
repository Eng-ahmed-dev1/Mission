namespace SMS.DAL
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationContext _context;
        public SubjectRepository(ApplicationContext Context)
        {
            _context = Context;
        }

        public void Add(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public Task<int> SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
