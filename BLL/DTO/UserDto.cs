using System.Collections;
using DAL.Entities;

namespace BLL.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public ICollection<Role> Role { get; set; } = null!;
}