// Author: superstra
// Date: Dec 3rd, 2023

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;

namespace Day3;

public class GearRatios
{

    public static void Main(string[] args)
    {
        // Add to this when a number is a part number
        Stack<int> partNums = new Stack<int>();

        //HashSet<int> partNums = new HashSet<int>();



        bool testing = false;

        string file = testing ? "TestSchematic.txt" : "EngineSchematic.txt";
        using (StreamReader reader = new StreamReader(@$"C:\Users\Hannah\source\repos\Aidan\Day3\{file}"))
        {
            string? line1 = reader.ReadLine();
            string? line2 = reader.ReadLine();
            string? line3;



            // First line special case

            Dictionary<int, int> line1_LocNum = LocateNumbers(line1);
            Dictionary<int, int> line2_LocNum = LocateNumbers(line2);
/*
            for (int i = 0; i < line1.Length; i++)
            {
                string token1 = line1[i].ToString();

                if (token1 == ".") continue;


                // Found symbol
                if (Regex.IsMatch(token1, @"\D"))
                {
                    // Check if there are any surrounding numbers and add them to partNums
                    FindSurroundingNums(i, line1, line1_LocNum, partNums);
                    FindSurroundingNums(i, line2, line2_LocNum, partNums);
                }

            }
*/




            while ((line3 = reader.ReadLine()) != null)
            {
                line1_LocNum = LocateNumbers(line1);
                line2_LocNum = LocateNumbers(line2);
                Dictionary<int, int> line3_LocNum = LocateNumbers(line3);

                for (int i = 0; i < line2.Length; i++)
                {
                    string token = line2[i].ToString();


                    if (token == ".") continue;

                    // Found symbol @"\D"
                    if (Regex.IsMatch(token, @"[*]"))
                    {
                        // Check if there are any surrounding numbers and add them to partNums
                        int above = FindSurroundingNums(i, line1, line1_LocNum, partNums);
                        int inLine = FindSurroundingNums(i, line2, line2_LocNum, partNums);
                        int below = FindSurroundingNums(i, line3, line3_LocNum, partNums);

                        if (above > 0 && inLine > 0 && below < 0)
                            partNums.Push(above * inLine);
                        else if (above > 0 && inLine < 0 && below > 0)
                            partNums.Push(above * below);
                        else if (above < 0 && inLine > 0 && below > 0)
                            partNums.Push(inLine * below);

                        // same line numbers already pushed
                    }

                }



                line1 = line2;
                line2 = line3;
            }



            // Last Line Special Case
/*
            for (int i = 0; i < line2.Length; i++)
            {
                string token = line2[i].ToString();

                if (token == ".") continue;


                // Found symbol
                if (Regex.IsMatch(token, @"\D"))
                {
                    // Check if there are any surrounding numbers and add them to partNums
                    FindSurroundingNums(i, line1, line1_LocNum, partNums);
                    FindSurroundingNums(i, line2, line2_LocNum, partNums);
                }

            }*/
        }


        int sum = 0;
        int stackCount = partNums.Count;
        for (int i = 0; i < stackCount; i++)
        {
            int num = partNums.Pop();
            sum += num;
            Console.WriteLine(num);
        }

        // Final Answer
        Console.WriteLine(sum);
    }

    // Part 1 Answer: 527364
    // Part 2 Answer: 79026871

    private static int FindSurroundingNums(int index, string line, Dictionary<int, int> locationNumber, Stack<int> partNums)
    {
        bool left = locationNumber.ContainsKey(index - 1);
        bool middle = locationNumber.ContainsKey(index);
        bool right = locationNumber.ContainsKey(index + 1);

        if (left && middle && right)
        {
            string num = Left(index, line, locationNumber) + locationNumber[index] + Right(index, line, locationNumber);
            return int.Parse(num);
            //partNums.Push(int.Parse(num));
        }
        else if (left && middle)
        {
            string num = Left(index, line, locationNumber) + locationNumber[index];
            return int.Parse(num);
            //partNums.Push(int.Parse(num));
        }
        else if (middle && right)
        {
            string num = locationNumber[index] + Right(index, line, locationNumber);
            return int.Parse(num);
            //partNums.Push(int.Parse(num));
        }
        else if (left && right)
        {
            partNums.Push(int.Parse(Left(index, line, locationNumber)) * int.Parse(Right(index, line, locationNumber)));
            return 0;
            //partNums.Push(int.Parse(Right(index, line, locationNumber)));
        }
        else if (left)
            return int.Parse(Left(index, line, locationNumber));
            //partNums.Push(int.Parse(Left(index, line, locationNumber)));
        else if (middle)
            return locationNumber[index];
            //partNums.Push(locationNumber[index]);
        else if (right)
            return int.Parse(Right(index, line, locationNumber));
            //partNums.Push(int.Parse(Right(index, line, locationNumber)));

        return -1;
    }

    private static String Left(int i, string line, Dictionary<int, int> locationNumber)
    {
        StringBuilder reversedNum = new StringBuilder();

        // Append numbers backwards
        for (int j = i - 1; j >= 0 && Regex.IsMatch(line[j].ToString(), @"\d"); j--)
            reversedNum.Append(locationNumber[j]);


        // flip the number before adding it to the stack
        StringBuilder num = new StringBuilder();
        foreach (char c in reversedNum.ToString())
            num.Insert(0, c);

        return num.ToString();
    }

    private static String Right(int i, string line, Dictionary<int, int> locationNumber)
    {
        StringBuilder num = new StringBuilder();

        // Append numbers backwards
        for (int j = i + 1; j < line.Length && Regex.IsMatch(line[j].ToString(), @"\d"); j++)
            num.Append(locationNumber[j]);

        return num.ToString();
    }



    private static Dictionary<int, int> LocateNumbers(string line)
    {
        Dictionary<int, int> locNum = new Dictionary<int, int>();

        for (int i = 0; i < line.Length; i++)
        {
            string token = line[i].ToString();

            // Found int
            if (Regex.IsMatch(token, @"\d"))
            {
                int digit = int.Parse(token);
                locNum.Add(i, digit);
            }
        }

        return locNum;
    }
}