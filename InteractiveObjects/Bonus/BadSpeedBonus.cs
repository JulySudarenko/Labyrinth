

namespace Labyrinth
{
    public sealed class BadSpeedBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            _playerSpeed.SpeedBonusActions["SpeedDown"]?.Invoke();
        }

    }
}
