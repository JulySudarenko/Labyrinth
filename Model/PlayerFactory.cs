using UnityEngine;


namespace Labyrinth
{
    public class PlayerFactory : IPlayerFactory
    {
        private PlayerData _playerData;
        private float _mass = 1.0f;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        public Transform CreatePlayer()
        {
            // GameObject player = Object.Instantiate(_playerData.BallPrefab).AddRigidbody(_mass).AddSphereCollider();
            // return player.transform;
            return new GameObject("Player").AddTransforn(_playerData.BallTransform).
                AddMesh(_playerData.BallMesh).
                AddMaterial(_playerData.BallMaterial).
                AddSphereCollider().
                AddRigidbody(_mass).transform;
        }
    }
}
