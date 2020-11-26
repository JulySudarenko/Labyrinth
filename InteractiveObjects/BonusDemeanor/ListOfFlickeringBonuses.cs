using System;


namespace Labyrinth
{
    public class ListOfFlickeringBonuses : IExecute
    {
        private FlickerController[] _flickeringBonuses;

        public ListOfFlickeringBonuses() => _flickeringBonuses = new FlickerController[] { };

        public int Count => _flickeringBonuses.Length;

        public void AddFlickeringBonus(InteractiveObject interactive)
        {
            if (_flickeringBonuses == null)
            {
                _flickeringBonuses = new[] {new FlickerController(interactive)};
                return;
            }

            Array.Resize(ref _flickeringBonuses, Count + 1);
            _flickeringBonuses[Count - 1] = new FlickerController(interactive);
        }

        public void AddManyFlickeringBonus(InteractiveObject[] interactives)
        {
            foreach (var interactive in interactives)
            {
                if (_flickeringBonuses == null)
                {
                    _flickeringBonuses = new[] {new FlickerController(interactive)};
                    return;
                }
                
                Array.Resize(ref _flickeringBonuses, Count + 1);
                _flickeringBonuses[Count - 1] = new FlickerController(interactive);
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
