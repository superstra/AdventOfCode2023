// Author: superstra
// Date: Dec 3rd, 2023

using System.Text.RegularExpressions;

namespace Day3;

public class Day3Puzzle
{

    public static void Main(string[] args)
    {

        bool testing = false;

        string file = testing ? "*.txt" : "*.txt";
        using (StreamReader reader = new StreamReader(@$"C:\Users\SheehanPC\source\repos\superstra\AdventOfCode2023\AdventOfCode2023\Day3\{file}"))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {




            }
        }
    }
}