using System.Threading.Tasks;
using Models.Repositories;

namespace Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        
        public IRoomRepository Room{ get; }

        public UnitOfWork(DataContext dataContext, IRoomRepository roomRepository)
        {
            _dataContext = dataContext;
            Room = roomRepository;
        }
        
        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}