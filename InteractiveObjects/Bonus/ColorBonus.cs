using static Labyrinth.TimeScaleForBonus;


namespace Labyrinth
{
    public class ColorBonus : InteractiveObject
    {
        private const int INTERVAL = 10;

        protected override void Interaction()
        {
            _playerColor.ColorBonusActions["ChangeColor"]?.Invoke();
            UndoChangesToThePlayer changesColorToThePlayer = ReturnColor;
            StartTheCountdown(this, INTERVAL, ReturnColor);
        }

        private void ReturnColor()
        {
            _playerColor.ColorBonusActions["ReturnBaseColor"].Invoke();
        }
    }
}
