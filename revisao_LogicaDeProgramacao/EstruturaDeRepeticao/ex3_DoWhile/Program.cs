Random random = new Random();
int numero = random.Next(1,10);

Console.WriteLine($"Digite seu palpite:");
int palpite = int.Parse(Console.ReadLine()!);

int tentativas = 1;

do
{
    Console.WriteLine($"Digite seu palpite:");
    palpite = int.Parse(Console.ReadLine()!);
    tentativas++;
    
} while (numero != palpite);  

Console.WriteLine($"acertou com {tentativas} palpites!");
