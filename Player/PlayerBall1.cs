using UnityEngine;
using static UnityEngine.Debug;


namespace Labyrinth
{
    public sealed partial class PlayerBall
    {
        [SerializeField] private float _jumpForce = 5.0f;
        [SerializeField] private LayerMask _mask;
        private float _groundDistance = 0.2f;

        private void Jump()
        {
            //if (CheckGround())
            //{
            if (Input.GetButtonDown("Jump"))
            {
                Log("Jump");
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }
            //}
        }

        private bool CheckGround()
        {
            var hit = Physics.Raycast(transform.position, Vector3.down, _groundDistance, _mask);

            if (hit)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
