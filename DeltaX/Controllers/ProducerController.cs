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
    [Route("Producer")]
    public class ProducerController : Controller
    {
        [HttpGet("v1/ListAllProducers")]

        public IActionResult ListAllProducersV1()
        {
            try
            {
                return new JsonResult(MongoConnnector.GetAllProducers());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPut("v1/AddNewProducer")]

        public IActionResult AddNewProducerV1([FromBody] PersonModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(MongoConnnector.AddNewProducer(request));
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
