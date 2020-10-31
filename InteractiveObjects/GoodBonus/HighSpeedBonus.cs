using static UnityEngine.Debug;


namespace Labyrinth
{
    public sealed class HighSpeedBonus : InteractiveObject
    {
        #region Field

        private float _highSpeed = 2.0f;

        #endregion


        #region Methods

        protected override void Interaction()
        {
            _player.Speed = _player.Speed * _highSpeed;
            Log($"Speed {_player.Speed}");
        }

        protected override void BackInteraction()
        {
            Log($"Speed {_player.Speed}");
            //_player.Speed = _player.Speed / _highSpeed;
        }

        #endregion
    }
}