using UnityEngine;


namespace Labyrinth
{
    public sealed class WinBonus : InteractiveObject, IFlay, IFlicker
    {
        #region Field

        public int Point = 5;
        private float _lengthFlay;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            _view.Display(Point);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void BackInteraction()
        {
            Debug.Log($"Poins {Point}");
        }

        public bool Equals(WinBonus other)
        {
            return Point == other.Point;
        }

        #endregion
    }
}
