Console.WriteLine($"Digite um numero");

int numeros = int.Parse(Console.ReadLine()!);

for (int n = 1; n <= 10; n++)
{
    Console.WriteLine($"{numeros * n} = {numeros} X {n}");
}
