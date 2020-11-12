using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Debug;


namespace Labyrinth
{
    public sealed class DisplayBonuses : IView
    {
        #region Field

        private Text _textPoints;
        private int _point;

        #endregion

        public DisplayBonuses()
        {
            _textPoints = Object.FindObjectOfType<Text>();
        }

        #region Methods

        public void Display(int value)
        {
            _point += value;
            _textPoints.text = $"Вы набрали: {_point} очков";
            Log($"All score: {_point}");
            Log($"Score for one point {value}");
        }

        #endregion
    }
}

