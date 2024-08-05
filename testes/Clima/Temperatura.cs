using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima
{
    public static class Temperatura
    {
        public static double ConverterCelsiusParaFahrenheit(double celsius)
        {
            return (celsius * 1.8) + 32;
        }
    }
}
