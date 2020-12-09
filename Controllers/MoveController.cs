using UnityEngine;


namespace Labyrinth
{
    public class MoveController : IExecute, ICleanup
    {
        private readonly Transform _player;
        private readonly Rigidbody _rigidbody;
        private readonly ISpeed _speed;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            Transform player, ISpeed speed)
        {
            _player = player;
            _rigidbody = _player.GetComponent<Rigidbody>();
            _speed = speed;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute()
        {
            _rigidbody.AddForce(new Vector3(_horizontal, 0.0f, _vertical) * _speed.Speed);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
