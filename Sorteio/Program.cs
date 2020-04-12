using System;

namespace Sorteio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of tries: ");
            var tries = Convert.ToUInt64(Console.ReadLine());

            Shuffle(tries);
        }

        private static void Shuffle(ulong numberOfTries)
        {
            int correctHits = 0;
            int wrongHits = 0;

            var prizeIndex = new Random();

            for (ulong i = 1; i <= numberOfTries; i++)
            {
                int[] doors = { 1, 2, 3 };

                int prizeDoor = doors[prizeIndex.Next(0, doors.Length)] ;

                int selectedDoor = doors[prizeIndex.Next(0, doors.Length)];               

                int discardedDoor = doors[prizeIndex.Next(0, doors.Length)];

                while (discardedDoor == prizeDoor || discardedDoor == selectedDoor)
                {
                    discardedDoor = doors[prizeIndex.Next(0, doors.Length)];
                }

                bool correctGuess = selectedDoor == prizeDoor;

                if (correctGuess) correctHits++;
                else wrongHits++;

                Console.WriteLine($"Prize Door: {prizeDoor}\nSelected Door: {selectedDoor}\nDiscarded Door: {discardedDoor}\nRight Guess? {correctGuess}\n\n");
            }

            Console.WriteLine($"Right Guesses: {correctHits} / {numberOfTries}\nWrong Guesses: {wrongHits} / {numberOfTries}");
        }
    }
}
