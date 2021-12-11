using System.Drawing;

namespace Pelikula.WINUI.Helpers
{
    public class SaveImageModel
    {
        public byte[] OriginalImageBytes { get; set; }

        public Image OriginalImage { get; set; }

        public byte[] ResizedImageBytes { get; set; }

        public Image ResizedImage { get; set; }

        public byte[] CroppedImageBytes { get; set; }

        public Image CroppedImage { get; set; }
    }
}
