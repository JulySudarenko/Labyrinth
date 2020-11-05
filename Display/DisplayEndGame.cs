﻿using System;
using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class DisplayEndGame
    {
        private readonly Text _finishGameLabel;

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            Debug.Log($"Вы проиграли. Вас убил {name} {color} цвета");
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name} {color} цвета";

        }
    }
}