using System;
using UnityEngine;
using static UnityEngine.Time;
using static UnityEngine.Mathf;
using static UnityEngine.Random;


namespace Labyrinth
{
    public sealed class BadSpeedBonus : InteractiveObject, IFlay, IRotation, ICloneable
    {
        #region Field

        private float _lengthFlay;
        private float _speedRotation;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            _player._speedActions["SpeedDown"]?.Invoke();
        }

        public override void Execute()
        {
            if(!IsInteractable){return;}
            Flay();
            Rotation();
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
