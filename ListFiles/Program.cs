// See https://aka.ms/new-console-template for more information
using System.Globalization;
using Units;

string currentDir = System.IO.Directory.GetCurrentDirectory();
string[] files = Directory.GetFiles(currentDir);
foreach (string file in files)
{
    var info = new System.IO.FileInfo(file);
    SizeInBytes fileSize = info.Length;
    Console.WriteLine("{0} {1}", info.Name, fileSize.ToString(CultureInfo.InvariantCulture));

}
