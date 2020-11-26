using System;


namespace Labyrinth
{
    public sealed class WinBonus : InteractiveObject
    {
        public int Point = 5;
        public event Action<int> OnPointChange = delegate(int i) { };

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }
    }
}
