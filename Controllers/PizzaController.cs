using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // get all
        [HttpGet]
        public ActionResult<List<Pizza>> Getall() => PizzaService.GetAll();

        //get by id
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null) return NotFound();

            return pizza;
        }
        //Post
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }
        //Put
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(id != pizza.Id) return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if(existingPizza == null) return NotFound();

            PizzaService.Update(pizza);
            return NoContent();
        }

        // Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza is null) return NotFound();

            PizzaService.Delete(id);
            return NoContent();
        }

    }
}
