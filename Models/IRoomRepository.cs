using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Models
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();

        Task<Room> GetRoomByIdAsync(Guid id);

        void CreateRoom(Room room);

        void UpdateRoom(Room room);

        void DeleteRoom(Room room);
    }
}