namespace SondaCapta.Domain.Abstractions
{
    public interface ILand
    {
        bool IsInside(int x, int y);
    }
}
