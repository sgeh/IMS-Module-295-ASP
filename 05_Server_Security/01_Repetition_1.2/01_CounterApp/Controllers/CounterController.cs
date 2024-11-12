using Bwz.Rappi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bwz.Rappi.CounterApp.Controllers
{
    /// <summary>
    /// Provides an API for managing the Counter.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly CounterAppContext _context;

        public CounterController(CounterAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("up")]
        public IActionResult Post()
        {
            var counter = _context.Counter.First();
            counter.Current++;

            // TODO: 1) Add Log Entry ( new Log { Date = DateTime.Now, Current = _current } ) to database
            Log newLog = new Log { Date = DateTime.Now, Current = counter.Current };
            _context.Logs.Add(newLog);

            // TODO: 1.2) Write current value into database            
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult Get()
        {
            // TODO: 1.2) Return current value from database
            return Ok(_context.Counter.First());
        }

        // TODO: 1.1) Return all Log Entries from database
        [HttpGet]
        [Route("logs")]
        public IActionResult GetAll()
        {
            return Ok(_context.Logs);
        }
    }
}