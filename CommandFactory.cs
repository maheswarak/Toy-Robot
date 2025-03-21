using ToyRobotSimulation;
using ToyRobotSolution.Commands;

public class CommandFactory
{
    private static readonly Dictionary<string, Func<ICommand>> commands = new()
        {
            { "MOVE", () => new MoveCommand() },
            { "LEFT", () => new LeftCommand() },
            { "RIGHT", () => new RightCommand() },
            { "REPORT", () => new ReportCommand() }
        };

    public static ICommand CreateCommand(string input)
    {
        string[] parts = input.Split(' ');
        string cmd = parts[0].ToUpper();
        if (cmd == "PLACE" && parts.Length == 2)
        {
            string[] args = parts[1].Split(',');
            if (args.Length == 3 && int.TryParse(args[0], out int x) && int.TryParse(args[1], out int y) && Enum.TryParse(args[2].ToUpper(), out Direction dir))
                return new PlaceCommand(x, y, dir);
        }
        return commands.ContainsKey(cmd) ? commands[cmd]() : null;
    }
}
