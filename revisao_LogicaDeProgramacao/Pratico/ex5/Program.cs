Console.Write("Digite um texto: ");
string texto = Console.ReadLine()!.ToLower();

int[] contadores = new int[26];

foreach (char c in texto)
{
    if (char.IsLetter(c)) 
    {
        contadores[c - 'a']++;
    }
}

for (int i = 0; i < contadores.Length; i++)
{
    if (contadores[i] > 0)
    {
        Console.WriteLine($"Letra '{(char)('a' + i)}': {contadores[i]} ocorrências");
    }
}