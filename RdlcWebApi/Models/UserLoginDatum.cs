using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class UserLoginDatum
{
    public int Id { get; set; }

    public int UserAccountId { get; set; }

    public string PasswordHash { get; set; }

    public string PasswordSalt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual UserAccount UserAccount { get; set; }
}
