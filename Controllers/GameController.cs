using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Field
        
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayWinGame _displayWinGame;
        private DisplaySpeed _displaySpeed;
        private Button _restartButton;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private int _countBonuses;
        private int _winBonusRemained;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            
            var reference = new Reference();
            
            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = reference.PlayerBall;
            }
            
            _cameraController = new CameraController(player.transform, reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);
            
            _inputController = new InputController(player);
            _interactiveObject.AddExecuteObject(_inputController);
            
            _displayBonuses = new DisplayBonuses(reference.Bonus);
            _displayEndGame = new DisplayEndGame(reference.EndGame);
            _displayWinGame = new DisplayWinGame(reference.WinGame);
            _displaySpeed = new DisplaySpeed(reference.SpeedDisplay);
            
            player.ShowSpeedAction += ShowNewSpeed;
            
            _restartButton = reference.RestartButton;
            
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObject.AddExecuteObject(_inputController);
            }
            
            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus holeBonus)
                {
                    holeBonus.OnCaughtPlayerChange += CaughtPlayer;
                    holeBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }
                
                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange += AddBonus;
                    _winBonusRemained++;
                }
            }
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
            ShowNewSpeed(player.Speed);
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        #endregion


        #region Methods
        
        private void CaughtPlayer(string value, Color args)
        {
            _restartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            _winBonusRemained--;
            if (_winBonusRemained == 0)
            {
                Victory();
                _restartButton.gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        private void Victory()
        {
            _displayWinGame.WinGame();
            Time.timeScale = 0.0f;
        }

        private void ShowNewSpeed(float newSpeed)
        {
            _displaySpeed.ShowSpeed(newSpeed);
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus holeBonus)
                {
                    holeBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    holeBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }
            
                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange -= AddBonus;
                }
            }
        }
        
        #endregion
    }
}
