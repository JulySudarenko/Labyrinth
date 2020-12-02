using System;


namespace Labyrinth
{
    public class ListOfRotatingBonuses : IExecute
    {
        private Rotation[] _rotatingBonuses;

        public ListOfRotatingBonuses() => _rotatingBonuses = new Rotation[] { };

        public int Count => _rotatingBonuses.Length;

        public void AddRotatingBonus(InteractiveObject interactive)
        {
            if (_rotatingBonuses == null)
            {
                _rotatingBonuses = new[] {new Rotation(interactive)};
                return;
            }

            Array.Resize(ref _rotatingBonuses, Count + 1);
            _rotatingBonuses[Count - 1] = new Rotation(interactive);
        }

        public void Execute()
        {
            foreach (var rotatingBonus in _rotatingBonuses)
            {
                rotatingBonus.Rotate();
            }
        }
    }
}
