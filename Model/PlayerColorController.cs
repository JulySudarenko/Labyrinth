using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;


namespace Labyrinth
{
    public class PlayerColorController
    {
        public Dictionary<string, Action> ColorBonusActions;

        private Renderer _playerRenderer;
        private readonly Color _baseColor;

        public PlayerColorController(Renderer playerRenderer)
        {
            _playerRenderer = playerRenderer;
            _baseColor = playerRenderer.material.color;

                ColorBonusActions = new Dictionary<string, Action>
            {
                ["ChangeColor"] = ChangeColor,
                ["ReturnBaseColor"] = ReturnBaseColor,
            };
        }

        public void ReturnBaseColor()
        {
            _playerRenderer.material.color = _baseColor;
        }

        public void ChangeColor()
        {
            _playerRenderer.material.color = ColorHSV();
        }
    }
}
