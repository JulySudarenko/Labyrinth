

namespace Labyrinth
{
    public sealed partial class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
            Jump();
        }
    }
}
