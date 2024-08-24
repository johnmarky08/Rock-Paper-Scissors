namespace Rock_Paper_Scissors
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome To Rock-Paper-Scissors Game!\n");
            Console.WriteLine("What\'s your name kiddo?");

            string Name = Console.ReadLine() ?? "";
            string ReadName = (Name == "") ? "YOU" : Name.ToUpper();

            Console.WriteLine("Hi {0}! Choose:\n[ R ] Rock\n[ P ] Paper\n[ S ] Scissors", ReadName);

            string PlayerChoice = "";
            bool Choosed = false;

            while (!Choosed)
            {
                string Choice = Console.ReadLine() ?? "";
                Choice = Choice.ToUpper();
                if (Choice == "R")
                {
                    PlayerChoice = "Rock";
                    Choosed = true;
                } else if (Choice == "P")
                {
                    PlayerChoice = "Paper";
                    Choosed = true;
                } else if (Choice == "S")
                {
                    PlayerChoice = "Scissors";
                    Choosed = true;
                } else Console.WriteLine("Please Choose Between R, P, and S!");
            }

            string[] choices = ["Rock", "Paper", "Scissors"];
            string BotChoice = choices[(new Random()).Next(choices.Length)];

            Console.WriteLine("{0}: {1}\nBot: {2}\n\nWant To Play Again? Press \"R\" To Restart!", ReadName, PlayerChoice, BotChoice);

            ConsoleKey Key = Console.ReadKey(true).Key;
            if (Key == ConsoleKey.R)
            {
                Console.Clear();
                Main();
            }
        }
    }
}
