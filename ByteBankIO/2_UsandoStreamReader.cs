namespace ByteBankIO;

partial class Program
{
    private static void UsandoStreamReader()
    {
        const string path = "contas.txt";
        using var leitor = new StreamReader(new FileStream(path, FileMode.Open));

        while (!leitor.EndOfStream)
        {
            var linha = leitor.ReadLine();
            var contaCorrente = ConverterStringParaContaCorrente(linha);

            var msg =
                $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
            Console.WriteLine(msg);
        }
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');

        var agenciaComInt = int.Parse(campos[0]);
        var numeroComInt = int.Parse(campos[1]);
        var saldoComDouble = double.Parse(campos[2].Replace('.', ','));
        var titular = new Cliente
        {
            Nome = campos[3]
        };

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;
        return resultado;
    }
}