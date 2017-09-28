using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public interface ILandFactory
    {
        ILand CreateRectangularLand(int maxX, int minX, int maxY, int minY);
    }
}
