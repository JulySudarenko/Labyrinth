using System;
using UnityEngine;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Field

        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _executeObject;
        private ListInteractiveObject _interactiveObject;
        private ListOfColoringBonuses _coloringBonuses;
        private InteractiveObjectsInitializer _interactiveObjectsInitializer;
        private ViewInitializer _viewInitializer;
        private CameraController _cameraController;
        private InputController _inputController;
        private PlayerBase _player;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executeObject = new ListExecuteObject();
            _interactiveObjectsInitializer = new InteractiveObjectsInitializer();
            _interactiveObjectsInitializer.Initialize();

            var reference = new Reference();

            _player = null;
            if (PlayerType == PlayerType.Ball)
            {
                _player = reference.PlayerBall;
            }

            _executeObject.AddExecuteObject(_interactiveObjectsInitializer.ListOfFlyingBonuses);
            _executeObject.AddExecuteObject(_interactiveObjectsInitializer.ListOfFlickeringBonuses);
            _executeObject.AddExecuteObject(_interactiveObjectsInitializer.ListOfRotatingBonuses);
            //_executeObject.AddExecuteObject(_interactiveObjectsInitializer.ListOfColoringBonuses);

            _interactiveObject = new ListInteractiveObject();

            _cameraController = new CameraController(_player.transform, reference.MainCamera.transform);
            _executeObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(_player, _interactiveObject);
            _executeObject.AddExecuteObject(_inputController);

            _viewInitializer = new ViewInitializer();
            _viewInitializer.InitializeDisplay();
            _player.ShowSpeedAction += _viewInitializer.ShowNewSpeed;
            _interactiveObjectsInitializer.HoleBonus.OnCaughtPlayerChange += _viewInitializer.CaughtPlayer;

            foreach (var winBonus in _interactiveObjectsInitializer.WinBonuses)
            {
                winBonus.OnPointChange += _viewInitializer.AddBonus;
                _viewInitializer.WinBonusRemained++;
            }

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_player, _interactiveObject);
                _executeObject.AddExecuteObject(_inputController);
            }

            _viewInitializer.ShowNewSpeed(_player.Speed);
        }

        private void Start()
        {
            _coloringBonuses = new ListOfColoringBonuses();
            _executeObject.AddExecuteObject(_coloringBonuses);
        }
        
        private void Update()
        {
            for (var i = 0; i < _executeObject.Length; i++)
            {
                var interactiveObject = _executeObject[i];
                if (interactiveObject != null)
                {
                    interactiveObject.Execute();
                }
            }
        }

        #endregion


        #region Methods

        public void Dispose()
        {
            foreach (var o in _executeObject)
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
