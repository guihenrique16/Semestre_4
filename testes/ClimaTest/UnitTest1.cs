using Clima;

namespace ClimaTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var n1 = 10;
            
            var valorEsperado = 50;

            var mul = Temperatura.ConverterCelsiusParaFahrenheit(n1);

            Assert.Equal(mul, valorEsperado);
        }
    }
}