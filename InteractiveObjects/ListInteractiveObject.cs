using System;
using System.Collections;
using Object = UnityEngine.Object;


namespace Labyrinth
{
    public sealed class ListInteractiveObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private InteractiveObject _current;
        private int _index = -1;

        public ListInteractiveObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }
        
        public int Count => _interactiveObjects.Length;
        
        public void AddInteractiveObject(InteractiveObject interactive)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] {interactive};
                return;
            }

            Array.Resize(ref _interactiveObjects, Count + 1);
            _interactiveObjects[Count - 1] = interactive;
        }

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }


        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
