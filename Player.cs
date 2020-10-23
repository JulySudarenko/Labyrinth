using UnityEngine;


namespace Labyrinth
{
    public class Player : MonoBehaviour
    {
        #region Field

        public float Speed = 3.0f;
        private Rigidbody _rigidbody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * Speed);
        }

        #endregion
    }
}
