namespace SondaCapta.Domain.Abstractions
{
    public interface ILandFactory
    {
        ILand CreateRectangularLand(int maxX, int minX, int maxY, int minY);
    }
}
