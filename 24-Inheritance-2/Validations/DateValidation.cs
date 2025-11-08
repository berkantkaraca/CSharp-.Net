using _24_Inheritance_2.Exceptions;

namespace _24_Inheritance_2.Validations
{
    //Helper class: static olmalı bu yüzden. instance oluşturulmaya gerek yok
    public static class DateValidation
    {
        public static DateTime CheckDate(DateTime date)
        {
            if (DateTime.Now <= date)
                return date;
            else
                throw new ValidationException("Tarih alanı doğrulanamadı");
        }
    }
}
