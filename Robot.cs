namespace ToyRobotSimulation
{
    public enum Direction { NORTH, EAST, SOUTH, WEST }

    public class Robot
    {
        private static readonly Lazy<Robot> instance = new(() => new Robot());
        private int x, y;
        private Direction direction;
        private bool isPlaced = false;
        private const int tableSize = 5;

        private Robot() { }

        public static Robot Instance => instance.Value;

        public void Place(int newX, int newY, Direction newDirection)
        {
            if (IsValidPosition(newX, newY))
            {
                x = newX;
                y = newY;
                direction = newDirection;
                isPlaced = true;
            }
        }

        public void Move()
        {
            if (!isPlaced) return;
            int newX = x, newY = y;
            switch (direction)
            {
                case Direction.NORTH: newY++; break;
                case Direction.EAST: newX++; break;
                case Direction.SOUTH: newY--; break;
                case Direction.WEST: newX--; break;
            }
            if (IsValidPosition(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        public void Left() { if (isPlaced) direction = (Direction)(((int)direction + 3) % 4); }
        public void Right() { if (isPlaced) direction = (Direction)(((int)direction + 1) % 4); }
        public void Report() { if (isPlaced) Console.WriteLine($"Output Result: {x},{y},{direction}"); }

        private bool IsValidPosition(int x, int y) => x >= 0 && x < tableSize && y >= 0 && y < tableSize;
    }

}
