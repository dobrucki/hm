using System.Threading.Tasks;

namespace Models
{
    public interface IUnitOfWork
    {
        IRoomRepository Room{ get; }

        Task SaveAsync();
    }
}