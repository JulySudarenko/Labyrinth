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
        
        public PlayerColorController(PlayerData playerData)
        {
            _playerColor = playerData.BallMaterial.color;
            _baseColor = _playerColor;
            
            
            ColorBonusActions = new Dictionary<string, Action>
            {
                ["ChangeColor"] = ChangeColor,
                ["ReturnBaseColor"] = ReturnBaseColor,
            };
        }

        private void ReturnBaseColor()
        {
            _playerColor = Random.ColorHSV();
        }

        private void ChangeColor()
        {
            _playerColor = _baseColor;
        }
    }
}
