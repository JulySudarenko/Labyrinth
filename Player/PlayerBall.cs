using UnityEngine;


namespace Labyrinth
{
    public sealed partial class PlayerBall : Player
    {
        private float _mouseSpeed;
        private float _deltaSpeed = 10.0f;

        private void FixedUpdate()
        {
            Move();
            MoveMouse();
            Jump();
        }

        private void MoveMouse()
        {
            float moveHorizontal = Input.GetAxis("Mouse X");
            float moveVertical = Input.GetAxis("Mouse Y");

            _movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(_movement * (Speed * _deltaSpeed));
        }
    }
}
