using System;
using Object = UnityEngine.Object;


namespace Labyrinth
{
    public class ListOfColoringBonuses : IExecute
    {
        private ColorController[] _coloringBonuses;

        //public ListOfColoringBonuses() => _coloringBonuses = new ColorController[] { };
        public ListOfColoringBonuses()
        {
            var bonses = Object.FindObjectsOfType<InteractiveObject>();
            foreach (var b in bonses)
            {
                if(b is ColorBonus colorBonus)
                {
                    AddColoringBonus(colorBonus);
                }
            }
        }
        
        public int Count => _coloringBonuses.Length;

        public void AddColoringBonus(InteractiveObject interactive)
        {
            if (_coloringBonuses == null)
            {
                _coloringBonuses = new[] {new ColorController(interactive)};
                return;
            }

            Array.Resize(ref _coloringBonuses, Count + 1);
            _coloringBonuses[Count - 1] = new ColorController(interactive);
        }
        
        public void AddManyColoringBonus(InteractiveObject[] interactives)
        {
            foreach (var interactive in interactives)
            {
                if (_coloringBonuses == null)
                {
                    _coloringBonuses = new[] {new ColorController(interactive)};
                    return;
                }

                Array.Resize(ref _coloringBonuses, Count + 1);
                _coloringBonuses[Count - 1] = new ColorController(interactive);
            }
        }

        public void Execute()
        {
            foreach (var coloringBonuses in _coloringBonuses)
            {
                coloringBonuses.ChangeColor();
            }
        }
    }
}
