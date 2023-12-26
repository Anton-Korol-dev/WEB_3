using System.ComponentModel.DataAnnotations;

namespace WEB3.Entities;

public class Gender
{
    [Key]
    public int Id { get; set; }

    [MaxLength(10)]
    public string Name { get; set; } = null!;

    public List<User>? Users { get; set; } = new();
}