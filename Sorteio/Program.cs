using System;

namespace Sorteio
{
    class Program
    {
        private static Random _prizeIndex = new Random();
        private static int[] _doors = { 1, 2, 3 };

        static void Main(string[] args)
        {
            Console.WriteLine("Number of tries: ");
            var tries = Convert.ToUInt64(Console.ReadLine());

            Shuffle(tries);
        }

        private static void Shuffle(ulong numberOfTries)
        {
            ulong correctHits = 0;
            ulong wrongHits = 0;

            int prizeDoor;
            int selectedDoor;
            int discardedDoor;

            for (ulong i = 1; i <= numberOfTries; i++)
            {
                prizeDoor = GetDoorNumber();

                selectedDoor = GetDoorNumber();

                discardedDoor = GetDoorNumber();

                while (discardedDoor == prizeDoor || discardedDoor == selectedDoor)
                {
                    discardedDoor = GetDoorNumber();
                }

                bool correctGuess = selectedDoor == prizeDoor;

                if (correctGuess) correctHits++;
                else wrongHits++;
                
                Console.WriteLine($"Prize Door: {prizeDoor}\nSelected Door: {selectedDoor}\nDiscarded Door: {discardedDoor}\nRight Guess? {correctGuess}\n\n");
            }

            Console.WriteLine($"Right Guesses: {correctHits} / {numberOfTries}\nWrong Guesses: {wrongHits} / {numberOfTries}");
        }

        private static int GetDoorNumber() => _doors[_prizeIndex.Next(0, _doors.Length)];
    }
}
