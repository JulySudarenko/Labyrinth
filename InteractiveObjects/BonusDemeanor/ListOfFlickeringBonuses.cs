using System;


namespace Labyrinth
{
    public class ListOfFlickeringBonuses : IExecute
    {
        private Flicker[] _flickeringBonuses;

        public ListOfFlickeringBonuses() => _flickeringBonuses = new Flicker[] { };

        public int Count => _flickeringBonuses.Length;

        public void AddFlickeringBonus(InteractiveObject interactive)
        {
            if (_flickeringBonuses == null)
            {
                _flickeringBonuses = new[] {new Flicker(interactive)};
                return;
            }

            Array.Resize(ref _flickeringBonuses, Count + 1);
            _flickeringBonuses[Count - 1] = new Flicker(interactive);
        }

        public void AddManyFlickeringBonus(InteractiveObject[] interactives)
        {
            foreach (var interactive in interactives)
            {
                if (_flickeringBonuses == null)
                {
                    _flickeringBonuses = new[] {new Flicker(interactive)};
                    return;
                }
                
                Array.Resize(ref _flickeringBonuses, Count + 1);
                _flickeringBonuses[Count - 1] = new Flicker(interactive);
            }
        }
        
        public void Execute()
        {
            foreach (var flickeringBonus in _flickeringBonuses)
            {
                flickeringBonus.MakeItFlicker();
            }
        }
    }
}
