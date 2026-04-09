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
}