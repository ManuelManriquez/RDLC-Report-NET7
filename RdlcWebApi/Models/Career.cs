using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class Career
{
    public int Id { get; set; }

    public string CareerCurriculum { get; set; }

    public string CarrerCurriculumAcronym { get; set; }

    public string CareerKey { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
