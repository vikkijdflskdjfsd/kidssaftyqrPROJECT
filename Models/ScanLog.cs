namespace KidsSafetyQR.Models
{
    public class ScanLog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime ScanTime { get; set; } = DateTime.Now;
        public string DeviceInfo { get; set; }
    }
}
