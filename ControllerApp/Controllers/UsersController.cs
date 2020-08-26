
using ControllerApp.Domains.Users;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    [ResponseCache(Duration = 5)]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UsersController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userInterface.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userInterface.GetUser(id);
            if(user == null)
            {
                return NotFound($"User with Id {id} was not found contact Stanley");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody]TempUser tempUser)
        {
            if(tempUser == null)
            {
                return BadRequest("User is null are you crazy");
            }
            var u = _userInterface.AddUser(tempUser);
            return Ok(u);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]TempUser tempUser)
        {
            if (tempUser == null)
            {
                return BadRequest("User is null");
            }
            var user = _userInterface.GetUser(id);
            if(user == null)
            {
                return NotFound("User was not found contact Stanley");
            }
            _userInterface.UpdateUser(user,tempUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {           
            var u = _userInterface.GetUser(id);
            if (u == null)
            {
                return NotFound("User was not found contact Stanley");
            }
            _userInterface.DeleteUser(u);
            return NoContent();
        }

        [HttpGet("types")]
        public IActionResult GetUserTypes()
        {
            var userTypes = _userInterface.GetUserTypes();
            return Ok(userTypes);
        }
    }
}