﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI
{
    public class Helper
    {
        public static SaveImageModel PrepareSaveImage(string imgPath)
        {
            SaveImageModel saveImage = null;

            try
            {
                if (string.IsNullOrEmpty(imgPath))
                {
                    return null;
                }

                if (File.Exists(imgPath))
                {
                    saveImage = new SaveImageModel();

                    saveImage.OriginalImageBytes = File.ReadAllBytes(imgPath);
                    saveImage.OriginalImage = Image.FromFile(imgPath);

                    if (saveImage.OriginalImage.Width > Properties.Settings.Default.ResizedImageWidth)
                    {
                        MemoryStream ms = new MemoryStream();

                        saveImage.ResizedImage = ResizeImage(saveImage.OriginalImage, new Size(Properties.Settings.Default.ResizedImageWidth,
                                                                                               Properties.Settings.Default.ResizedImageHeight));
                        saveImage.ResizedImage.Save(ms, saveImage.OriginalImage.RawFormat);
                        saveImage.ResizedImageBytes = ms.ToArray();

                        if (saveImage.ResizedImage.Width > Properties.Settings.Default.CroppedImageWidth &&
                            saveImage.ResizedImage.Height > Properties.Settings.Default.CroppedImageHeight)
                        {
                            int croppedXPosition = (saveImage.ResizedImage.Width - Properties.Settings.Default.CroppedImageWidth) / 2;
                            int croppedYPosition = (saveImage.ResizedImage.Height - Properties.Settings.Default.CroppedImageHeight) / 2;

                            saveImage.CroppedImage = CropImage(saveImage.ResizedImage, new Rectangle(croppedXPosition, croppedYPosition,
                                                                                                     Properties.Settings.Default.CroppedImageWidth,
                                                                                                     Properties.Settings.Default.CroppedImageHeight));
                            saveImage.CroppedImage.Save(ms, saveImage.OriginalImage.RawFormat);
                            saveImage.CroppedImageBytes = ms.ToArray();
                        }
                        else
                        {
                            MessageBox.Show("Slika ne zadovoljava minimalne dimenzije!" + " " + Properties.Settings.Default.ResizedImageWidth + "x" + Properties.Settings.Default.ResizedImageHeight + ".",
                                            "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            saveImage = null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Odabrana slika ne postoji!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saveImage = null;
                }
            }
            catch
            {
                saveImage = null;
            }

            return saveImage;
        }

        private static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercentW = size.Width / (float)sourceWidth;
            float nPercentH = size.Height / (float)sourceHeight;
            float nPercent;

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return bmpCrop;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}