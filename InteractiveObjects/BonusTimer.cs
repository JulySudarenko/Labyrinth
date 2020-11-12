using static UnityEngine.Time;
using static UnityEngine.Debug;
using UnityEngine;


namespace Labyrinth
{
    public class BonusTimer : MonoBehaviour
    {
        private float _timer;

        public bool IsTimeInterval(float timeInterval)
        {
            _timer += deltaTime;
            Log(_timer);

            if (_timer > timeInterval)
            {
                _timer = 0.0f;
                return true;
            }
            else
                return false;
        }
    }
}
