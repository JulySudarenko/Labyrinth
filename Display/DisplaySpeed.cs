using System;
using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplaySpeed : IView
    {
        private readonly Text _speedLabel;

        public DisplaySpeed(GameObject winGame)
        {
            _speedLabel = winGame.GetComponentInChildren<Text>();
            _speedLabel.text = String.Empty;
        }

        public void ShowSpeed(float speed)
        {
            _speedLabel.text = $"Скорость {speed}";
        }
    }
}