using System;
using System.Collections.Generic;

namespace DepartmentCURD_DBFirst.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? DepartmentHead { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? Status { get; set; }

    public decimal? Budget { get; set; }
}
