using AssignmentApi.DTOs;

namespace AssignmentApi.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto?> GetById(int id);

        Task<List<UserResponseDto>> GetUsers(int lastSeenId, int pageSize);

        Task<UserResponseDto> Create(CreateUserDto dto);

        Task Update(int id, UpdateUserDto dto);

        Task Delete(int id);
    }
}