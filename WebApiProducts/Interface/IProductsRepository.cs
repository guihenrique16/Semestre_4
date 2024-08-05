using WebApiProducts.Domains;

namespace WebApiProducts.Interface
{
    public interface IProductsRepository
    {
        void Cadastrar(Products products);

        void Deletar(Guid id);

        void Atualizar(Guid id, Products products);

        List<Products> GetAll();

        Products GetById(Guid id);
    }
}
