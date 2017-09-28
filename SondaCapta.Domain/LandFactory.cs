using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    public class LandFactory : ILandFactory
    {
        public ILand CreateRectangularLand(int maxX, int minX, int maxY, int minY)
        {
            return new RectangularLand(maxX, minX, maxY, minY);
        }
    }
}
