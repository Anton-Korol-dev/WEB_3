using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class List_of_works
{
    public string Work_Name { get; set; }
    public string Duration_of_Work { get; set; }
    public List<Worker> worker_Code { get; set; }
    [Key] public int ID { get; set; }
    public List<Ordering> Code_of_Ordering { get; set; }
    public int Price { get; set; }
}