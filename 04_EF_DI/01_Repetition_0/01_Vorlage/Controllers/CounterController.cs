using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bwz.Rappi.CounterApp.Controllers
{
    /// <summary>
    /// Data object for the counter (JSON representation).
    /// </summary>
    public class Counter
    {
        public int Current  { get; set; }
    }

    /// <summary>
    /// Provides an API for managing the Counter.
    /// </summary>
    // TODO: Add required [Annotation]s
    public class CounterController : ControllerBase
    {
        private static int _current = 0;

        // TODO: Implement Method
        // public IActionResult Post() { }

        // TODO: Add required [Annotation]
        public IActionResult Get()
        {
            var newCounter = new Counter { Current = _current };
            return Ok(newCounter);
        }
    }
}