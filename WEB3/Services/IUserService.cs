using Common.Models;
using WEB3.Entities;

namespace WEB3.Services;

public interface IUserService
{
    Task<int> CreateUser(UserCreateModel model);
    Task DeleteUser(UserDeleteModel model);
    Task UpdateUser(UserUpdateModel model);
    Task<List<User>> GetAllUsers(int page, int pageSize, string? sortBy, bool? isAsc, string? search);
}
