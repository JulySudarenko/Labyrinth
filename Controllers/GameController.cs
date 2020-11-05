using System;
using System.Collections.Generic;
using System.Linq;
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
        private Button _restartButton;
        private CameraController _cameraController;
        private InputController _inputController;
        private Reference _reference;
        private int _countBonuses;

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
                
                if (o is WinBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }

                if (o is HighSpeedBonus highSpeedBonus)
                {
                    //player._speedActions["SpeedUp"]?.Invoke();
                }
                
                if (o is BadSpeedBonus badSpeedBonus)
                {
                    //player._speedActions["SpeedDown"]?.Invoke();
                }
            }
            
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
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
        }
        
        // public void Dispose()
        // {
        //     foreach (var o in _interactiveObject)
        //     {
        //         if (o is InteractiveObject interactiveObject)
        //         {
        //             if (o is HoleBonus holeBonus)
        //             {
        //                 holeBonus.CaughtPlayer -= CaughtPlayer;
        //                 holeBonus.CaughtPlayer -= _displayEndGame.GameOver;
        //             }
        //             Destroy(interactiveObject.gameObject);
        //         }
        //     }
        // }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }
            
                if (o is WinBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
            }
        }

        //
        // private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        // {
        //     value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
        //     _interactiveObjects.Remove(value);
        // }
        
        #endregion
    }
}
