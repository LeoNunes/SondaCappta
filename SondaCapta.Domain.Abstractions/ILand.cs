using System;
using System.Collections.Generic;
using System.Text;

namespace SondaCapta.Domain.Abstractions
{
    public interface ILand
    {
        bool IsInside(int x, int y);
    }
}
