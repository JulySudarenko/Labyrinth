using static UnityEngine.Time;
using static UnityEngine.Debug;
using UnityEngine;
using System.Collections;


namespace Labyrinth
{
    public class BonusTimer : MonoBehaviour
    {
        private float _timer;

        private void Start()
        {
            StartCoroutine(TimeBonus());
        }

        IEnumerator TimeBonus()
        {
            Log(TimeBonus());
            yield return new WaitForSeconds(10);
        }

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
