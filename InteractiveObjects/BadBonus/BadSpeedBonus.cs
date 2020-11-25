

namespace Labyrinth
{
    public sealed class BadSpeedBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            _player.SpeedBonusActions["SpeedDown"]?.Invoke();
        }
    }
}
