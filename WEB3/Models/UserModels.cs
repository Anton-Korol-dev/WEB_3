using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB3.Entities;

namespace Common.Models;

public record UserCreateModel (string Name, string Email, int? GenderId);
public record UserUpdateModel (int Id, string? Name, string? Email, int? GenderId);
public record UserDeleteModel(int Id);
public record GetUsersModel(List<User> Users, int PageSize, int Page);
