using UnityEngine;


namespace Labyrinth
{
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _player;
        
        private void Start()
        {
            _player = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0.0f, 5.0f, 0.0f);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            GetComponent<Camera>().targetTexture = rt;
        }

        private void LateUpdate()
        {
            var newPosition = _player.position;
            newPosition.y = transform.position.y;
            newPosition.z = transform.position.z + 6.0f;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}