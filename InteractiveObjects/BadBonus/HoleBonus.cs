using UnityEngine;
using System;


namespace Labyrinth
{
    public sealed class HoleBonus : InteractiveObject
    {
        public event Action<string, Color> OnCaughtPlayerChange = delegate(string str, Color color) { };
 
        protected override void Interaction()
        {
            OnCaughtPlayerChange?.Invoke(gameObject.name, _color);
        }

        // public override void Execute()
        // {
        //     if (!IsInteractable)
        //     {
        //         return;
        //     }
        // }
    }
}
