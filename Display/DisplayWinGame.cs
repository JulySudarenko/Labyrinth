using System;
using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplayWinGame : IView
    {
        private readonly Text _winLabel;

        public DisplayWinGame(GameObject winGame)
        {
            _winLabel = winGame.GetComponentInChildren<Text>();
            _winLabel.text = String.Empty;
        }

        public void WinGame()
        {
            _winLabel.text = $"Поздравляю!!! Вы выиграли!";
        }
    }
}