using DAL.Entities;

namespace DAL.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;

    }
    public IEnumerable<Role> GetAll()
    {
        return _context.Roles.ToList();
    }

    public Role? GetById(int id)
    {
        return _context.Roles.Find(id);
    }

    public int Create(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
        return role.Id;
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Role? role = _context.Roles.Find(id);

        if (role is not null)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}