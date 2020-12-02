using System;


namespace Labyrinth
{
    public class ListOfFlyingBonuses : IExecute
    {
        private Fly[] _flyingBonuses;

        public ListOfFlyingBonuses() => _flyingBonuses = new Fly[] { };

        public int Count => _flyingBonuses.Length;

        public void AddFlyingBonus(InteractiveObject interactive)
        {
            if (_flyingBonuses == null)
            {
                _flyingBonuses = new[] {new Fly(interactive)};
                return;
            }

            Array.Resize(ref _flyingBonuses, Count + 1);
            _flyingBonuses[Count - 1] = new Fly(interactive);
        }
        
        public void AddManyFlyingBonus(InteractiveObject[] interactives)
        {
            foreach (var interactive in interactives)
            {
                if (_flyingBonuses == null)
                {
                    _flyingBonuses = new[] {new Fly(interactive)};
                    return;
                }

                Array.Resize(ref _flyingBonuses, Count + 1);
                _flyingBonuses[Count - 1] = new Fly(interactive);
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
