using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        #region Field

        protected PlayerBase _player;
        protected Color _color;

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
        }

        #endregion


        #region Methods

        protected abstract void Interaction();
        public abstract void Execute();

        #endregion
    }
}
