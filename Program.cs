using System.Globalization;

namespace Hangman_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangman Game");
            Console.WriteLine("sport");
         
            char[] play = { '-', '-', '-', '-', '-', '-', '-', '-' };
            List<char> list = new List<char>();
                 string[] hangmanFigures = {
                @"
       +---+
       |   |
           |
           |
           |
           |
     =========",
            @"
       +---+
       |   |
       O   |
           |
           |
           |
     =========",
            @"
       +---+
       |   |
       O   |
       |   |
           |
           |
     =========",
            @"
       +---+
       |   |
       O   |
      /|   |
           |
           |
     =========",
            @"
       +---+
       |   |
       O   |
      /|\  |
           |
           |
     =========",
            @"
       +---+
       |   |
       O   |
      /|\  |
      /    |
           |
     =========",
            @"
       +---+
       |   |
       O   |
      /|\  |
      / \  |
           |
     ========="
        };
            int count = 0;
            char a='a';
            string ans = "football";
            string[] ansArr= ans.Split("");

            DateTime startTime = DateTime.Now;

            // Set the timer interval to 1 second (1000 milliseconds)
            Timer timer = new Timer(TimerCallback, startTime, 0, 1000);
            while (count < 7) 
            {
                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(hangmanFigures[count]);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (char s in play) { 
                Console.Write(s);
                }
                ;
                Console.WriteLine(" ");
                
                try {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine(" ");
                    string input = Console.ReadLine();
                    if (input.Length > 0)
                    {
                        a = input[0];
                    }
                }
                catch (Exception e)
                {
                    
                }

                if (ans.Contains(a) && play[ans.IndexOf(a)] == '-')
            {
                int index=ans.IndexOf(a);
                    play[index] = a;
            }
            else
            {
                    count++;
            }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            // Calculate the elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;
            Console.WriteLine(" ");
            Console.WriteLine($"Total Time: {elapsedTime.Minutes} minutes {elapsedTime.Seconds} seconds");
         
            // Dispose the timer object
            timer.Dispose();
        }

        // Timer callback function
        static void TimerCallback(object state)
        {
            // Get the start time from the state object
            DateTime startTime = (DateTime)state;

            // Calculate the elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;

            // Update the timer display
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Elapsed Time: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");
            Console.WriteLine(" ");
            Console.WriteLine("Enter a character: ");
        }
    }
}