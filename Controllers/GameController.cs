﻿using System;
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
        private HoleBonus _holeBonus;
        private PlayerBase _player;
        private int _countBonuses;
        private int _winBonusRemained;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            
            var reference = new Reference();
            var bonusReference = new BonusReference();
            
            _player = null;
            if (PlayerType == PlayerType.Ball)
            {
                _player = reference.PlayerBall;
            }
            
            _holeBonus = bonusReference.HoleBonus;
            _interactiveObject.AddExecuteObject(_holeBonus);
            
            _cameraController = new CameraController(_player.transform, reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);
            
            _inputController = new InputController(_player);
            _interactiveObject.AddExecuteObject(_inputController);
            
            _displayBonuses = new DisplayBonuses(reference.Bonus);
            _displayEndGame = new DisplayEndGame(reference.EndGame);
            _displayWinGame = new DisplayWinGame(reference.WinGame);
            _displaySpeed = new DisplaySpeed(reference.SpeedDisplay);
            
            _player.ShowSpeedAction += ShowNewSpeed;
            
            _restartButton = reference.RestartButton;
            
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_player);
                _interactiveObject.AddExecuteObject(_inputController);
            }
            
            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus holeBonus)
                {
                    holeBonus.OnCaughtPlayerChange += CaughtPlayer;
                    holeBonus.OnCaughtPlayerChange += _displayEndGame.ShowLoseGameLabel;
                }
                
                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange += AddBonus;
                    _winBonusRemained++;
                }
            }
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
            ShowNewSpeed(_player.Speed);
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
                СongratulateVictory();
                _restartButton.gameObject.SetActive(true);
            }
        }

        private void RestartGame()
        {
            Dispose();
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        private void СongratulateVictory()
        {
            Dispose();
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
                    holeBonus.OnCaughtPlayerChange -= _displayEndGame.ShowLoseGameLabel;
                }
            
                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange -= AddBonus;
                }
            }
            _player.ShowSpeedAction -= ShowNewSpeed;
        }
        
        #endregion
    }
}
