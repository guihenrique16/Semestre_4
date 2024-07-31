using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using minimalAPIMongo.ViewModels;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");

        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                foreach (var order in orders) {

                    if (order.ProductIds != null) 
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductIds);

                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    if (order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }

                return Ok(orders);

            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Cadastrar(OrderViewModel orderViewModel)
        {
            //List<Product> products = [];

            //foreach (var item in orderViewModel.ProductIds!)
            //{
            //    products.Add(_product.Find(x => x.Id == item).FirstOrDefault());
            //}

            try
            {
                Order order = new Order();
                order.Id = orderViewModel.Id;   
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductIds = orderViewModel.ProductIds;
                order.ClientId = orderViewModel.ClientId;
                //order.Products = products;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null) { 
                    return NotFound();
                }

                //order.Client = client;

                await _order.InsertOneAsync(order);

                return StatusCode(201, order);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var orders = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                //foreach (var order in orders)
                //{

                //    if (order.ProductIds != null)
                //    {
                //        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductIds);

                //        order.Products = await _product.Find(filter).ToListAsync();
                //    }

                //    if (order.ClientId != null)
                //    {
                //        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                //    }
                //}
                return Ok(orders);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order o)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, o.Id);

                if (filter != null)
                {
                    await _order.ReplaceOneAsync(filter, o);

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
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _order.DeleteOneAsync(filter);
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
