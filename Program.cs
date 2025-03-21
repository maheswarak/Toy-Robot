using ToyRobotSimulation;
using ToyRobotSolution.Commands;

class Program
{
    static void Main(string[] args)
    {
        
            Console.WriteLine("Enter commands:");
            string inputSource = Console.ReadLine();

            if (System.IO.File.Exists(inputSource))
                ProcessCommands(System.IO.File.ReadAllLines(inputSource));
            else
            {
                ProcessCommands(new string[] { inputSource });
                while (true)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) ProcessCommands(new string[] { input });
                }
            }
    }
    static void ProcessCommands(string[] commands)
    {
        foreach (string command in commands)
        {
            ICommand cmd = CommandFactory.CreateCommand(command);
            if (cmd != null)
            {
                cmd.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command: " + command);
            }
        }
    }
}