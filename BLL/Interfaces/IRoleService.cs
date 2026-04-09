using BLL.DTO;

namespace BLL.Interfaces;

public interface IRoleService
{
    List<RoleDto> GetAllRoles();
}