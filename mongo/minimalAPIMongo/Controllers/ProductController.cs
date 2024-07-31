using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var product = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(product);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);

                return Ok("Produto cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            try
            {
                var product = await _product.Find(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(product);

                //var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                //return filter is not null? Ok(filter): NotFound();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product p)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, p.Id);

                if (filter != null)
                {
                    await _product.ReplaceOneAsync(filter, p);

                    return Ok();

                }

                return NotFound();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _product.DeleteOneAsync(filter);
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
