using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace SecretSanta.Core.Services;

public class ImageConversion
{
    public static string ToBase64(string ImagePath)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Convert image path to Base 64 image
            using (var image = System.Drawing.Image.FromFile(ImagePath))
            {
                using (var stream = new MemoryStream())
                {
                    // Inserted image to MemorySteam
                    image.Save(stream, image.RawFormat);
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }
        return ImagePath;
    }
}