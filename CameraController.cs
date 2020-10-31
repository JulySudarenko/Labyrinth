using System.Data;
using UnityEngine;
using static UnityEngine.Debug;


namespace Labyrinth
{
    public class CameraController : MonoBehaviour
    {
        #region Field

        public Player Player;
        private Vector3 _offset;
        private float _bottomPosition = 9.0f;
        private float _topPosition = 9.5f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            if (Player == null)
            {
                throw new DataException($"Player not found");
            }

            try
            {
                _offset = transform.position - Player.transform.position;
                if ((_offset.y < _bottomPosition) || (_offset.y > _topPosition))
                    throw new ErrorNews("Check camera position", _bottomPosition, _topPosition);
            }
            catch (ErrorNews e)
            {
                Log($"{e}, {_bottomPosition}, {_topPosition}");
            }
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }

        #endregion
    }
}
