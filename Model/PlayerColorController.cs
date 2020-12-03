using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public class PlayerColorController
    {
        public Dictionary<string, Action> ColorBonusActions;

        private Color _playerColor;
        private readonly Color _baseColor;

        private const int INTERVAL = 10;

        public PlayerColorController(PlayerData playerData, Transform player)
        {
            _playerColor = playerData.BallMaterial.color;
            _baseColor = playerData.BallMaterial.color;


            ColorBonusActions = new Dictionary<string, Action>
            {
                ["ChangeColor"] = ChangeColor,
                ["ReturnBaseColor"] = ReturnBaseColor,
            };
        }

        public void ReturnBaseColor()
        {
            _playerColor = _baseColor;
        }

        public void ChangeColor()
        {
            _playerColor = Random.ColorHSV();
        }
    }
}
