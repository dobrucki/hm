using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await FindAll().OrderBy(room => room.Number).ToListAsync();
        }

        public async Task<Room> GetRoomById(Guid id)
        {
            return await FindByCondition(room => room.Id == id)
                .FirstOrDefaultAsync();
        }

        public void CreateRoom(Room room)
        {
            Create(room);
        }

        public void UpdateRoom(Room room)
        {
            Update(room);
        }

        public void DeleteRoom(Room room)
        {
            Delete(room);
        }
    }
}