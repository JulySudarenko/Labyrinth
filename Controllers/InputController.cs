using UnityEngine;
using static Labyrinth.AxisManager;


namespace Labyrinth
{
    public sealed class InputController : IExecute
    {
        private readonly Transform _player;
        private readonly ListInteractiveObject _interactiveObject;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;


        public InputController(Transform player, ListInteractiveObject interactiveObject,
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _player = player;

            _interactiveObject = interactiveObject;

            _saveDataRepository = new SaveDataRepository();
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        public void Execute()
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();

            if (Input.GetKeyDown(SAVE))
            {
                _saveDataRepository.Save(_player, _interactiveObject);
            }

            if (Input.GetKeyDown(LOAD))
            {
                _saveDataRepository.Load(_player, _interactiveObject);
            }
        }
    }
}
