using UnityEngine;


namespace Labyrinth
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly ListExecuteObject _interactiveObject;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public InputController(PlayerBase player, ListExecuteObject interactiveObject)
        {
            _playerBase = player;

            _interactiveObject = interactiveObject;
            
            _saveDataRepository = new SaveDataRepository();
        }
        
        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase, _interactiveObject);
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase, _interactiveObject);
            }
        }
    }
}