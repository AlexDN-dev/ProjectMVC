using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetAll()
    {
        return _context.Users.Include(u => u.Roles).AsNoTracking().ToList(); //AsNoTracking est optionnel mais boost les perfs pour de la lecture seul? askip
    }

    public User? GetById(int id)
    {
        return _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == id);
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public int Create(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        User? user = _context.Users.Find(id);
        if (user is not null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public void AddRoleToUser(int userId, int roleId)
    {
        User? user = _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == userId);
        Role? role = _context.Roles.Find(roleId);

        if (user is not null && role is not null)
        {
            if (!user.Roles.Any(r => r.Id == roleId))
            {
                user.Roles.Add(role);
                _context.SaveChanges();
            }
        }
    }

    public void RemoveRoleFromUser(int userId, int roleId)
    {
        User? user = _context.Users.Include(u => u.Roles)
            .FirstOrDefault(u => u.Id == userId);
        if (user is not null)
        {
            Role? roleToRemove = user.Roles.FirstOrDefault(r => r.Id == roleId);

            if (roleToRemove is not null)
            {
                user.Roles.Remove(roleToRemove);
                _context.SaveChanges();
            }
        }
    }
}