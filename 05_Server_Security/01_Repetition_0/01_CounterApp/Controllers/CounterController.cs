using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private static int _current = 0;

        [HttpPost]
        [Route("up")]
        public IActionResult Post()
        {
            _current++; // TODO: 1.2) Write current value into database
            // TODO: 1) Add Log Entry ( new Log { Date = DateTime.Now, Current = _current } ) to database
            return Ok();
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var newCounter = new Counter { Current = _current }; // TODO: 1.2) Return highest value from database
            return Ok(newCounter);
        }

        // TODO: 1.1) Return all Log Entries from database
    }
}