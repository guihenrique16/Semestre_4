using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("users");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            try
            {
                var user = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(user);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(User user)
        {
            try
            {
                await _user.InsertOneAsync(user);

                return Ok("Ususrio cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            try
            {
                var user = await _user.Find(x => x.Id == id).FirstOrDefaultAsync();
                return Ok(user);

                //var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
                //return filter is not null? Ok(filter): NotFound();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(User u)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, u.Id);

                if (filter != null)
                {
                    await _user.ReplaceOneAsync(filter, u);

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
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _user.DeleteOneAsync(filter);
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
