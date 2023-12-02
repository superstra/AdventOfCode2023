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
        // ---- Part One ----
        Stack<int> possibleGames = new Stack<int>();
        Stack<int> impossibleGames = new Stack<int>();


        // ---- Part Two ----
        Stack<int> products = new Stack<int>();



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
                    // Get game number
                    if (t.StartsWith("Game "))
                    {
                        string s = t.Substring(5);
                        s = s.Remove(s.Length - 1);
                        gameNume = int.Parse(s);
                    }
                    // All rounds in game
                    else
                    {
                        // ---- Part One ----
                        /*
                        bool gamePossible = true;
                        */


                        int redCube = 0;
                        int greenCube = 0;
                        int blueCube = 0;

                        // ROUNDS
                        #region Rounds
                        string[] gameRounds = Regex.Split(t, @"(?<=[;])");
                        foreach (string round in gameRounds)
                        {
                            // ---- Part One ----
                            /*
                            redCube = 12;
                            greenCube = 13;
                            blueCube = 14;
                            */



                            string[] cubes = Regex.Split(round, @"(?<=[,])");
                            foreach (string cubeColor in cubes)
                            {
                                int numOfCubes = int.Parse(cubeColor.Split(' ')[1]);

                                // ---- Part One ----
                                /*
                                if (Regex.IsMatch(cubeColor, "(red)"))
                                    redCube -= int.Parse(cubeColor.Split(' ')[1]); // # of red cubes


                                if (Regex.IsMatch(cubeColor, "(green)"))
                                    greenCube -= int.Parse(cubeColor.Split(' ')[1]);// # of green cubes


                                if (Regex.IsMatch(cubeColor, "(blue)"))
                                    blueCube -= int.Parse(cubeColor.Split(' ')[1]);// # of blue cubes
                                */

                                if (Regex.IsMatch(cubeColor, "(red)"))
                                    if (numOfCubes > redCube)
                                        redCube = numOfCubes;

                                if (Regex.IsMatch(cubeColor, "(green)"))
                                    if (numOfCubes > greenCube)
                                        greenCube = numOfCubes;

                                if (Regex.IsMatch(cubeColor, "(blue)"))
                                    if (numOfCubes > blueCube)
                                        blueCube = numOfCubes;
                            }

                            //Console.WriteLine(gameNume + " redCubes: " + redCube);
                            //Console.WriteLine(gameNume + " greenCubes: " + greenCube);
                            //Console.WriteLine(gameNume + " blueCubes: " + blueCube);

                            // End of Round

                            /*
                            if (redCube < 0 || greenCube < 0 || blueCube < 0)
                                gamePossible = false;
                            */

                        }
                        #endregion

                        // End of Game

                        // ---- Part One ----
                        /*
                        if (gamePossible)
                            possibleGames.Push(gameNume);
                        else
                            impossibleGames.Push(gameNume);
                        */


                        // ---- Part Two ----
                        products.Push(redCube * greenCube * blueCube);
                    }

                }
            }
        }
        // ---- Part One ----

        //Console.WriteLine("games possible: " + possibleGames.Count);
/*
        int sum = 0;
        foreach (int gameNum in possibleGames)
        {
            sum += gameNum;
        }
*/

        // ---- Part Two ----

        int sum = 0;
        foreach (int product in products)
        {
            sum += product;
        }



        // Final Answer
        Console.WriteLine(sum);

        // Part 1: 2439
        // Part 2: 63711
    }
}