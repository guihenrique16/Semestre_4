using Microsoft.EntityFrameworkCore;
using WebApiProducts.Contexts;
using WebApiProducts.Domains;
using WebApiProducts.Interface;

namespace WebApiProducts.Repositorie
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly ProductContext ctx;
        public ProductsRepository()
        {
            ctx = new ProductContext();
        }
        public void Atualizar(Guid id, Products products)
        {
            try
            {
                Products p = ctx.Products.Find(id)!;
                if (p != null)
                {
                    p.Name = products.Name;
                    p.Price = products.Price;
                    
                }
                ctx.Products.Update(p!);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Products products)
        {
            try
            {
                ctx.Products.Add(products);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Products pBuscado = ctx.Products.Find(id)!;

                if (pBuscado != null)
                {
                    ctx.Products.Remove(pBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Products> GetAll()
        {
            return [.. ctx.Products];
        }

        public Products GetById(Guid id)
        {
            try
            {
                return ctx.Products.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
