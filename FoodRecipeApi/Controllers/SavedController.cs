using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedController : ControllerBase
    {
        private readonly ISaved _ISaved;

        public SavedController(ISaved ISaved)
        {
            _ISaved = ISaved;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saved>>> Get()
        {
            return await Task.FromResult(_ISaved.GetSavedDetails());
        }
       
        [HttpPost]
        public async Task<ActionResult<Saved>> Post(Saved saved)
        {
            _ISaved.AddSaved(saved);
            return await Task.FromResult(saved);
        }
        [Authorize]
        [HttpGet("[action]/{search}")]
        public async Task<ActionResult<IEnumerable<Saved>>> Search(int id)
        {
            try
            {
                var result = await _ISaved.Searchbyid(id);

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Saved>> GetSavedDetail(int id)
        {
            var saved = await Task.FromResult(_ISaved.GetSavedDetail(id));
            if (saved == null)
            {
                return NotFound();
            }
            return saved;
        }
        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Saved>> Delete(int id)
        {
            var saved = _ISaved.DeleteSaved(id);
            return await Task.FromResult(saved);
        }
    }
}
