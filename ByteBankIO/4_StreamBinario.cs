partial class Program
{

    /* 
      O StreamWriter sempre usa a representação de texto para qualquer valor:
      booleanos, inteiros ou qualquer outro tipo. Se não é necessário 
      mantermos um arquivo com texto legível, podemos criar este documento
      escrevendo os valores em formato binário.    
      A leitura binária é utilizada para diminuir o tamanho do arquivo, 
      os textos são codificados em binário ao invés de serem guardados puros
    */
    static void EscritaBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);       //número da Agência
            escritor.Write(546544);   //número da conta
            escritor.Write(4000.50); //Saldo
            escritor.Write("Gustavo Braga");
        }
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
        }
    }

}
