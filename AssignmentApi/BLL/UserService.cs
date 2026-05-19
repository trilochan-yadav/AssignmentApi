using AssignmentApi.BLL.Interfaces;
using AssignmentApi.DAL.Interfaces;
using AssignmentApi.DTOs;
using AssignmentApi.Models;

namespace AssignmentApi.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDto?> GetById(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return null;
            }

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Address1 = user.Address1,
                Address2 = user.Address2
            };
        }

        public async Task<List<UserResponseDto>> GetUsers(int lastSeenId, int pageSize)
        {
            var users = await _repository.GetUsers(lastSeenId, pageSize);

            return users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Address1 = u.Address1,
                    Address2 = u.Address2
                })
                .ToList();
        }

        public async Task<UserResponseDto> Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Address1 = dto.Address1,
                Address2 = dto.Address2
            };

            user = await _repository.Create(user);

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Address1 = user.Address1,
                Address2 = user.Address2
            };
        }

        public async Task Update(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return;
            }

            user.Name = dto.Name;
            user.Address1 = dto.Address1;
            user.Address2 = dto.Address2;

            await _repository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}