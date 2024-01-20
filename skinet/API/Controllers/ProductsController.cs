
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context =context; //bech iwali aana acess il db context ..
        }
       
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() // we added async(good practice) + instead of the whole thread waiting for a response from db , it simply taaml another task (another thread to do the job without stoping everything)
        {
            var products= await _context.Products.ToListAsync(); // kona najmy naamluha fard ligne just as get bil id
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id); // it will look using the primary key !
        }

    }
}