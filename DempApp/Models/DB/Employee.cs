using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DempApp.Models.DB;

public partial class Employee
{
    public long Id { get; set; }
    [DisplayName("First Name")]
    public string FirstName { get; set; } = null!;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = null!;
    [DisplayName("Employee Type")]
    public long EmployeeType { get; set; }
    [DisplayName("Employee Type")]
    public virtual EmployeeType EmployeeTypeNavigation { get; set; } = null!;
}
