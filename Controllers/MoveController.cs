using UnityEngine;


namespace Labyrinth
{
    public class MoveController : IExecute
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

        // public void Move(Transform player, float x, float y, float z)
        // {
        //     _player.GetComponent<Rigidbody>().AddForce(new Vector3(x, y, z) * _speed);
        // }

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
            //var speed =  _speed.Speed;
            _rigidbody.AddForce(new Vector3(_horizontal, 0.0f, _vertical) * _speed.Speed);
            //_move.Set(new Vector3(, _horizontal, 0.0f, _vertical) * _speed.Speed);
            //_player.rilocalPosition += _move;
        }
    }
}
