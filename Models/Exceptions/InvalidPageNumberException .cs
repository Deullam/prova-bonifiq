namespace ProvaPub.Models
{
    public class InvalidPageNumberException : Exception
    {
        public InvalidPageNumberException() : base("The page number must be greater than zero.")
        {
        }
    }
}
