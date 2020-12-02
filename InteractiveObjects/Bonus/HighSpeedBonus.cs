

namespace Labyrinth
{
    public sealed class HighSpeedBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            _playerSpeed.SpeedBonusActions["SpeedUp"]?.Invoke();
        }
    }
}