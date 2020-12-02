using UnityEngine;


namespace Labyrinth
{
    public sealed class BonusReference
    {
        private HoleBonus _holeBonus;
        private BadSpeedBonus _badSpeedBonus;
        private HighSpeedBonus _highSpeedBonus;
        private WinBonus[] _winBonuses;

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

        public BadSpeedBonus BadSpeedBonus
        {
            get
            {
                if (_badSpeedBonus == null)
                {
                    var gameObject = Resources.Load<BadSpeedBonus>("Bonuses/BadSpeedBonus");
                    _badSpeedBonus = Object.Instantiate(gameObject);
                }

                return _badSpeedBonus;
            }
        }

        public HighSpeedBonus HighSpeedBonus
        {
            get
            {
                if (_highSpeedBonus == null)
                {
                    var gameObject = Resources.Load<HighSpeedBonus>("Bonuses/HightSpeedBonus");
                    _highSpeedBonus = Object.Instantiate(gameObject);
                }

                return _highSpeedBonus;
            }
        }

        public WinBonus[] WinBonuses
        {
            get
            {
                if (_winBonuses == null)
                {
                    var gameObjects = Resources.LoadAll<WinBonus>("WinBonus");
                    _winBonuses = new WinBonus[gameObjects.Length];
                    for (int i = 0; i < _winBonuses.Length; i++)
                    {
                        _winBonuses[i] = Object.Instantiate(gameObjects[i]);
                    }
                }
                return _winBonuses;
            }
        }
        
        
    }
}
