using Microsoft.AspNetCore.Mvc;
using Passport.Models;
using Passport.Mongo;

namespace Passport.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TurnController : ControllerBase
    {
        DBContext dbContext = new DBContext();

        [HttpGet]
        public async Task<IActionResult> GetLastTurn()
        {
            return Ok(dbContext.get());
        }

        [HttpPost]
        [Route("set_turn")]
        public async Task<IActionResult> SetNewTurn([FromBody] Person person)
        {
            person.CreatedDate = DateTime.Now;
            dbContext.insert(person);
            return Ok();
        }

        [HttpPost]
        [Route("confirm")]
        public async Task<IActionResult> ConfirmLastTurn([FromBody] PersonFilterId filter)
        {
            String d = dbContext.confirm(filter.Id);
            return Ok(d);
        }


    }
}