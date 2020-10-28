using System;
using UnityEngine;
using static UnityEngine.Time;
using static UnityEngine.Mathf;
using static UnityEngine.Random;
using static UnityEngine.Debug;


namespace Labyrinth
{
    public sealed class BadSpeedBonus : InteractiveObject, IFlay, IRotation, ICloneable
    {
        #region Field

        private float _lengthFlay;
        private float _speedRotation;
        private float _lowSpeed = 2.0f;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        protected override void BackInteraction()
        {

            Log($"Speed {_player.Speed}");
            //_player.Speed = _player.Speed * _lowSpeed;
            Clone();
        }

        protected override void Interaction()
        {
            _player.Speed = _player.Speed / _lowSpeed;
            Log($"Speed {_player.Speed}");
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }

        #endregion
    }
}
