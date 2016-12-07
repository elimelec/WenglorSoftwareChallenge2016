using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Image
{
    /// <summary>
    /// A wrapper over System.Drawing.Bitmap that provides easier access to rotate and remap methods. 
    /// </summary>
    class BitmapImage
    {
        public Bitmap bitmap { get; set; }

        /// <summary>
        /// Initialize an instance and loads a bitmap image from the specified path.
        /// </summary>
        /// <param name="path">The path where the bitmap image will be loaded from.</param>
        public BitmapImage(string path)
        {
            bitmap = new Bitmap(path);
        }

        /// <summary>
        /// Rotates, flips, or rotates and flips the image.
        /// </summary>
        public void Rotate(RotateFlipType rotateType)
        {
            bitmap.RotateFlip(rotateType);
        }

        /// <summary>
        /// Remaps the colors of the image according to the <paramref name="remapTable"/>.
        /// </summary>
        public void RemapColors(ColorMap[] remapTable)
        {
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            var g = Graphics.FromImage(bitmap);
            g.DrawImage(
                bitmap,
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                0, 0, bitmap.Width, bitmap.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
            g.Dispose();
        }

        /// <summary>
        /// Saves the image in <c>ImageFormat.Bmp</c> format.
        /// </summary>
        /// <param name="path">The path where the image will be saved.</param>
        public void Save(string path)
        {
            bitmap.Save(path, ImageFormat.Bmp);
        }
    }
}
