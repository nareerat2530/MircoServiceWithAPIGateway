using MicroService_User.Interfaces;
using MicroService_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MicroService_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMapper _userMapper;

        public UsersController(IUnitOfWork unitOfWork , IUserMapper userMapper)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.UserRepository.GetAllUsersAsync();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var addUser = _userMapper.Map(user);
            if (!await _unitOfWork.UserRepository.AddNewUser(addUser)) return StatusCode(500, "Something went wrong!");
            if (!await _unitOfWork.Complete()) return StatusCode(500, "Something went wrong!");
            return StatusCode(201);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (result == null) return NotFound($"Could not find  movie with id: {id} in the system");
            var _movie = _userMapper.Map(result);
            return Ok(_movie);
        }

        [HttpPut("update/{id}")]
        public  async Task<IActionResult> UpdateUser(int id, [FromBody] PutViewModel user)
        {
            var toUpdate = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (toUpdate == null) return NotFound($"Could not find any user with {id}");



            toUpdate = _userMapper.Map(user, toUpdate);
            if (!_unitOfWork.UserRepository.UpdatedUser(toUpdate)) return StatusCode(500, "Something went wrong");
            if (await _unitOfWork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var toDelete = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (toDelete == null) return NotFound($"Could not find any user with {id}");
            
            if (!_unitOfWork.UserRepository.DeleteUser(toDelete)) return StatusCode(500, "Something went wrong");
            if (await _unitOfWork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }
    }
}
