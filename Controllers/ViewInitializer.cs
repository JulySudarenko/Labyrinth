using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Labyrinth
{
    public class ViewInitializer
    {
        #region Fields

        private DisplayReference _displayReference;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private DisplayWinGame _displayWinGame;
        private DisplaySpeed _displaySpeed;
        private Button _restartButton;

        private int _countBonuses;
        private int _winBonusRemained;
        
        public int WinBonusRemained
        {
            get => _winBonusRemained;
            set => _winBonusRemained = value;
        }

        #endregion

        
        #region Methods

        public void InitializeDisplay()
        {
            _displayReference = new DisplayReference();
            Debug.Log(_displayReference);
            _displayBonuses = new DisplayBonuses(_displayReference.Bonus);
            _displayEndGame = new DisplayEndGame(_displayReference.EndGame);
            _displayWinGame = new DisplayWinGame(_displayReference.WinGame);
            _displaySpeed = new DisplaySpeed(_displayReference.SpeedDisplay);
            _restartButton = _displayReference.RestartButton;
            
            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
        }
 
        public void CaughtPlayer(string value, Color args)
        {
            _restartButton.gameObject.SetActive(true);
            _displayEndGame.ShowLoseGameLabel(value, args);
            Time.timeScale = 0.0f;
        }
        
        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0); 
            Time.timeScale = 1.0f;
        }

        public void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            _winBonusRemained--;
            if (_winBonusRemained == 0)
            {
                СongratulateVictory();
                _restartButton.gameObject.SetActive(true);
            }
        }

        private void СongratulateVictory()
        {
            _displayWinGame.WinGame();
            Time.timeScale = 0.0f;
        }

        public void ShowNewSpeed(float newSpeed)
        {
            _displaySpeed.ShowSpeed(newSpeed);
        }

        #endregion
    }
}
