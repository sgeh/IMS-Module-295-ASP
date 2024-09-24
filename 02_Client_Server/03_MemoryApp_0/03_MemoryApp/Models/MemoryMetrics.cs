using Microsoft.AspNetCore.Mvc;

namespace Bwz.Rappi.MemoryApp.Controllers
{
    /// <summary>
    /// Data Object for the memory metrics.
    /// </summary>
    public class MemoryMetrics
    {
        public double? Total { get; set; }
        public double? Used { get; set; }
        public double? Free { get; set; }
    }
}