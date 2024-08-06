using Moq;
using WebApiProducts.Domains;
using WebApiProducts.Interface;
using WebApiProducts.Repositorie;

namespace WebApiProductsTest
{
    public class ProductTest
    {
        [Fact]
        public void Get()
        {
            //Arrange
            //Lista de produtos
            List<Products> productList = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name="Produto1", Price= 55},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto2", Price= 65},
                new Products {IdProduct = Guid.NewGuid(), Name="Produto3", Price= 75}
            };

            //Cria um objeto de simulacao do tipo ProductsRepository
            //var mockRepository = new Mock<ProductsRepository>();
            var mockRepository = new Mock<IProductsRepository>();


            //Configura o metodo "GetAll" para que quando for acionado retorne a lista "mockada"
            mockRepository.Setup(x => x.GetAll()).Returns(productList);

            //Act

            //Executando o metodo "GetAll" e atribui a resposta em result
            var result = mockRepository.Object.GetAll();

            //Assert

            Assert.Equal(3, result.Count);

        }

        [Fact]
        public void Post()
        {

            Products products = new Products 
            { 
                IdProduct = Guid.NewGuid(), 
                Name = "Produto 1", 
                Price = 2 
            };

            List<Products> productsList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Cadastrar(products)).Callback<Products>(x => productsList.Add(products));

            mockRepository.Object.Cadastrar(products);

            Assert.Contains(products, productsList);
        }

        [Fact]
        public void Delete()
        {
            var products = new Products { IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 2 };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Object.Deletar(products.IdProduct);

            var result = mockRepository.Object.GetById(products.IdProduct);

            Assert.Null(result);
        }

        [Fact]
        public void GetById()
        {
            var products = new Products
            {
                IdProduct = Guid.NewGuid(),
                Name = "Produto1",
                Price = 2
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.GetById(products.IdProduct)).Returns(products);
            var result = mockRepository.Object.GetById(products.IdProduct);

            Assert.Equal(products, result);
        }

    }
}