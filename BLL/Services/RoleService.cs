using BLL.DTO;
using BLL.Interfaces;
using BLL.Mapping;
using DAL.Repositories;

namespace BLL.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public List<RoleDto> GetAllRoles()
    {
        return _roleRepository.GetAll().Select(RoleMapper.RoleToDto).ToList();
    }
}