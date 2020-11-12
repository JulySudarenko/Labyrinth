using System;


namespace Labyrinth
{
    public sealed class ErrorNews : Exception
    {
        public float LowerLimit { get; }
        public float UpperLimit { get; }
        public ErrorNews(string message, float lowerLimit, float upperLimit) : base(message)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
