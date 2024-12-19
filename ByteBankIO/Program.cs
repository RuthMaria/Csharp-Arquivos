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
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var lerAPriveiralinhaDoAquivo = leitor.ReadLine();

            /*
             se o arquivo for grande podemos ter problema com essa prática de
             carregar todo de uma vez pois pode consumir bastante memória
            */
          //  var lerTodasAsLinhasDoArquivoDeUmaUnicaVez = leitor.ReadToEnd(); 

           // var lerOPrimeiroByteDoArquivo = leitor.Read();

            /*
             EndOfStream é usado para carregar o arquivo de parte em partes.
             Ele reconhece onde é o fim de um fluxo e, aliado ao ReadLine, 
             é capaz de fazer a leitura de um arquivo sem precisar 
             carregá-lo todo de uma vez. Essa estratégia é muito útil para
            arquivos grandes que consomem bastante memória.
             */

            while (!leitor.EndOfStream) { 
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);
                var msg = $"Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }

        }
        Console.ReadLine();

    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375 4644 2483.13 Jonatan
        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

        return resultado;
    }
}

