namespace _19_Extension
{
    public static class ExceptionExtensions
    {
        public static string GetFriendlyMessage(this Exception exception)
        {
            return $"Error: {exception.Message}\n Date: {DateTime.Now}";
        }
    }
}
