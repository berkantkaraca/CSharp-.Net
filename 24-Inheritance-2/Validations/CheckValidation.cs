using _24_Inheritance_2.Exceptions;

namespace _24_Inheritance_2.Validations
{
    public static class CheckValidation
    {
        public static string CheckValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value;
            else
                throw new ValidationException("Hata");
        }
    }
}
