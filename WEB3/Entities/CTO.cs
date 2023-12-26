using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class CTO
{
    [Key] public int Id { get; set; }
    public string Name_of_CTO { get; set; }
    public string Amount_of_workers { get; set; }
}