namespace Rock_Paper_Scissors
{
    internal class Program
    {
        public static int PlayerWon = 0;
        public static int BotWon = 0;
        static void Main()
        {
            Console.WriteLine("Welcome To Rock-Paper-Scissors Game!\n");
            Console.WriteLine("What\'s your name kiddo?");

            string Name = Console.ReadLine() ?? "";
            string ReadName = (Name == "") ? "You" : Name;

            RPS(ReadName);
        }
        static void RPS(string ReadName)
        {
            Console.WriteLine("{0}! Choose Between:\n[ R ] Rock\n[ P ] Paper\n[ S ] Scissors", (ReadName == "You") ? "Hello" : String.Format("Hi {0}", ReadName));

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
                }
                else if (Choice == "P")
                {
                    PlayerChoice = "Paper";
                    Choosed = true;
                }
                else if (Choice == "S")
                {
                    PlayerChoice = "Scissors";
                    Choosed = true;
                }
                else Console.WriteLine("Please Choose Between R, P, and S!");
            }

            string[] choices = ["Rock", "Paper", "Scissors"];
            string BotChoice = choices[(new Random()).Next(choices.Length)];
            int Won = Winner(PlayerChoice, BotChoice);
            string Win = (Won == 0) ? "It's A Tie" : (Won == 1) ? String.Format("{0} Won", ReadName) : (Won == 2) ? "Bot Won" : "Error";

            if (Won == 1) ++PlayerWon;
            if (Won == 2) ++BotWon;

            Console.WriteLine("{0}: {1}\nBot: {2}\n\n{3}!\n\nWant To Play Again?\nPress \"G\" To Play Again\nPress \"R\" To Restart!", ReadName, PlayerChoice, BotChoice, Win);

            ConsoleKey Key = Console.ReadKey(true).Key;
            if (Key == ConsoleKey.R)
            {
                Console.Clear();
                PlayerWon = 0;
                BotWon = 0;
                Main();
            }
            if (Key == ConsoleKey.G)
            {
                Console.Clear();
                Console.WriteLine("YOUR SCORE: {0}\nBOT SCORE: {1}\n", Convert.ToString(PlayerWon), Convert.ToString(BotWon));
                RPS(ReadName);
            }
        }
        static int Winner(string PlayerChoice, string BotChoice)
        {
            // 0 = Tie
            // 1 = Player Win
            // 2 = Bot Win
            if (PlayerChoice == BotChoice) return 0;
            return ((PlayerChoice == "Rock") && (BotChoice == "Paper")) ? 2
                : ((PlayerChoice == "Rock") && (BotChoice == "Scissors")) ? 1
                : ((PlayerChoice == "Paper") && (BotChoice == "Rock")) ? 1
                : ((PlayerChoice == "Paper") && (BotChoice == "Scissors")) ? 2
                : ((PlayerChoice == "Scissors") && (BotChoice == "Rock")) ? 2
                : ((PlayerChoice == "Scissors") && (BotChoice == "Paper")) ? 1
                : 0;
        }
    }
}
