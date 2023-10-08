using System;
using System.Collections.Generic;

namespace DepartmentCURD_DBFirst.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public bool? IsActive { get; set; }
}
