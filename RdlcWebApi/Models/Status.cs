using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ServicioSocialLetter> ServicioSocialLetters { get; } = new List<ServicioSocialLetter>();

    public virtual ICollection<ServicioSocialProcedure> ServicioSocialProcedures { get; } = new List<ServicioSocialProcedure>();
}
