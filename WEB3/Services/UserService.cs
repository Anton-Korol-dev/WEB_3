using Common.Models;
using Dapper;
using WEB3;
using WEB3.Entities;
using WEB3.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using WEB3.Data;

namespace WEB3.Services;

internal sealed class UserService : IUserService
{
    private readonly WEB3Context _context;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UserService(WEB3Context appDbContext, ISqlConnectionFactory sqlConnectionFactory)
    {
        _context = appDbContext;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> CreateUser(UserCreateModel model)
    {
        var user = new User
        {
            Email = model.Email,
            GenderId = model.GenderId,
            Name = model.Name,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> DeleteUser(UserDeleteModel model)
    {
        try
        {
            var user = await _context.Users
                           .FirstOrDefaultAsync(user => user.Id == model.Id)
                       ?? throw new Exception("User not found");
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        { return -1; }
    }

    public async Task<List<User>> GetAllUsers(int page, int pageSize, string? sortBy, bool? isAsc, string? search)
    {
        IQueryable<User> userQuery = sortBy switch
        {
            "Name" when isAsc!.Value => _context.Users.OrderBy(user => user.Name),
            "Name" when !isAsc.Value => _context.Users.OrderByDescending(user => user.Name),
            "Email" when isAsc!.Value => _context.Users.OrderBy(user => user.Email),
            "Email" when !isAsc.Value => _context.Users.OrderByDescending(user => user.Email),
            "Gender" when isAsc!.Value => _context.Users.OrderBy(user => user.GenderId),
            "Gender" when !isAsc.Value => _context.Users.OrderBy(user => user.GenderId),
            _ => _context.Users.OrderBy(user => user.Id),
        };

        // Apply search if search is not null
        if (!string.IsNullOrWhiteSpace(search))
        {
            userQuery = userQuery.Where(e => e.Name.Contains(search));
        }

        var users = await userQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        return users;
    }

    public async Task UpdateUser(UserUpdateModel model)
    {
        var user = await _context.Users
                       .FirstOrDefaultAsync(user => user.Id == model.Id)
                   ?? throw new Exception("User not found");

        user.Name = model.Name ?? user.Name;
        user.Email = model.Email ?? user.Email;
        user.GenderId = model.GenderId ?? user.GenderId;

        _context.Users.Update(user);
        _context.SaveChanges();
    }
}