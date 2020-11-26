using System;


namespace Labyrinth
{
    public class ListOfRotatingBonuses : IExecute
    {
        private RotationController[] _rotatingBonuses;

        public ListOfRotatingBonuses() => _rotatingBonuses = new RotationController[] { };

        public int Count => _rotatingBonuses.Length;

        public void AddRotatingBonus(InteractiveObject interactive)
        {
            if (_rotatingBonuses == null)
            {
                _rotatingBonuses = new[] {new RotationController(interactive)};
                return;
            }

            Array.Resize(ref _rotatingBonuses, Count + 1);
            _rotatingBonuses[Count - 1] = new RotationController(interactive);
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
