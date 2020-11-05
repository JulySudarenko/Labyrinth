using System.Data;
using UnityEngine;
using static UnityEngine.Debug;


namespace Labyrinth
{
    public class CameraController : IExecute
    {
        #region Field

        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;
        // private float _bottomPosition = 9.0f;
        // private float _topPosition = 9.5f;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }
        
        #endregion

        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }

        // #region UnityMethods
        //
        // private void Start()
        // {
        //     if (Player == null)
        //     {
        //         throw new DataException($"Player not found");
        //     }
        //
        //     try
        //     {
        //         _offset = transform.position - Player.transform.position;
        //         if ((_offset.y < _bottomPosition) || (_offset.y > _topPosition))
        //             throw new ErrorNews("Check camera position", _bottomPosition, _topPosition);
        //     }
        //     catch (ErrorNews e)
        //     {
        //         Log($"{e}, {_bottomPosition}, {_topPosition}");
        //     }
        // }
        //
        //
        //
        // #endregion
    }
}
