using System;
using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplayBonuses : IView
    {
        private Text _textPoints;

        public DisplayBonuses(GameObject bonus)
        {
            _textPoints = bonus.GetComponentInChildren<Text>();
            _textPoints.text = String.Empty;
        }

        public void Display(int value)
        {
            _textPoints.text = $"Вы набрали: {value} очков";
        }
    }
}

