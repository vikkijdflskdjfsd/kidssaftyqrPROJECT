namespace KidsSafetyQR.Models
{
    public class Kid
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? School { get; set; }
        public string? ParentPhone { get; set; }
        public string? Code { get; set; }
        public bool? IsLost { get; set; }
    }
}
