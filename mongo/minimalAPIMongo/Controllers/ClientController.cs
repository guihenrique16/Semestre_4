using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<User> _user;

        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            try
            {
                var client = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(client);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Client client)
        {
            try
            {
                await _client.InsertOneAsync(client);

                return Ok("cliente cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(string id)
        {
            try
            {
                var client = await _client.Find(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(client);

                //var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                //return filter is not null? Ok(filter): NotFound();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Client c)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    await _client.ReplaceOneAsync(filter, c);

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
                var filter = Builders<Client>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _client.DeleteOneAsync(filter);
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
