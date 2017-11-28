using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackaton.Models.Repositories;
using Hackaton.Models;

namespace Hackaton.Controllers
{
    [Produces("application/json")]
    [Route("api/Droids")]
    public class DroidsController : Controller
    {
        private readonly IDroidRepository droidsRepo;

        public DroidsController(IDroidRepository droidsRepo)
        {
            this.droidsRepo = droidsRepo;
        }

        //////////////////////////////////// 
        ///     GET: api/Droids     ////////
        //////////////////////////////////// 
        [HttpGet]
        public async Task<IActionResult> GetAllDroids()
        {
            var result = await droidsRepo.GetAllDroids();

            if (result == null)
            {
                return NotFound("Geen droids gevonden");
            }

            return Ok(result);
        }

        ///////////////////////////////// 
        ///     GET: api/Droids/5   /////
        /////////////////////////////////
        [HttpGet("{id:int}"), ActionName("GetDroidById/{id}")]
        public async Task<IActionResult> GetDroidById(int id)
        {
            var droid = await droidsRepo.GetDroidById(id);
            if (droid != null)
                return Ok(droid);
            return BadRequest("Geen droid met id: " + id + " gevonden");
        }


        ///////////////////////////////////////////////
        ///     GET: api/Droids/Vanilla           /////
        ///////////////////////////////////////////////
        [HttpGet("{name}"), ActionName("GetDroidByName/{name}")]
        public async Task<IActionResult> GetDroidByName(string name)
        {
            var droid = await droidsRepo.GetDroidByName(name);
            if (droid != null)
                return Ok(droid);
            return BadRequest("Geen droid met naam: " + name + " gevonden");
        }


        ///////////////////////////////// 
        ///     POST: api/Droids    /////
        /// /////////////////////////////
        [HttpPost, ActionName("CreateNewDroid")]
        public async Task<IActionResult> CreateNewDroid([FromBody] Droid newDroid)
        {
            // check if form was filled in correctly
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var droid = await droidsRepo.GetDroidByName(newDroid.Name);

           

            if (droid != null)
            {
                return BadRequest("Droid met deze naam bestaat al");
            }
            else
            {
                bool droidAdded = droidsRepo.CreateNewDroid(newDroid).Result;
                return Ok(droidAdded);
            }
        }
    }
}
