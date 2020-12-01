using UnityEngine;
using static Labyrinth.AxisManager;


namespace Labyrinth
{
    public sealed class InputController : IExecute
    {
        private readonly Transform _player;
        private readonly ListInteractiveObject _interactiveObject;
        private readonly SaveDataRepository _saveDataRepository;

        // public InputController(PlayerBase player, ListInteractiveObject interactiveObject)
        // {
        //     _playerBase = player;
        //
        //     _interactiveObject = interactiveObject;
        //     
        //     _saveDataRepository = new SaveDataRepository();
        // }
        
        public InputController(Transform player, ListInteractiveObject interactiveObject)
        {
            _player = player;

            _interactiveObject = interactiveObject;
            
            _saveDataRepository = new SaveDataRepository();
        }
        
        public void Execute()
        {
            //_player.Move(Input.GetAxis(HORIZONTAL), 0.0f, Input.GetAxis(VERTICAL));
        
            if (Input.GetKeyDown(SAVE))
            {
                _saveDataRepository.Save(_player, _interactiveObject);
            }
        
            if (Input.GetKeyDown(LOAD))
            {
                _saveDataRepository.Load(_player, _interactiveObject);
            }
        }
        
        // public void Execute()
        // {
        //     _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //
        //     if (Input.GetKeyDown(_savePlayer))
        //     {
        //         _saveDataRepository.Save(_playerBase, _interactiveObject);
        //     }
        //
        //     if (Input.GetKeyDown(_loadPlayer))
        //     {
        //         _saveDataRepository.Load(_playerBase, _interactiveObject);
        //     }
        // }
    }
}