using BackApi.Contracts.User;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение информации обо всех пользователях
        /// </summary>
        /// <remarks></remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <remarks></remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse()
            {
                UserId = result.UserId,
                Login = result.Login,
                PasswordHash = result.PasswordHash,
                RoleId = result.RoleId,
            };

            return Ok(await _userService.GetById(id));
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Login" : "stud123",
        ///        "PasswordHash" : "hash11",
        ///        "RoleId" : "1"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = new User()
            {
                Login = request.Login,
                PasswordHash = request.PasswordHash,
                RoleId = request.RoleId,
            };

            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример:
        ///     PUT
        ///     {
        ///        "Login" : "stud123",
        ///        "PasswordHash" : "hash11",
        ///        "RoleId" : "1"
        ///     }
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(PutUserResponse request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Update(userDto);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <remarks></remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}