using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bwz.Rappi.CounterApp.Controllers
{
    /// <summary>
    /// Data object for the counter.
    /// </summary>
    public class Counter
    {
        public int Current  { get; set; }
    }

    /// <summary>
    /// Provides an API for managing the Counter.
    /// </summary>
    public class CounterController : ControllerBase
    {
        private static int _current = 0;

        // public IActionResult Post() { }

        public IActionResult Get()
        {
            var newCounter = new Counter { Current = _current };
            return Ok(newCounter);
        }
    }
}