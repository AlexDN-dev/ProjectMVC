using BLL.DTO;

namespace BLL.Interfaces;

public interface IUserService
{
    List<UserDto> GetAllUsers();
    bool CreateUser(CreateUserDto user);
    UserDto? GetUserById(int id);
    UserDto EditUser(UserDto user);
    bool DeleteUserById(int id);
    bool AddRoleToUser(int userId, int roleId);
    bool RemoveRoleFromUser(int userId, int roleId);
}