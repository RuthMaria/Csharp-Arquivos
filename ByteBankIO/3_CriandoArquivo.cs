using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456, 7895, 4785.40, Gustavo Santos";

            var encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(contaComoString); // seleciona os caracteres e os transforma em bytes conforme o encoding.

            fluxoDeArquivo.Write(bytes, 0, bytes.Length); // escreve no arquivo começando da posição zero até a quantidae de posições que se deseja ocupar

        }

    }
}