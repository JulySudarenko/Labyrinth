using UnityEngine;


namespace Labyrinth
{
    public class CameraController : MonoBehaviour
    {
        #region Field

        public Player Player;
        private Vector3 _offset;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void LateUpdate()
        {
            if (Player)
            {
                transform.position = Player.transform.position + _offset;
            }
        }

        #endregion
    }
}
