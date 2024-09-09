using System;
using System.IO;

string path = @"C:\naka\Teste.txt";

FileStream fs = null;
StreamReader sr = null;

try
{
    sr = File.OpenText(path);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        Console.WriteLine(line);
    }
}
catch (IOException e)
{
    Console.WriteLine("ERROR: " + e.Message);
}
finally
{
    if(sr != null)
    {
        sr.Close();
    }
}