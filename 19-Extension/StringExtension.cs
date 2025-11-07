namespace _19_Extension
{
    public static class StringExtension //static olmak zorunda
    {
        //string işlemlerine tersten yazan işlemi eklemek istediğinde kullanabilirsin
        public static string ReverseString(this string str) //this kısmı parametre değildir. hangi class'ı ezeceğini ve geliştireceğini belirtirsin. eğer parametre eklemek istersen bu ifadeden sonrasına yaz
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        } 

        //Metnin ilk harfini büyüten extension
        public static string CapitalizeFirstLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
