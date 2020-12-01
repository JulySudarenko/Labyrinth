using UnityEngine;


namespace Labyrinth
{
    public class PlayerInitialization : IInitialization
    {
        private IPlayerFactory _playerFactory;
        private Transform _player;
        
        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }
        
        public void Initialize()
        {
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}
