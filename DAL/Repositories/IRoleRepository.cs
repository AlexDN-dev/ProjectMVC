using DAL.Entities;

namespace DAL.Repositories;

public interface IRoleRepository
{
    IEnumerable<Role> GetAll();
    Role? GetById(int id);
}