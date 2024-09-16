using System;
using System.Globalization;
using System.IO;
using Entities;

Console.WriteLine("Insira o caminho inteiro do arquivo: ");
string sourceFilePath = Console.ReadLine();

try
{
    string[] lines = File.ReadAllLines(sourceFilePath);

    string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
    string targetFolderPath = sourceFolderPath + @"\out";
    string targetFilePath = targetFolderPath + @"\summary.csv";

    Directory.CreateDirectory(targetFolderPath);

    using (StreamWriter sw = File.AppendText(targetFilePath))
    {
        foreach (string line in lines)
        {

            string[] fields = line.Split(',');
            string nome = fields[0];
            double preco = double.Parse(fields[1], CultureInfo.InvariantCulture);
            int quantidade = int.Parse(fields[2]);

            Produto prod = new Produto(nome, preco, quantidade);

            sw.WriteLine(prod.Nome + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("Ocorreu um erro: " + e.Message);
}