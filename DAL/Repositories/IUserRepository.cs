using DAL.Entities;

namespace DAL.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    User? GetByEmail(string email);
    int Create(User user);
    void Update(User user);
    void Delete(int id);
    void AddRoleToUser(int userId, int roleId);
    void RemoveRoleFromUser(int userId, int roleId);
}