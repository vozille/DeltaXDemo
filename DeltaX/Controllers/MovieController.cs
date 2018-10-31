using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaX.Mongo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaX.Controllers
{
    [Route("Movie")]
    public class MovieController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("v1/GetAllMovieDetails")]

        public IActionResult GetAllMovieDetailsV1()
        {
            try
            {
                return Ok(MongoConnnector.GetAllMovies());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
