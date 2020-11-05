using System;
using UnityEngine;
using static UnityEngine.Random;


namespace Labyrinth
{
    public sealed class WinBonus : InteractiveObject, IFlay, IFlicker
    {
        #region Field

        public int Point = 5;
        private float _lengthFlay;
        public event Action<int> OnPointChange = delegate(int i) {  }; 
        private Material _material;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Range(1.0f, 5.0f);
        }

        #endregion


        #region Methods

        protected override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public override void Execute()
        {
            if(!IsInteractable){return;}
            Flay();
            Flicker();
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

        // public bool Equals(WinBonus other)
        // {
        //     return Point == other.Point;
        // }

        #endregion
    }
}
