using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB3.Entities;

public class Car
{
    public string CarManufacturer { get; set; }

    public string CarModel { get; set; }

    public string YearOfManufactureOfTheCar { get; set; }

    public string FuelType { get; set; }

    public int ClientCode { get; set; }

    [Key] public string VinNumber { get; set; } = null!;

    public virtual List<User> ClientCodeNavigation { get; set; }
}
