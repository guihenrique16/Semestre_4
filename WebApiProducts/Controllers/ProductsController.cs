using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProducts.Domains;
using WebApiProducts.Interface;
using WebApiProducts.Repositorie;

namespace WebApiProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsRepository _productsRepository;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(_productsRepository.GetAll());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_productsRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Products products) 
        {
            try
            {
                _productsRepository.Cadastrar(products);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _productsRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Products products)
        {
            try
            {
                _productsRepository.Atualizar(id, products);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
