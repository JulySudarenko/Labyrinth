using static Labyrinth.TimeScaleForBonus;


namespace Labyrinth
{
    public class ColorBonus : InteractiveObject
    {
        private const int INTERVAL = 10;

        protected override void Interaction()
        {
            _playerColor.ColorBonusActions["ChangeColor"]?.Invoke();
            UndoChangesToThePlayer changesSpeedToThePlayer = ReturnBaseColor;
            StartTheCountdown(this, INTERVAL, ReturnBaseColor);
        }

        private void ReturnBaseColor()
        {
            _playerColor.ColorBonusActions["ReturnBaseColor"].Invoke();
        }
    }
}
