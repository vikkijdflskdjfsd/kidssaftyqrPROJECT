using Microsoft.AspNetCore.Mvc;
using QRCoder;
using KidsSafetyQR.Controllers;
using KidsSafetyQR.Data;
using KidsSafetyQR.Models;

namespace KidsSafetyQR.Controllers
{
    public class QRController : Controller
    {
        private readonly AppDbContext _context;

        public QRController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Generate(string code)
        {
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            string url = $"{baseUrl}/QR/Details/{code}";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var data = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(data);

            return File(qrCode.GetGraphic(20), "image/png");
        }
        public IActionResult Details(string code)
        {
            var kid = _context.Kids.FirstOrDefault(x => x.Code == code);
            return View(kid);
        }
        [HttpPost]
        public IActionResult SendAlert(string code)
        {
            var kid = _context.Kids.FirstOrDefault(x => x.Code == code);

            if (kid != null)
            {
                // future: SMS API call
                // abhi log save kar dete hain

                _context.ScanLogs.Add(new ScanLog
                {
                    Code = code,
                    ScanTime = DateTime.Now,
                    DeviceInfo = "ALERT TRIGGERED"
                });

                _context.SaveChanges();
            }

            return Json(new { success = true });
        }
    }
}