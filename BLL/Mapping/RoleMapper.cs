using BLL.DTO;
using DAL.Entities;

namespace BLL.Mapping;

public class RoleMapper
{
    public static RoleDto RoleToDto(Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            RoleName = role.RoleName,
        };
    }
}