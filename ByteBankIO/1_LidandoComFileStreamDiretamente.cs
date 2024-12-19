using ByteBankIO;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {

        var enderecoDoArquivo = "contas.txt";

        // using faz a mesma coisa que o bloco try/catch/finally, só que ele é usado para tratar exceções complexas e só funciona com objetos que implementam uma interface IDisposable. O FileStream implementa essa interface. 
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numeroDeBytesLidos = -1;

            var buffer = new byte[1024]; // onde serão armazenados os bytes lidos - trechos temporários do arquivo


            // Devoluções:
            // O número total de bytes lidos do buffer.
            // Isso poderá ser menor que o número de bytes solicitado caso esse número de bytes não estiver disponível no momento,
            // ou zero, se o final do fluxo for atingido
            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                LerBuffer(buffer, numeroDeBytesLidos);
            }

            fluxoDoArquivo.Close(); // informa ao sistema operacional que aquele arquivo está liberado para sofrer modificações
            Console.ReadLine();
        }

    }

    static void LerBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = Encoding.UTF8;
        // var utf8 = new UTF8Encoding(); // também pode ser escrito assim

        var texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);
    }
}

