using UnityEngine;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, ICleanup
    {
        #region Field

        [SerializeField] private Data _data;
        private Controllers _controllers;
        private ListInteractiveObject _interactiveObject;
        private ListOfColoringBonuses _coloringBonuses;
        private InteractiveObjectsInitializer _interactiveObjectsInitializer;
        private ViewInitializer _viewInitializer;
        private CameraController _cameraController;
        private InputController _inputController;
        private SpeedController _speedController;
        private PlayerColorController _colorController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjectsInitializer = new InteractiveObjectsInitializer();
            _interactiveObjectsInitializer.Initialize();
            _viewInitializer = new ViewInitializer();
            _speedController = new SpeedController(_data.Player);

            GetComponentInChildren<BonusCreator>().CreateBonus();
            _coloringBonuses = new ListOfColoringBonuses();

            var reference = new Reference();
            var playerFactory = new PlayerFactory(_data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory);

            _interactiveObject = new ListInteractiveObject();

            _controllers = new Controllers();

            _controllers.Add(_interactiveObjectsInitializer.ListOfFlyingBonuses);
            _controllers.Add(_interactiveObjectsInitializer.ListOfFlickeringBonuses);
            _controllers.Add(_interactiveObjectsInitializer.ListOfRotatingBonuses);
            _controllers.Add(_coloringBonuses);

            var inputInitialization = new InputInitialization();
            _inputController = new InputController(playerInitialization.GetPlayer(), _interactiveObject,
                inputInitialization.GetInput());
            _colorController = new PlayerColorController(_data.Player, playerInitialization.GetPlayer());
            _interactiveObject.ConnectAll(_speedController, _colorController);

            _controllers.Add(_viewInitializer);
            _controllers.Add(inputInitialization);
            _controllers.Add(playerInitialization);

            _controllers.Add(_inputController);
            _controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(),
                _speedController));
            _controllers.Add(new CameraController(playerInitialization.GetPlayer(), reference.MainCamera.transform));
            _controllers.Initialize();

            _speedController.ShowSpeedAction += _viewInitializer.ShowNewSpeed;
            _interactiveObjectsInitializer.HoleBonus.OnCaughtPlayerChange += _viewInitializer.CaughtPlayer;

            foreach (var winBonus in _interactiveObjectsInitializer.WinBonuses)
            {
                winBonus.OnPointChange += _viewInitializer.AddBonus;
                _viewInitializer.WinBonusRemained++;
            }

            _viewInitializer.ShowNewSpeed(_speedController.Speed);
        }

        private void Update()
        {
            _controllers.Execute();
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        #endregion


        #region Methods

        public void Cleanup()
        {
            foreach (var winBonus in _interactiveObjectsInitializer.WinBonuses)
            {
                winBonus.OnPointChange -= _viewInitializer.AddBonus;
            }

            _interactiveObjectsInitializer.HoleBonus.OnCaughtPlayerChange -= _viewInitializer.CaughtPlayer;
            _speedController.ShowSpeedAction -= _viewInitializer.ShowNewSpeed;
        }

        #endregion
    }
}
