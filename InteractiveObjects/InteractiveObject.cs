using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        #region Field

        public event Action<InteractiveObject> OnDestroyChange;
        public delegate void BonusInteraction(object value);
        public event BonusInteraction BonusTaken;

        public bool IsInteractable { get; } = true;
        protected IView _view;
        protected Player _player;
        protected Material _material;
        protected float _startSpeed;
        protected int _interval = 10;
        protected int _deadInterval = 1;
        protected bool _isHole = false;

        #endregion


        #region UnityMethods

        private void Start()
        {
            ((IAction)this).Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            _player = other.GetComponent<Player>();
            Interaction();
            if (!_isHole)
            {
                OnDestroyChange?.Invoke(this);
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods

        protected abstract void Interaction();

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                _material = GetComponent<Renderer>().material;
                _material.SetFloat("_Mode", 2.0f);
                renderer.material.color = Random.ColorHSV();
            }
        }

        public void Initialization(IView view)
        {
            _view = view;
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }

        #endregion
    }
}
