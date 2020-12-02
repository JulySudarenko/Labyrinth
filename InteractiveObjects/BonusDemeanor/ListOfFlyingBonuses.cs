using System;


namespace Labyrinth
{
    public class ListOfFlyingBonuses : IExecute
    {
        private FlyController[] _flyingBonuses;

        public ListOfFlyingBonuses() => _flyingBonuses = new FlyController[] { };

        public int Count => _flyingBonuses.Length;

        public void AddFlyingBonus(InteractiveObject interactive)
        {
            if (_flyingBonuses == null)
            {
                _flyingBonuses = new[] {new FlyController(interactive)};
                return;
            }

            Array.Resize(ref _flyingBonuses, Count + 1);
            _flyingBonuses[Count - 1] = new FlyController(interactive);
        }
        
        public void AddManyFlyingBonus(InteractiveObject[] interactives)
        {
            foreach (var interactive in interactives)
            {
                AddFlyingBonus(interactive);
            }
        }

        public void Execute()
        {
            foreach (var flyBonus in _flyingBonuses)
            {
                flyBonus.MakeItFly();
            }
        }
    }
}
