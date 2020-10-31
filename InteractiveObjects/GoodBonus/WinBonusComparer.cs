using System.Collections.Generic;


namespace Labyrinth
{
    public sealed class WinBonusComparer : IComparer<WinBonus>
    {
        public int Compare(WinBonus x, WinBonus y)
        {
            if (x.Point < y.Point)
            {
                return 1;
            }

            if (x.Point > y.Point)
            {
                return -1;
            }

            return 0;
        }
    }
}
