using System;


namespace Labyrinth
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}
