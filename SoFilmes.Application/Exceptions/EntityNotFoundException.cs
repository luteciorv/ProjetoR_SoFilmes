namespace SoFilmes.Application.Exceptions
{
    public class EntityNotFoundException : ExceptionBase
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
