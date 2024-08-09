using System.ComponentModel;

int contador = 0;
int resultado = 0;

while (contador <= 100)
{
    resultado += contador;
    contador += 2;
}
Console.WriteLine($"{resultado}");

// int pares = 1;
// int soma = 0;

// while (pares <= 100)
// {
//     if (pares% 2 == 0 )
//     {
        
//     }
// }