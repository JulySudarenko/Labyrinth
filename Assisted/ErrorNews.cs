using System;


namespace Labyrinth
{
    public sealed class ErrorNews : Exception
    {
        public ErrorNews(string message) : base(message)
        {

        }
    }
}
