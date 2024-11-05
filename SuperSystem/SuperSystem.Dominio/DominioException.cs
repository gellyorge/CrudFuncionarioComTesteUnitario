namespace SuperSystem.Dominio
{
    public class DominioException : Exception
    {
        public DominioException(string message) : base(message) 
        {

        }
        public static void when(bool hasError, string message) 
        {
            if (hasError) 
            {
                throw new DominioException(message);
            }
        }
    }
}
