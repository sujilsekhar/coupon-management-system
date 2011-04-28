using System;

namespace Core
{
    [Serializable]
    public class sArtException : Exception
    {
        public sArtException(string message)
            : base(message)
        {
        }
    }
}