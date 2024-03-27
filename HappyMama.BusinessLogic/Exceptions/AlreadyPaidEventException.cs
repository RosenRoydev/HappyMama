namespace HappyMama.BusinessLogic.Exceptions
{
    public class AlreadyPaidEventException : Exception
    {
        public AlreadyPaidEventException()
        {
            
        }

        public AlreadyPaidEventException(string message) :base(message)
        {
            
        }
    }
}
