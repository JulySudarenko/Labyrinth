using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Field

        public Dictionary<string, Action> _speedActions;

        public float Speed = 3.0f;
        public abstract void Move(float x, float y, float z);


    // protected Rigidbody _rigidbody;
    //     protected Vector3 _movement;
    //     protected float _moveHorizontal;
    //     protected float _moveVertical;
         private float _speedChanger = 2.0f;
         private float _baseSpeed;
         private int _interval = 10;

        #endregion


        #region UnityMethods

        private void Start()
        {
            // _rigidbody = GetComponent<Rigidbody>();
            // Cursor.visible = false;
            _baseSpeed = Speed;

            _speedActions = new Dictionary<string, Action>
            {
                ["SpeedUp"] = SpeedUp,
                ["SpeedDown"] = SpeedDown,
                ["SpeedBase"] = SpeedBase,
            };
        }

        #endregion


        #region Methods

        // protected void Move()
        // {
        //     _moveHorizontal = Input.GetAxis("Horizontal");
        //     _moveVertical = Input.GetAxis("Vertical");
        //
        //     _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
        //     _rigidbody.AddForce(_movement * Speed);
        // }

        private void SpeedBase()
        {
            StartCoroutine(TimeBonus(_interval));
        }

        private void SpeedDown()
        {
            Speed /= _speedChanger;
            PrintSpeed();
            SpeedBase();
        }

        private void SpeedUp()
        {
            Speed *= _speedChanger;
            PrintSpeed();
            SpeedBase();
        }

        private void ReturnBaseSpeed()
        {
            Speed = _baseSpeed;
            PrintSpeed();
        }

        public void Dead()
        {
            Destroy(gameObject);
        }

        IEnumerator TimeBonus(int _interval)
        {
            yield return new WaitForSeconds(_interval);

            ReturnBaseSpeed();
        }

        private void PrintSpeed()
        {
            Debug.Log($"Speed = {Speed}");
        }

        #endregion
    }
}
