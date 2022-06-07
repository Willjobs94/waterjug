using System;

namespace WaterJugChallange
{
    class Program
    {

        static void Main(string[] args)
        {
            var ShouldExit = false;
            PlayGame();

            do
            {
                Console.WriteLine("====================================");
                Console.Write("\nDo you want to play again, type (N or Y)");
                var retryInput = Console.ReadKey();
                var key = retryInput.Key.ToString();

                switch (key)
                {
                    case "N":
                        Console.WriteLine("\nThanks for playing Water Jug Challange!, press any key to exit");
                        ShouldExit = true;
                        Console.ReadKey();
                        break;
                    case "Y":
                        Console.Clear();
                        PlayGame();
                        break;
                    default:
                        Console.WriteLine("\nNot a valid option");
                        break;
                }

            }

            while (!ShouldExit);


        }

        private static void PlayGame()
        {
            Console.WriteLine("======= Welcome to the Water Jug Challange =========");

            var xJugWaterSize = GetValidNumber("Insert Jug Water 1 size: ");
            var yJugWaterSize = GetValidNumber("Insert Jug Water 2 size: ");
            var targetAmount = GetValidNumber("Insert the target amount (Z): ");

            var challange = new WaterJugChallange(xJugWaterSize, yJugWaterSize, targetAmount);

            challange.DisplaySolution();
        }

        private static int GetValidNumber(string message)

        {
            Console.Write(message);
            var stringInput = Console.ReadLine();
            int integerOutput;
            while (!Int32.TryParse(stringInput, out integerOutput))
            {
                Console.WriteLine("Not a valid number, try again.");
                Console.Write(message);
                stringInput = Console.ReadLine();
            }

            return integerOutput;
        }
    }
}

