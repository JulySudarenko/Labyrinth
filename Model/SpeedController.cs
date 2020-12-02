using System;
using System.Collections.Generic;


namespace Labyrinth
{
    public sealed class SpeedController : ISpeed
    {
        public Dictionary<string, Action> SpeedBonusActions;
        public event Action<float> ShowSpeedAction;
        
        private float _playerSpeed;
        private readonly float _baseSpeed;

        private const float _speedChanger = 2.0f;
        private const int _interval = 10;

        public float Speed => _playerSpeed;

        public SpeedController(PlayerData _playerData)
        {
            _playerSpeed = _playerData.Speed;
            _baseSpeed = _playerSpeed;
            
            
            SpeedBonusActions = new Dictionary<string, Action>
            {
                ["SpeedUp"] = SpeedUp,
                ["SpeedDown"] = SpeedDown,
                ["SpeedBase"] = SpeedBase,
                ["ReturnBaseSpeed"] = ReturnBaseSpeed,
            };
        }
        
        #region Methods

        private void SpeedBase()
        {
            //StartTheCountdown(this, _interval, ReturnBaseSpeed);
        }

        private void SpeedDown()
        {
            _playerSpeed /= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void SpeedUp()
        {
            _playerSpeed *= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void ReturnBaseSpeed()
        {
            _playerSpeed = _baseSpeed;
            ShowSpeedAction?.Invoke(Speed);
        }

        #endregion
    }
}
