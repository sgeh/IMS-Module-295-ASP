using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bwz.Rappi.PizzaApp.Controllers
{
    /// <summary>
    /// Data Object for the Pizza.
    /// </summary>
    public class Pizza
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Ingredients { get; set; }
        public double? Price { get; set; }
    }


    /// <summary>
    /// Provides an API for retrieving Pizza's.
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private List<Pizza> pizzas = new List<Pizza> {
            new Pizza{
                Name = "Stromboli",
                Ingredients = "Tomatensauce, veganer Käse, frische Peperoncini, Oliven, Oregano",
                Description = "Trotz sorgfältiger Auswahl können in den Oliven noch vereinzelt Kerne und Kernstücke enthalten sein.",
                Price = 10
            },
            new Pizza{
                Name = "Margherita",
                Ingredients = "Tomatensauce, veganer Käse, Oregano",
                Description = "",
                Price = 10
            },
            new Pizza{
                Name = "Giardino",
                Ingredients = "Tomatensauce, veganer Käse, Artischocken, frische Champignons, grillierte Peperoni, Oliven, Oregano",
                Description = "Trotz sorgfältiger Auswahl können in den Oliven noch vereinzelt Kerne und Kernstücke enthalten sein.",
                Price = 11
            },
            new Pizza{
                Name = "Prosciutto",
                Ingredients = "Tomaten, Mozzarella (Italien), Hinterschinken (Schweiz), Oregano",
                Description = "Auch glutenfreies Mehl kann Spuren von Gluten enthalten.",
                Price = 12
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pizzas);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(pizzas);
        }
    }
}