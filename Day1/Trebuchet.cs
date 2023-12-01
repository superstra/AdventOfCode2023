// Author: superstra
// Date: Dec 1st, 2023

using System.Text;
using System.Text.RegularExpressions;

namespace Day1;

public class Trebuchet
{



    public static void Main(string[] args)
    {
        try
        {
            //using (StreamReader reader = new StreamReader(@$"C:\Users\SheehanPC\source\repos\superstra\AdventOfCode2023\AdventOfCode2023\Day1\TextFile1.txt"))
            using (StreamReader reader = new StreamReader(@$"C:\Users\SheehanPC\source\repos\superstra\AdventOfCode2023\AdventOfCode2023\Day1\calibrationDocument.txt"))
            {
                StringBuilder sb = new StringBuilder();

                int sum = 0;

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Special case where the only char in the line is a number
                    if (line.Length == 1)
                    {
                        sb.Append(line);
                        sb.Append(line);
                        continue;
                    }

                    int num; 

                    // First num
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (int.TryParse(line[i].ToString(), out num) || IsStringNumAtBegining(line.Substring(i), out num))
                        {
                            sb.Append(num);
                            break;
                        }
                    }
                    // Second Num
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        if (int.TryParse(line[i].ToString(), out num) || IsStringNumAtEnd(line.Substring(0, i+1), out num))
                        {
                            sb.Append(num);
                            break;
                        }
                    }
                    Console.WriteLine($"{line} = {sb}");

                    if (!int.TryParse(sb.ToString(), out int calibrationValue))
                        throw new Exception("sb wasn't a number");

                    sb.Clear();

                    sum += calibrationValue;
                }

                Console.WriteLine($"Sum of all calibration values = {sum}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static bool IsStringNumAtBegining(string s, out int num)
    {
        string zero = "zero";
        string one = "one";
        string two = "two";
        string three = "three";
        string four = "four";
        string five = "five";
        string six = "six";
        string seven = "seven";
        string eight = "eight";
        string nine = "nine";
        
        /*if (Regex.IsMatch(s, $"^{zero}"))
        {
            num = 0;
            return true;
        }
        else*/ if (Regex.IsMatch(s, $"^{one}"))
        {
            num = 1;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{two}"))
        {
            num = 2;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{three}"))
        {
            num = 3;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{four}"))
        {
            num = 4;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{five}"))
        {
            num = 5;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{six}"))
        {
            num = 6;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{seven}"))
        {
            num = 7;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{eight}"))
        {
            num = 8;
            return true;
        }
        else if (Regex.IsMatch(s, $"^{nine}"))
        {
            num = 9;
            return true;
        }

        num = int.MinValue;
        return false;
    }

    private static bool IsStringNumAtEnd(string s, out int num)
    {
        // Patterns
        string zero = "zero";
        string one = "one";
        string two = "two";
        string three = "three";
        string four = "four";
        string five = "five";
        string six = "six";
        string seven = "seven";
        string eight = "eight";
        string nine = "nine";

        /*if (Regex.IsMatch(s, $"{zero}$"))
        {
            num = 0;
            return true;
        }
        else*/ if (Regex.IsMatch(s, $"{one}$"))
        {
            num = 1;
            return true;
        }
        else if (Regex.IsMatch(s, $"{two}$"))
        {
            num = 2;
            return true;
        }
        else if (Regex.IsMatch(s, $"{three}$"))
        {
            num = 3;
            return true;
        }
        else if (Regex.IsMatch(s, $"{four}$"))
        {
            num = 4;
            return true;
        }
        else if (Regex.IsMatch(s, $"{five}$"))
        {
            num = 5;
            return true;
        }
        else if (Regex.IsMatch(s, $"{six}$"))
        {
            num = 6;
            return true;
        }
        else if (Regex.IsMatch(s, $"{seven}$"))
        {
            num = 7;
            return true;
        }
        else if (Regex.IsMatch(s, $"{eight}$"))
        {
            num = 8;
            return true;
        }
        else if (Regex.IsMatch(s, $"{nine}$"))
        {
            num = 9;
            return true;
        }

        num = int.MinValue;
        return false;
    }
}