using System;


namespace Labyrinth
{
    public sealed class ErrorNews : Exception
    {
        private float LowerLimit { get; }
        private float UpperLimit { get; }
        public ErrorNews(string message, float lowerLimit, float upperLimit) : base(message)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
