using SondaCapta.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain
{
    internal class RectangularLand : ILand
    {
        public RectangularLand(int maxX, int minX, int maxY, int minY)
        {
            if (minX > maxX || minY > maxY)
                throw new ArgumentException("Min value can't be greater than max value");

            MaxX = maxX;
            MinX = minX;
            MaxY = maxY;
            MinY = minY;
        }

        public int MaxX { get; private set; }
        public int MinX { get; private set; }
        public int MaxY { get; private set; }
        public int MinY { get; private set; }

        public bool IsInside(int x, int y)
        {
            return (x <= MaxX && x >= MinX && y <= MaxY && y >= MinY);
        }
    }
}
