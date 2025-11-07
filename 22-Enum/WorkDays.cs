namespace _22_Enum
{
    //[Flags] eskiden bunu tanımlayıp yapılıyomuş
    public enum WorkDays
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    public class Schedule
    {
        public WorkDays WorkDays { get; set; }

        public void PrintSchedule()
        {
            Console.WriteLine($"{WorkDays}");
        }
    }
}
