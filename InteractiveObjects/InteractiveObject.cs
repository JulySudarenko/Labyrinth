using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        #region Field

        public bool IsFly;

        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float ActiveDis;
        protected PlayerBase _player;
        protected Color _color;
        protected Renderer _renderer;
        protected Collider _collider;

        private bool _isInteractable;

        public bool IsInteractable
        {
            get { return _isInteractable; }
            set
            {
                _isInteractable = value;
                _renderer.enabled = _isInteractable;
                _collider.enabled = _isInteractable;
            }
        }

        #endregion


        #region UnityMethods

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _renderer = GetComponent<Renderer>();
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

        #endregion
    }
}
