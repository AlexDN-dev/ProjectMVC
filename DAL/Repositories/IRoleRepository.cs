using DAL.Entities;

namespace DAL.Repositories;

public interface IRoleRepository
{
    IEnumerable<Role> GetAll();
    Role? GetById(int id);
    int Create(Role role);
    void Update(Role role);
    void Delete(int id);
}