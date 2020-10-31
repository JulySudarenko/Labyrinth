using UnityEngine;


namespace Labyrinth
{
    public sealed class HoleBonus : InteractiveObject
    {
        protected override void BackInteraction()
        {
            Debug.Log("Game over");
            _player.Dead();
        }

        protected override void Interaction()
        {
            _isHole = true;
            _player.GetComponent<Collider>().enabled = false;
        }
    }
}
