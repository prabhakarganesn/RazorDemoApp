using System;
using System.Collections.Generic;

namespace DempApp.Models.DB;

public partial class EmployeeType
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
