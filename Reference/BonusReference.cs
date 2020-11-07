using UnityEngine;


namespace Labyrinth
{
    public sealed class BonusReference
    {
        private HoleBonus _holeBonus;
        
        public HoleBonus HoleBonus
        {
            get
            {
                if (_holeBonus == null)
                {
                    var gameObject = Resources.Load<HoleBonus>("Bonuses/BlackHole");
                    _holeBonus = Object.Instantiate(gameObject);
                }
                return _holeBonus;
            }
        }
    }
}
