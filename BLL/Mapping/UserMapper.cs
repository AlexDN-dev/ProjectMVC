using BLL.DTO;
using DAL.Entities;

namespace BLL.Mapping;

public static class UserMapper
{
    public static UserDto UserToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            CreatedAt = user.CreatedAt,
            Role = user.Roles
        };
    }

    public static User UserDtoToEntity(CreateUserDto user)
    {
        return new User
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            PasswordHash = user.Password,
        };
    }
}