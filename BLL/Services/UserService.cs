using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public List<UserDto> GetAllUsers()
    {
        return _userRepository.GetAll().Select(UserMapper.UserToDto).ToList();
    }

    public UserDto CreateUser(CreateUserDto user)
    {
        User? existingUser = _userRepository.GetByEmail(user.Email);
        if (existingUser is not null)
        {
            throw new Exception("Un compte avec cet email existe déjà.");
        }

        User userEntity = UserMapper.UserDtoToEntity(user);
        userEntity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _userRepository.Create(userEntity);
        return UserMapper.UserToDto(userEntity);
    }

    public UserDto? GetUserById(int id)
    {
        User? user = _userRepository.GetById(id);
        if (user is not null)
        {
            throw new Exception("Aucun user trouvé.");
        }

        return UserMapper.UserToDto(user);
    }

    public UserDto EditUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUserById(int id)
    {
        throw new NotImplementedException();
    }

    public bool AddRoleToUser(int userId, int roleId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveRoleFromUser(int userId, int roleId)
    {
        throw new NotImplementedException();
    }
}