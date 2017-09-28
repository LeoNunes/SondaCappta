namespace SondaCapta.Common
{
    public struct Position
    {
        public Position(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public int X { get; }
        public int Y { get; }
        public Orientation Orientation { get; }
    }
}
