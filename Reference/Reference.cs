using UnityEngine;
using UnityEngine.UI;


namespace Labyrinth
{
    public sealed class Reference
    {
        private Camera _mainCamera;


        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}