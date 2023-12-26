using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class List_of_spare_parts
{
    public string Date_of_Arrival { get; set; }
    public string Type_of_Spare_Part { get; set; }
    public int Code_of_Spare_Part { get; set; }
    public int Amount_of_Spare_Part { get; set; }
    public int worker_Code { get; set; }
    [Key] public int ID { get; set; }
    public List<Ordering> OrderCodeNavigation { get; set; }
    public int Price { get; set; }
}