using UnityEngine;


namespace Labyrinth
{
    public sealed partial class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x,y,z) * Speed);
        }
    }
}
