using UnityEngine;
using System;


namespace Labyrinth
{
    public sealed class HoleBonus : InteractiveObject
    {
        #region Fields
        public event Action<string, Color> OnCaughtPlayerChange = delegate(string str, Color color) {  };
        // private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        // public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        // {
        //     add { _caughtPlayer += value; }
        //     remove { _caughtPlayer -= value; }
        // }

        #endregion
          
        
        #region Methods

        protected override void Interaction()
        {
            //_isHole = true;
            // _player.GetComponent<Collider>().enabled = false;
            // _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_color));
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public override void Execute()
        {
            if(!IsInteractable){return;}
        }
        #endregion
    }
}
