using UnityEngine;


namespace Labyrinth
{
    public class PlayerInitialization : IInitialization
    {
        private IPlayerFactory _playerFactory;
        private GameObject _player;

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
            return _player.transform;
        }

        public Renderer GetRenderer()
        {
            return _player.GetComponent<Renderer>();
        }
    }
}
