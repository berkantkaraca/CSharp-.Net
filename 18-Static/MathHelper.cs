namespace _18_Static
{
    public class MathHelper
    {
        public static double Pi => Math.PI;
        public static double CalculateCircleArea(double radius)
        {
            return Pi * radius * radius;
        }
    }
}
