using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

[Index("RoleName", Name = "UQ__Roles__8A2B6160ADA55CD8", IsUnique = true)]
public partial class Role
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RoleName { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
