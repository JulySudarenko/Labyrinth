using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute//IInteractable, IExecute//IComparable<InteractiveObject>
    {
        #region Field

        //public event Action<InteractiveObject> OnDestroyChange;

        //public bool IsInteractable { get; } = true;
        protected IView _view;
        protected PlayerBase _player;
        protected Color _color;
        protected Material _material;
        // protected float _startSpeed;
        // protected int _interval = 10;
        // protected int _deadInterval = 1;
        // protected bool _isHole = false;
        private bool _isInteractable;

        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }
        
        
        #endregion


        #region UnityMethods

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
            //((IAction)this).Action();
            //Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            _player = other.GetComponent<PlayerBase>();
            Interaction();
            IsInteractable = false;

            // if (!_isHole)
            // {
            //     OnDestroyChange?.Invoke(this);
            //     Destroy(gameObject);
            // }
        }

        #endregion


        #region Methods

        protected abstract void Interaction();
        public abstract void Execute();
        
        //void IAction.Action()
        private  void Action()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                _material = GetComponent<Renderer>().material;
                _material.SetFloat("_Mode", 2.0f);
                renderer.material.color = _color;
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
        //
        // public int CompareTo(InteractiveObject other)
        // {
        //     return name.CompareTo(other.name);
        // }
        //
        // IEnumerator DeadTime(int _interval)
        // {
        //     yield return new WaitForSeconds(_interval);
        //     
        // }
        

        #endregion
    }
}
