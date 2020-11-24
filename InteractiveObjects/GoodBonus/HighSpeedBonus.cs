using UnityEngine;
using static UnityEngine.Time;
using static UnityEngine.Random;


namespace Labyrinth
{
    public sealed class HighSpeedBonus : InteractiveObject, IRotation
    {
        #region Field
        
        private float _speedRotation;

        #endregion

        private void Awake()
        {
            _speedRotation = Range(10.0f, 50.0f);
        }
        
        #region Methods

        protected override void Interaction()
        {
            _player.SpeedBonusActions["SpeedUp"]?.Invoke();
        }

        // public override void Execute()
        // {
        //     if(!IsInteractable){return;}
        //     Rotation();
        // }
        
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }
        #endregion
    }
}