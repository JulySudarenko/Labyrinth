using UnityEngine;


namespace Labyrinth
{
    public class MoveController : IExecute
    {
        private readonly Transform _player;
        private readonly ISpeed _speed;
        
        public void Move(Transform player, float x, float y, float z)
        {
            _player.rigidbody.AddForce(new Vector3(x,y,z) * _speed);
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
