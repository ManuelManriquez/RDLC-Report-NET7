using System;
using System.Collections.Generic;

namespace RdlcWebApi.Models;

public partial class ServicioSocialLetter
{
    public int Id { get; set; }

    public int ServicioSocialProcedureId { get; set; }

    public int StatusId { get; set; }

    public string LetterType { get; set; }

    public string ProjectName { get; set; }

    public int? TotalHours { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string ScheduleDays { get; set; }

    public TimeSpan? ScheduleStartHours { get; set; }

    public TimeSpan? ScheduleEndHours { get; set; }

    public string OfficialDependency { get; set; }

    public string StudentActivity { get; set; }

    public string StudentServiceModality { get; set; }

    public string SupervisorName { get; set; }

    public string SupervisorPosition { get; set; }

    public string HeadOfDepartmentName { get; set; }

    public string HeadOfDepartmentPosition { get; set; }

    public string AddresseeName { get; set; }

    public string AddresseePosition { get; set; }

    public string FilePath { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ServicioSocialProcedure ServicioSocialProcedure { get; set; }

    public virtual Status Status { get; set; }
}
