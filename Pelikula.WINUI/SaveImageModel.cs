using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelikula.WINUI
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
