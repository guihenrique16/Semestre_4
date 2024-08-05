using Biblioteca;

namespace BibliotecaTest
{
    public class UnitTest1
    {
        [Fact]
        public void Adicionar()
        {
            var titulo = "diario de um banana";

            //var valorEsperado = "diario de um banana";

            var add = Livros.AdicionarLivro(titulo);

            Assert.Equal(add, titulo);
        }
        
    }
}