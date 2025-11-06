namespace _18_Static
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i]++;
            }

            return new string(chars);
        }

        public static string Decrypt(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i]--;
            }

            return new string(chars);
        }
    }
}
