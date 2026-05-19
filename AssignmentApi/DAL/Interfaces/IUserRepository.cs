using AssignmentApi.Models;

namespace AssignmentApi.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);

        Task<List<User>> GetUsers(int lastSeenId, int pageSize);

        Task<User> Create(User user);

        Task Update(User user);

        Task Delete(int id);
    }
}