using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bwz.Rappi.CounterApp.Controllers
{
    /// <summary>
    /// Data object for the counter.
    /// </summary>
    public class Counter
    {
        public int Current { get; set; }
    }

    /// <summary>
    /// Provides an API for managing the Counter.
    /// </summary>
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private static int _current = 0;

        [HttpPost]
        [Route("up")]
        public IActionResult Post()
        {
            _current++;
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var newCounter = new Counter { Current = _current };
            return Ok(newCounter);
        }
    }
}