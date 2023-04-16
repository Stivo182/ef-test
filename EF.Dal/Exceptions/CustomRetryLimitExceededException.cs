
namespace EF.Dal.Exceptions
{
    public class CustomRetryLimitExceededException : CustomException
    {
        public CustomRetryLimitExceededException() { }
        public CustomRetryLimitExceededException(string message): base(message) { }
        public CustomRetryLimitExceededException(string message, Exception innerException): base(message, innerException) { }
    }
}
