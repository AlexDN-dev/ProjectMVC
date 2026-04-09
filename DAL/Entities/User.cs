using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

[Index("Email", Name = "UQ__Users__A9D105340815C7A9", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Firstname { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Lastname { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual List<Role> Roles { get; set; } = new List<Role>();
}
