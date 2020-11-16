﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Labyrinth.TimeScaleForBonus;


namespace Labyrinth
{
    public abstract class PlayerBase : MonoBehaviour
    {
        #region Field

        public Dictionary<string, Action> SpeedBonusActions;
        public event Action<float> ShowSpeedAction;

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
            SpeedBonusActions = new Dictionary<string, Action>
            {
                ["SpeedUp"] = SpeedUp,
                ["SpeedDown"] = SpeedDown,
                ["SpeedBase"] = SpeedBase,
                ["ReturnBaseSpeed"] = ReturnBaseSpeed,
            };
            MakeBaseSpeed makeBaseSpeed = ReturnBaseSpeed;
        }

        #endregion


        #region Methods

        private void SpeedBase()
        {
            StartTheCountdown(this, _interval, ReturnBaseSpeed);
        }

        private void SpeedDown()
        {
            Speed /= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void SpeedUp()
        {
            Speed *= _speedChanger;
            ShowSpeedAction?.Invoke(Speed);
            SpeedBase();
        }

        private void ReturnBaseSpeed()
        {
            Speed = _baseSpeed;
            ShowSpeedAction?.Invoke(Speed);
        }
        //
        // public void Dead()
        // {
        //     Destroy(gameObject);
        // }

        // IEnumerator TimeBonus(int _interval)
        // {
        //     yield return new WaitForSeconds(_interval);
        //
        //     ReturnBaseSpeed();
        // }

        #endregion
    }
}