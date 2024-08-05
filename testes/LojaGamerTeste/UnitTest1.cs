using AdicionarJogo;

namespace LojaGamerTeste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Jogo jogoB = new Jogo();
            jogoB.Nome = "Produto2";
            jogoB.Quantidade = 1;

            Assert.Equal(ControleDeJogos.AdicionarJogo(jogoB), "cadastrado com sucesso");
        }
    }
}