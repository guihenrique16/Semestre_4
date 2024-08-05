using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        [Fact]

        //public void SomarDoisNumeros()
        //{
        //    var n1 = 3.3;
        //    var n2 = 5.2;

        //    var valorEsperado = 8.5;

        //    var soma = Calculo.Somar(n1,n2);

        //    Assert.Equal(soma, valorEsperado);
        //}

        //public void SubtrairDoisNumeros()
        //{
        //    var n1 = 10;
        //    var n2 = 5.2;

        //    var valorEsperado = 4.8;

        //    var sub = Calculo.subtracao(n1, n2);

        //    Assert.Equal(sub, valorEsperado);
        //}
        //public void DividirDoisNumeros()
        //{
        //    var n1 = 12;
        //    var n2 = 6;

        //    var valorEsperado = 2;

        //    var div = Calculo.divisao(n1, n2);

        //    Assert.Equal(div, valorEsperado);
        //}

        public void MultiplicarDoisNumeros()
        {
            var n1 = 10;
            var n2 = 5.2;

            var valorEsperado = 52;

            var mul = Calculo.multiplicacao(n1, n2);

            Assert.Equal(mul, valorEsperado);
        }


    }
}
