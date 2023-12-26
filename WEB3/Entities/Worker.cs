using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class Worker
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int? Salary { get; set; }
    public string Worker_Phone_Number { get; set; }
    public string? Type_of_Worker { get; set; }
    public string? Adress { get; set; }
    public string? Experience { get; set; }
    [Key] public string ID { get; set; }
}