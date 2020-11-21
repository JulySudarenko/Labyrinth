using System;
using UnityEngine;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Field

        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObject;
        private ViewInitializer _viewInitializer;
        private CameraController _cameraController;
        private InputController _inputController;
        private HoleBonus _holeBonus;
        private PlayerBase _player;

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

            _inputController = new InputController(_player, _interactiveObject);
            _interactiveObject.AddExecuteObject(_inputController);

            _viewInitializer = new ViewInitializer();
            _viewInitializer.InitializeDisplay();
            _player.ShowSpeedAction += _viewInitializer.ShowNewSpeed;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_player, _interactiveObject);
                _interactiveObject.AddExecuteObject(_inputController);
            }

            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus holeBonus)
                {
                    holeBonus.OnCaughtPlayerChange += _viewInitializer.CaughtPlayer;
                }

                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange += _viewInitializer.AddBonus;
                    _viewInitializer.WinBonusRemained++;
                }
            }

            _viewInitializer.ShowNewSpeed(_player.Speed);
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

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is HoleBonus holeBonus)
                {
                    holeBonus.OnCaughtPlayerChange -= _viewInitializer.CaughtPlayer;
                }

                if (o is WinBonus winBonus)
                {
                    winBonus.OnPointChange -= _viewInitializer.AddBonus;
                }
            }

            _player.ShowSpeedAction -= _viewInitializer.ShowNewSpeed;
        }

        #endregion
    }
}
