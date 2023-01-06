using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// See https://aka.ms/new-console-template for more information

var summary = BenchmarkRunner.Run<RegexvsNoRegex>();
Console.ReadKey();

[ClrJob, CoreJob]
public class RegexvsNoRegex
{
    private string[] strings = { "FMC787", "FMC123", "SUMMARY", "BEBO", "DJN55" };

    [Benchmark]
    public void Regex()
    {
        strings.Select(x => filterNumber(x));
    }

    [Benchmark]
    public void NoRegex()
    {
        strings.Select(s => s.Substring(0, s.TakeWhile(char.IsLetter).Count()));
    }

    public string filterNumber(string input)
    {
        return System.Text.RegularExpressions.Regex.Match(input, @"[A-Z]+").ToString();
    }
}
