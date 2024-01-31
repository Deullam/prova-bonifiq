namespace ProvaPub.Models
{
    public class InvalidPageNumberException : Exception
    {
        public InvalidPageNumberException() : base("O número da página deve ser maior que zero.")
        {
        }
    }
}
