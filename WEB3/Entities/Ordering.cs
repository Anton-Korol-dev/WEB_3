using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class Ordering
{
    public string VIN_Number { get; set; }
    public List<User> Client_Phone_Number { get; set; }
    public string Manager { get; set; }
    [Key] public int ID { get; set; }
}