using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using FoodRecipeApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace FoodRecipeApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _Iusers;


        public UsersController(IUsers IUsers)
        {
            _Iusers = IUsers;
        }
        // GET: api/Users>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await Task.FromResult(_Iusers.GetUsersDetails());
        }
        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> Post(Users user)
        {
            _Iusers.AddUser(user);
            return await Task.FromResult(user);
            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        // GET api/employee/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var employees = await Task.FromResult(_Iusers.GetUserDetail(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }
        /*  // GET api/employee/5
          [HttpGet("[action]/{name}")]
          public async Task<ActionResult<Users>> GetName(string name)
          {
              var employees = await Task.FromResult(_Iusers.GetUserDetailName(name));
              if (employees == null)
              {
                  return NotFound();
              }
              return employees;
          }*/
        [Authorize]
        [HttpGet("[action]/{search}")]
        public async Task<ActionResult<IEnumerable<Users>>> Search(string name)
        {
            try
            {
                var result = await _Iusers.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
