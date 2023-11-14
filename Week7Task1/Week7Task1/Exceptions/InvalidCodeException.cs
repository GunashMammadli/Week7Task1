namespace Week7Task1.Exceptions
{
    internal class InvalidCodeException : Exception
    {
        public InvalidCodeException()
        {
        }

        public InvalidCodeException(string? message) : base(message)
        {
        }
    }
}
