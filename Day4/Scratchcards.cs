// Author: superstra
// Date: Dec 4th, 2023

using System.Text.RegularExpressions;

namespace Day4;

public class Scratchcards
{

    public static void Main(string[] args)
    {

        Dictionary<int, int> cardPoints = new();
        Dictionary<int, int> cardCopies = new();
        Dictionary<int, int> cardCounts = new();

        int index = 0;



        bool testing = false;

        string file = testing ? "testCards.txt" : "scratchcards.txt";
        using (StreamReader reader = new StreamReader(@$"C:\Users\SheehanPC\source\repos\superstra\AdventOfCode2023\AdventOfCode2023\Day4\{file}"))
        {
            string? scratchcard;
            while ((scratchcard = reader.ReadLine()) != null)
            {
                cardPoints.Add(++index, CalculateScratchcard(scratchcard, cardCopies));
            }
        }

        
        CalculateCards(cardPoints, cardCopies, cardCounts);


        // If you want to find the total points for part 2 :P
        // Reading comprehension strikes again
        //int totalPoints = 0;

        //for (int cardNumber = 1; cardNumber <= cardCounts.Count; cardNumber++)
        //{
        //    totalPoints += cardCounts[cardNumber] * cardPoints[cardNumber];
        //}



        int totalScratchcards = 0;

        foreach (int cardNumber in cardCounts.Keys)
        {
            totalScratchcards += cardCounts[cardNumber];
        }

        // Final Answer
        Console.WriteLine(totalScratchcards);
    }

    // Part 2 answer: 5704953 total scratchcards


    /// <summary>
    /// Part 1
    /// </summary>
    /// <param name="line"></param>
    /// <returns> The points won by the scratchcard </returns>
    private static int CalculateScratchcard(string scratchcard, Dictionary<int, int> cardCopies)
    {
        HashSet<int> winningNums = new HashSet<int>();
        HashSet<int> myNums = new HashSet<int>();


        string[] cardData = Regex.Split(scratchcard, @"(?<=[:|])");



        string winNums = cardData[1].Trim();
        string[] tokens = Regex.Split(winNums, @"(?<=[ ])");
        foreach (string token in tokens)
        {
            if (token == " ") continue;

            if (Regex.IsMatch(token, @"(\d)"))
                winningNums.Add(int.Parse(token));
        }


        string myNumbers = cardData[2].Trim();
        tokens = Regex.Split(myNumbers, @"(?<=[ ])");
        foreach (string token in tokens)
        {
            if (token == " ") continue;

            if (Regex.IsMatch(token, @"\d"))
                myNums.Add(int.Parse(token));
        }


        // Check all of myNums to see if they win
        int winCounter = 0;
        foreach (int num in myNums)
        {
            if (winningNums.Contains(num))
                winCounter++;
        }


        string cardNumber = cardData[0];
        cardNumber = cardNumber.Remove(0, 4).Trim();
        cardNumber = cardNumber.Remove(cardNumber.Length - 1);
        cardCopies.Add(int.Parse(cardNumber), winCounter);

        // Points
        return (int)Math.Pow(2, winCounter - 1);
    }





    private static void CalculateCards(Dictionary<int, int> cardPoints, Dictionary<int, int> cardCopies, Dictionary<int, int> cardCounts)
    {
        for (int cardNumber = 1; cardNumber <= cardCopies.Count; cardNumber++)
            cardCounts.Add(cardNumber, 1);



        foreach (int cardNumber in cardCopies.Keys) 
        {
            // Add +1 copies to cardCounts for each card
            //for (int nextCardNumber = cardNumber + 1; nextCardNumber <= cardCopies[cardNumber] + cardNumber; ++nextCardNumber)
            //{
            //    cardCounts[nextCardNumber]++;
            //}
            CalcCardsRecursive(cardNumber, cardPoints, cardCopies, cardCounts);
        }

        
    }


    private static void CalcCardsRecursive(int cardNumber, Dictionary<int, int> cardPoints, Dictionary<int, int> cardCopies, Dictionary<int, int> cardCounts)
    {
        // Add +1 copies to cardCounts for each card
        //if (cardCopies[cardNumber] < 1)
        //{
        //    cardCounts[cardNumber]++;
        //}


        for (int nextCardNumber = cardNumber + 1; nextCardNumber <= cardCopies[cardNumber] + cardNumber; ++nextCardNumber)
        {
            cardCounts[nextCardNumber]++;
            CalcCardsRecursive(nextCardNumber, cardPoints, cardCopies, cardCounts);
        }

    }

}