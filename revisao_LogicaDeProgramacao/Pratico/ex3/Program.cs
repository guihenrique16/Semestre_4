int[] numeros = { 10, 10, 3, 10, 10, 10, 10, 8, 9, 10 };
int somaPares = 0;

for (int i = 0; i < numeros.Length; i++)
{
    if (numeros[i] % 2 == 0)
    {
        somaPares += numeros[i];
    }
}

Console.WriteLine("A soma dos números pares é: " + somaPares);
