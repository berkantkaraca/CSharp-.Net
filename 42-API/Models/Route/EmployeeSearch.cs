namespace _42_API.Models.Route
{
    //routedaki parametreleri azaltmak adına model oluşturduk, model binding yapıldı
    public class EmployeeSearch
    {
        public string? Gender { get; set; }
        public string? Department { get; set; }
        public string? City { get; set; }
    }
}
