Console.WriteLine($"Digite um numero:");
int numero =  int.Parse(Console.ReadLine()!);

if (numero % 2 == 0)
{
    Console.WriteLine($"{numero} é par.");
}
else
{
    Console.WriteLine($"{numero} é ímpar.");
}