namespace _24_Inheritance_2.Exceptions
{
    public class ValidationException : Exception
    {
        public string PropertName { get; private set; }
        public ValidationException()
        {

        }
        public ValidationException(string message) : base(message + " Date: " + DateTime.Now)
        {
        }
        public ValidationException(string message, string propertyName) : base(message + " Date: " + DateTime.Now)
        {
            PropertName = propertyName;
        }
    }
}
