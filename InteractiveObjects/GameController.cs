using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Labyrinth
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        #region Field

        private List<InteractiveObject> _interactiveObjects;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            var displayBonuses = new DisplayBonuses();
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        #endregion


        #region Methods

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
        }

        #endregion
    }
}
