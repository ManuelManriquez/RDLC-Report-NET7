using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class UserAccount
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string PaternalName { get; set; }

    public string MaternalName { get; set; }

    public string Role { get; set; }

    public string Email { get; set; }

    public string IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<UserLoginDatum> UserLoginData { get; } = new List<UserLoginDatum>();
}
