using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Random;


namespace Labyrinth
{
    public class Fly
    {
        private Transform _flyingBonus { get; }
        private readonly float _flyAltitude;

        public Fly(InteractiveObject flyingBonus)
        {
            _flyingBonus = flyingBonus.transform;
            _flyAltitude = Range(1.0f, 5.0f);
        }

        public void MakeItFly()
        {
            _flyingBonus.localPosition = new Vector3(_flyingBonus.localPosition.x,
                    PingPong(Time.time, _flyAltitude),
                    _flyingBonus.localPosition.z);
        }
    }
}
