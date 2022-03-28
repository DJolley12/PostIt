public class NullException : Exception
{
    public NullException(string name) 
        : base($"{name} cannot be null")
    {
    }
}
