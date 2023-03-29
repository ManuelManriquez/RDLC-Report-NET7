using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class Student
{
    public string ControlNumber { get; set; }

    public int UserAccountId { get; set; }

    public int CareerId { get; set; }

    public string Nss { get; set; }

    public DateTime AdmissionDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Career Career { get; set; }

    public virtual ICollection<ServicioSocialProcedure> ServicioSocialProcedures { get; } = new List<ServicioSocialProcedure>();

    public virtual UserAccount UserAccount { get; set; }
}
