using UnityEngine;


namespace Labyrinth
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerData _playerData;
        private string _name = "Player";
        private float _mass = 1.0f;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        public GameObject CreatePlayer()
        {
            return new GameObject().
                AddName(_name).
                AddTag(_name).
                AddTransform(_playerData.BallTransform).
                AddMesh(_playerData.BallMesh).
                AddMaterial(_playerData.BallMaterial).
                AddSphereCollider().
                AddRigidbody(_mass);
        }
    }
}
