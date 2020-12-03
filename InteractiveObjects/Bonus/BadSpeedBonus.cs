using static Labyrinth.TimeScaleForBonus;


namespace Labyrinth
{
    public sealed class BadSpeedBonus : InteractiveObject
    {
        private const int INTERVAL = 10;

        protected override void Interaction()
        {
            _playerSpeed.SpeedBonusActions["SpeedDown"]?.Invoke();
            UndoChangesToThePlayer changesSpeedToThePlayer = ReturnBaseSpeed;
            StartTheCountdown(this, INTERVAL, ReturnBaseSpeed);
        }

        private void ReturnBaseSpeed()
        {
            _playerSpeed.SpeedBonusActions["ReturnBaseSpeed"].Invoke();
        }
    }
}
