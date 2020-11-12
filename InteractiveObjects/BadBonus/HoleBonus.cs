using UnityEngine;


namespace Labyrinth
{
    public sealed class HoleBonus : InteractiveObject
    {
        protected override void Interaction()
        {
            _isHole = true;
            _player.GetComponent<Collider>().enabled = false;
        }
    }
}
