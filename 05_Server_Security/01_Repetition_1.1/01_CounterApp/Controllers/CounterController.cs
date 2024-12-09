﻿using Bwz.Rappi.Models;
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
    [Route("[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private static int _current = 0;
        private readonly CounterAppContext _context;

        public CounterController(CounterAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("up")]
        public IActionResult Post()
        {
            _current++; // TODO: 1.2) Write current value into database
            // TODO: 1) Add Log Entry ( new Log { Date = DateTime.Now, Current = _current } ) to database
            Log newLog = new Log { Date = DateTime.Now, Current = _current };
            _context.Logs.Add(newLog);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var newCounter = new Counter { Current = _current }; // TODO: 1.2) Return current value from database
            return Ok(newCounter);
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