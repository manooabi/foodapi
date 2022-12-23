using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoods _Ifoods;
        public FoodsController(IFoods Ifoods)
        {
            _Ifoods = Ifoods;
        }
        // GET: api/Users>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foods>>> Get()
        {
            return await Task.FromResult(_Ifoods.GetFoodDetails());
        }
        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<Foods>> Post(Foods food)
        {
            _Ifoods.AddFood(food);
            return await Task.FromResult(food);
        }
        [HttpGet("[action]/{search}")]
        public async Task<ActionResult<IEnumerable<Foods>>> Search(string name)
        {
            try
            {
                var result = await _Ifoods.SearchbyCateogory(name);

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
        [HttpGet("[action]/{search}")]
        public async Task<ActionResult<IEnumerable<Foods>>> SearchType(string name)
        {
            try
            {
                var result = await _Ifoods.SearchbyType(name);

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
        // GET api/employee/5
        [HttpGet("{id}")]
         public async Task<ActionResult<Foods>> Get(int id)
         {
             var employees = await Task.FromResult(_Ifoods.GetFoodDetail(id));
             if (employees == null)
             {
                 return NotFound();
             }
             return employees;
         }
    }
}
