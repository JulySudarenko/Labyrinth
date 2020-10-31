using UnityEngine;


namespace Labyrinth
{
    public class Player : MonoBehaviour
    {
        #region Field

        public float Speed = 3.0f;
        protected Rigidbody _rigidbody;
        protected Vector3 _movement;
        protected float _moveHorizontal;
        protected float _moveVertical;

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
            _moveHorizontal = Input.GetAxis("Horizontal");
            _moveVertical = Input.GetAxis("Vertical");

            _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
            _rigidbody.AddForce(_movement * Speed);
        }

        public void Dead()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}
