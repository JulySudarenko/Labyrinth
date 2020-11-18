using UnityEngine;


namespace Labyrinth
{
    public sealed class MiniMap : MonoBehaviour
    {
        [SerializeField] private float _cameraHeight = 5.0f;
        [SerializeField] private float _cameraDeltaPosition = 7.0f;
        private Transform _player;

        private void Start()
        {
            _player = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0.0f, _cameraHeight, 0.0f);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            GetComponent<Camera>().targetTexture = rt;
        }

        private void LateUpdate()
        {
            var newPosition = _player.position;
            newPosition.y = transform.position.y;
            newPosition.z = _player.position.z + _cameraDeltaPosition;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}