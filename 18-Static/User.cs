namespace _18_Static
{
    public class User
    {
        public static int TotalUsers = 0;
        public string Name { get; set; }
        public int Id { get; set; }

        public User()
        {
            TotalUsers++;
        }
    }
}
