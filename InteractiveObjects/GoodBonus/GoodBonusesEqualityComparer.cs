using System.Collections.Generic;


namespace Labyrinth
{
    public sealed class GoodBonusesEqualityComparer : IEqualityComparer<WinBonus>
    {
        public bool Equals(WinBonus x, WinBonus y) => x.Point == y.Point;

        public int GetHashCode(WinBonus obj) => obj.Point.GetHashCode();
    }
}
