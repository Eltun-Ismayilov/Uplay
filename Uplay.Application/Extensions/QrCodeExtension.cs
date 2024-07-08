using Microsoft.AspNetCore.Http;
using SkiaSharp.QrCode;
using SkiaSharp;

namespace Uplay.Application.Extensions
{
    public static class QrCodeExtension
    {
        public static IFormFile GenerateQr(string qrUrl)
        {
            byte[] qrImageByteArray;
            using (var generator = new QRCodeGenerator())
            {
                var qr = generator.CreateQrCode(qrUrl, ECCLevel.L);
                var info = new SKImageInfo(350, 350);
                using (var surface = SKSurface.Create(info))
                {
                    var canvas = surface.Canvas;
                    canvas.Render(qr, info.Width, info.Height);
                    var route = Directory.GetCurrentDirectory();
                    string url = Path.Combine(route, "wwwroot\\Images", "Group.jpg");
                    using (var inputStream = System.IO.File.OpenRead(url))
                    using (var image = surface.Snapshot())
                    using (var originalBitmap = SKBitmap.Decode(inputStream))
                    {
                        var resizedBitmap = originalBitmap.Resize(new SKImageInfo(50, 50), SKFilterQuality.High);
                        var x = (info.Width - resizedBitmap.Width) / 2;
                        var y = (info.Height - resizedBitmap.Height) / 2;
                        canvas.DrawBitmap(resizedBitmap, x, y);
                    }
                    using (var image = surface.Snapshot())
                    using (var data = image.Encode(SKEncodedImageFormat.Jpeg, 100))
                        qrImageByteArray = data.ToArray();
                }
            }

            var stream = new MemoryStream(qrImageByteArray);

            IFormFile formFile = new FormFile(stream, 0, qrImageByteArray.Length, "qrCode", "qrCode.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            return formFile;
        }
    }
}
