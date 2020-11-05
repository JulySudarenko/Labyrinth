using UnityEngine;


namespace Labyrinth
{
    public sealed partial class PlayerBall : PlayerBase
    {
        [SerializeField] private float _jumpForce = 5.0f;
        private float _mouseSpeed;
        private float _deltaSpeed = 10.0f;
        private Rigidbody _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x,y,z) * Speed);
        }
        
        // private void FixedUpdate()
        // {
        //     Move();
        //     MoveMouse();
        //     Jump();
        // }
        //
        // private void MoveMouse()
        // {
        //     float moveHorizontal = Input.GetAxis("Mouse X");
        //     float moveVertical = Input.GetAxis("Mouse Y");
        //
        //     _movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //     _rigidbody.AddForce(_movement * (Speed * _deltaSpeed));
        // }
        
        // private void Jump()
        // {
        //     //if (CheckGround())
        //     //{
        //     if (Input.GetButtonDown("Jump"))
        //     {
        //         Debug.Log("Jump");
        //         _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        //     }
        //     //}
        // }

        // private bool CheckGround()
        // {
        //     var hit = Physics.Raycast(transform.position, Vector3.down, _groundDistance, _mask);
        //
        //     if (hit)
        //     {
        //         return true;
        //     }
        //
        //     else
        //     {
        //         return false;
        //     }
        // }
    }
}
