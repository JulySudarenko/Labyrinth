using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplayReference
    {
        private GameObject _bonus;
        private GameObject _endGame;
        private GameObject _winGame;
        private GameObject _speedDisplay;
        private Button _restartButton;
        private Canvas _canvas;
        
        
               public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject WinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/WinGame");
                    _winGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _winGame;
            }
        }

        public GameObject Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonus");
                    _bonus = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _bonus;
            }
        }
        
        public GameObject SpeedDisplay
        {
            get
            {
                if (_speedDisplay == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/SpeedDisplay");
                    _speedDisplay = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _speedDisplay;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }
        
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            } 
        }
    }
}
