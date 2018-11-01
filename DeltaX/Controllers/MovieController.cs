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
    [Route("Movie")]
    public class MovieController : Controller
    {
        [HttpGet("v1/GetAllMovieDetails")]

        public IActionResult GetAllMovieDetailsV1()
        {
            try
            {
                return Ok(MongoConnnector.GetAllMoviesV1());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("v1/AddNewMovie")]

        public IActionResult AddNewMovieV1([FromBody] MovieRequestModel requestModel)
        {
            try
            {
                return Ok(MongoConnnector.AddMovieV1(requestModel));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
