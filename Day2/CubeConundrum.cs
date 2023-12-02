// Author: superstra
// Date: Dec 2nd, 2023

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Day2;

public class CubeConundrum
{

    public static void Main(string[] args)
    {
        Stack<int> possibleGames = new Stack<int>();
        Stack<int> impossibleGames = new Stack<int>();

        bool testing = false;

        string file = testing ? "SampleGames.txt" : "GameResults.txt";
        using (StreamReader reader = new StreamReader(@$"C:\Users\SheehanPC\source\repos\superstra\AdventOfCode2023\AdventOfCode2023\Day2\{file}"))
        {



            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                

                int gameNume = 0;


                string[] tokens = Regex.Split(line, @"(?<=[:])");
                foreach (string t in tokens)
                {
                    //Console.WriteLine(t);


                    if (t.StartsWith("Game "))
                    {
                        string s = t.Substring(5);
                        s = s.Remove(s.Length - 1);
                        gameNume = int.Parse(s);
                    }
                    else
                    {
                        bool gamePossible = true;




                        string[] gameRounds = Regex.Split(t, @"(?<=[;])");
                        foreach (string round in gameRounds)
                        {
                            int redCube = 12;
                            int greenCube = 13;
                            int blueCube = 14;





                            string[] cubes = Regex.Split(round, @"(?<=[,])");
                            foreach (string cubeColor in cubes)
                            {
                                if (Regex.IsMatch(cubeColor, "(red)"))
                                    redCube -= int.Parse(cubeColor.Split(' ')[1]); // # of red cubes


                                if (Regex.IsMatch(cubeColor, "(green)"))
                                    greenCube -= int.Parse(cubeColor.Split(' ')[1]);// # of green cubes


                                if (Regex.IsMatch(cubeColor, "(blue)"))
                                    blueCube -= int.Parse(cubeColor.Split(' ')[1]);// # of blue cubes
                            }

                            //Console.WriteLine(gameNume + " redCubes: " + redCube);
                            //Console.WriteLine(gameNume + " greenCubes: " + greenCube);
                            //Console.WriteLine(gameNume + " blueCubes: " + blueCube);

                            // End of Round
                            if (redCube < 0 || greenCube < 0 || blueCube < 0) 
                                gamePossible = false;

                        }

                        // End of Game
                        if (gamePossible)
                            possibleGames.Push(gameNume);
                        else
                            impossibleGames.Push(gameNume);

                    }

                }
            }
        }

        Console.WriteLine("games possible: " + possibleGames.Count);
        int sum = 0;
        foreach (int gameNum in possibleGames)
        {
            sum += gameNum;
        }


        // Final Answer
        Console.WriteLine(sum);
    }
}


/*
foreach (string c in split)
    Console.WriteLine(c);
*/