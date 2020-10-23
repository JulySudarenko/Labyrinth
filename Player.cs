using UnityEngine;


namespace Labyrinth
{
    public class Player : MonoBehaviour
    {
        #region Field

        public bool IsAlternativeControl = false;
        public float Speed = 3.0f;
        public float MouseSpeed = 20.0f;
        private Rigidbody _rigidbody;


        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Cursor.visible = false;
        }

        #endregion


        #region Methods

        protected void Move()
        {

            float moveHorizontal;
            float moveVertical;
            float localSpeed;

            if (IsAlternativeControl)
            {
                moveHorizontal = Input.GetAxis("Mouse X");
                moveVertical = Input.GetAxis("Mouse Y");
                localSpeed = MouseSpeed;
            }
            else
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                localSpeed = Speed;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * localSpeed);
        }

        #endregion
    }
}
