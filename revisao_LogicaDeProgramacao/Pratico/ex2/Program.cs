
string[] nomes = new string[5];

Console.WriteLine($"Por favor, digite 5 nomes:");
for (int i = 0; i < nomes.Length; i++)
{
    Console.Write($"Digite o nome {i + 1}: ");
    nomes[i] = Console.ReadLine()!;
}

Array.Sort(nomes);

Console.WriteLine($"Nomes cadastrados em ordem alfabética:");
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}
