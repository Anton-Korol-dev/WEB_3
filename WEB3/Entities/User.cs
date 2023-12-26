using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WEB3.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int? GenderId { get; set; }

    public Gender? Gender { get; set; }
}
