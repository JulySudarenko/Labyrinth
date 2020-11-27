using System;
using System.Collections.Generic;
using UnityEngine;
using static Labyrinth.TimeScaleForBonus;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Field

        public Dictionary<string, Action> SpeedBonusActions;
        public event Action<float> ShowSpeedAction;

        private Color _playerColor;
        private Color _playerBaseColor;

        private float _speed = 3.0f;
        private float _baseSpeed;
        private float _speedChanger = 2.0f;

        private int _interval = 10;

        public float Speed => _speed;

        public abstract void Move(float x, float y, float z);

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _baseSpeed = Speed;
            _playerColor = GetComponent<Renderer>().sharedMaterial.color;
            _playerBaseColor = _playerColor;
            SpeedBonusActions = new Dictionary<string, Action>
            {
                ["SpeedUp"] = SpeedUp,
                ["SpeedDown"] = SpeedDown,
                ["SpeedBase"] = SpeedBase,
                ["ReturnBaseSpeed"] = ReturnBaseSpeed,
                ["ChangeColor"] = ChangePlayerColor,
            };
            MakeBaseSpeed makeBaseSpeed = ReturnBaseSpeed;
            MakeBaseSpeed makeBaseColor = ReturnBaseColor;
        }

        #endregion


        #region Methods

        private void ChangePlayerColor()
        {
            _playerColor = Random.ColorHSV();
            StartTheCountdown(this, _interval, ReturnBaseColor);
        }

        private void ReturnBaseColor()
        {
            _playerColor = _playerBaseColor;
        }

        private void SpeedBase()
        {
            StartTheCountdown(this, _interval, ReturnBaseSpeed);
        }

        private void SpeedDown()
        {
            _speed /= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void SpeedUp()
        {
            _speed *= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void ReturnBaseSpeed()
        {
            _speed = _baseSpeed;
            ShowSpeedAction?.Invoke(Speed);
        }

        #endregion
    }
}
