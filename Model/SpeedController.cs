using System;
using System.Collections.Generic;


namespace Labyrinth
{
    public sealed class SpeedController : ISpeed
    {
        public Dictionary<string, Action> SpeedBonusActions;
        public event Action<float> ShowSpeedAction;
        private const float _speedChanger = 2.0f;
        private readonly float _baseSpeed;
        private float _playerSpeed;


        public float Speed => _playerSpeed;

        public SpeedController(PlayerData playerData)
        {
            _playerSpeed = playerData.Speed;
            _baseSpeed = _playerSpeed;


            SpeedBonusActions = new Dictionary<string, Action>
            {
                ["SpeedUp"] = SpeedUp,
                ["SpeedDown"] = SpeedDown,
                ["ReturnBaseSpeed"] = ReturnBaseSpeed,
            };
        }

        #region Methods

        private void SpeedDown()
        {
            _playerSpeed /= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
        }

        private void SpeedUp()
        {
            _playerSpeed *= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
        }

        private void ReturnBaseSpeed()
        {
            _playerSpeed = _baseSpeed;
            ShowSpeedAction?.Invoke(Speed);
        }

        #endregion
    }
}
