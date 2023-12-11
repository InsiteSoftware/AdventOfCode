
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

var lines = File.ReadLines("../../../input.txt");
int total = 0;

foreach (var line in lines)
{
    var first = line.FirstNumberOrDefault();
    var last = line.LastNumberOrDefault();

    total += first * 10;
    total += last;
}

Console.WriteLine($"The code is: {total}");







