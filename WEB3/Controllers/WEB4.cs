using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB3.Data;
using WEB3.Entities;
using WEB3.Services;

namespace WEB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WEB4 : ControllerBase
    {
        private readonly WEB3Context _context;
        private readonly IUserService _service;

        [HttpGet("users")]
        public async Task<List<User>> GetAllUsers(int page = 1, int pageSize = 10, string? sortBy = null, bool isAsc = false, string? search = null)
        {
            //TODO: add normal pagination and sorting by enum prob???
            var users = await _service.GetAllUsers(page, pageSize, sortBy, isAsc, search);

            return users;
        }

        public WEB4(IUserService service, WEB3Context context)
        {
            _service = service;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateModel user)
        {
            await _service.CreateUser(user);

            return new OkObjectResult("Створено юзера");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateModel user)
        {
            await _service.UpdateUser(user);

            return new OkObjectResult("Оновлено юзера");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(UserDeleteModel user)
        {
            var result = await _service.DeleteUser(user);
            if (result == -1)
            {
                return new NotFoundObjectResult("Користувача не найдено");
            }
            return new OkObjectResult("Видалено юзера");
        }
    }
}
