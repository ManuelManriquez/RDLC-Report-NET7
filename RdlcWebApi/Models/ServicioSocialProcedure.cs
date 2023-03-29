using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class ServicioSocialProcedure
{
    public int Id { get; set; }

    public string StudentControlNumber { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ServicioSocialLetter> ServicioSocialLetters { get; } = new List<ServicioSocialLetter>();

    public virtual Status Status { get; set; }

    public virtual Student StudentControlNumberNavigation { get; set; }
}
