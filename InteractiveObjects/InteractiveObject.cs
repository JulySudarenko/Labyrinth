using UnityEngine;
using Random = UnityEngine.Random;


namespace Labyrinth
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        #region Field

        public bool IsFly;

        protected PlayerBase _player;
        protected Color _color;
        protected Renderer _renderer;
        protected Collider _collider;

        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float ActiveDis;
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Bonus.png", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
            #if UNITY_EDITOR
            Transform t = transform;

            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            var flat = new Vector3(ActiveDis, 0, ActiveDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5);
            #endif
        }

        #endregion


        #region Methods

        protected abstract void Interaction();

        #endregion
    }
}
