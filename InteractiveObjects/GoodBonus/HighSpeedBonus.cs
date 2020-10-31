

namespace Labyrinth
{
    public sealed class HighSpeedBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            _player._speedActions["SpeedUp"]?.Invoke();
        }
    }
}