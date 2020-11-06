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
        //public event Action<float> _showSpeed;

        public float Speed = 3.0f;
        public abstract void Move(float x, float y, float z);

        private float _speedChanger = 2.0f;
        private float _baseSpeed;
        private int _interval = 10;

        #endregion


        #region UnityMethods

        private void Awake()
        {
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

        public void SpeedBase()
        {
            StartCoroutine(TimeBonus(_interval));
        }

        public void SpeedDown()
        {
            Speed /= _speedChanger;
            PrintSpeed();
            SpeedBase();
        }

        public void SpeedUp()
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