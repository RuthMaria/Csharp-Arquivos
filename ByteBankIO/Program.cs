using ByteBankIO;
using System.Text;


/*
 uso do partial => Quando compilarmos e executarmos a aplicação, o programa 
entenderá que a classe  Program(ou qualquer outra classe) está em vários 
arquivos e pode ser trabalhada de uma forma única. Ela está separada
apenas por questões de organização.

Desse modo, o partial tornará o código mais simples e mais legível,
pois conseguimos dividir nossa classe para lidar com diferentes métodos em 
diferentes arquivos.
 */

// O uso do StreamReader é a forma mais recomendada para leitura de arquivo
partial class Program
{
    static void Main(string[] args)
    {
        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {linhas.Length} linhas");


        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);
        }
        
        // usamos a classe File quando trabalhamos com arquivos pequenos, pois é mais rápido e fácil
        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

        File.WriteAllText("escrevendoComClasseFile.txt", "Testando File.WriteAllText");

        Console.WriteLine("Aplicação Finalizada ...");

        Console.ReadLine();
    }
}

