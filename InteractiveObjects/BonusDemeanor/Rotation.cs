using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Time;


namespace Labyrinth
{
    public class Rotation
    {
        private Transform _rotatingBonus { get; }
        private readonly float _rotationSpeed;
        
        public Rotation(InteractiveObject rotatingBonus)
        {
            _rotatingBonus = rotatingBonus.transform;
            _rotationSpeed = Range(1.0f, 5.0f);
        }
        
        public void Rotate()
        {
            _rotatingBonus.Rotate(Vector3.up * (deltaTime * _rotationSpeed), Space.World);
        }
    }
}
