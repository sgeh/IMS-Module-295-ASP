using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bwz.Rappi.MemoryApp.Controllers
{
    /// <summary>
    /// Provides an API for retrieving servers memory stats.
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<MemoryMetrics> Get()
        {
            return Ok(GetMetrics());
        }

        private MemoryMetrics GetMetrics()
        {
            var info = new ProcessStartInfo();
            info.FileName = "wmic";
            info.Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value";
            info.RedirectStandardOutput = true;

            var output = "";
            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            var lines = output.Trim().Split("\n");
            var freeMemoryParts = lines[0].Split("=", StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split("=", StringSplitOptions.RemoveEmptyEntries);

            var metrics = new MemoryMetrics();
            metrics.Total = Math.Round(double.Parse(totalMemoryParts[1]) / 1024, 0);
            metrics.Free = Math.Round(double.Parse(freeMemoryParts[1]) / 1024, 0);
            metrics.Used = metrics.Total - metrics.Free;

            return metrics;
        }
    }
}