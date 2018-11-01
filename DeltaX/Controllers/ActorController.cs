using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaX.Models;
using DeltaX.Mongo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaX.Controllers
{
    [Route("Actor")]
    public class ActorController : Controller
    {
        [HttpGet("v1/ListAllActors")]

        public IActionResult ListAllActorsV1()
        {
            try
            {
                return new JsonResult(MongoConnnector.GetAllActors());
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPut("v1/AddNewActor")]

        public IActionResult AddNewActorV1([FromBody] PersonModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(MongoConnnector.AddNewActor(request));
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
