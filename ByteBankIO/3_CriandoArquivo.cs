using System.Text;
using FileStream = System.IO.FileStream;

partial class Program
{
    private static void CriarArquivo()
    {
        const string path = "contasExportadas.csv";
        using var fluxoDoArquivo = new FileStream(path, FileMode.Create);
        const string contaComoString = "456,78945,4785.40,Gustavo Santos";
        var encoding = Encoding.UTF8;
        var bytes = encoding.GetBytes(contaComoString);

        fluxoDoArquivo.Write(bytes, 0, bytes.Length);
    }

    private static void CriarArquivoComWriter()
    {
        const string caminhoNovoArquivo = "contasExportadas.csv";

        using var escritor = new StreamWriter(new FileStream(caminhoNovoArquivo, FileMode.Create));
        escritor.Write("456,65465,456.0,Pedro");
    }
}