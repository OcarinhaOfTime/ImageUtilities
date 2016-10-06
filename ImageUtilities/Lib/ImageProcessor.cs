using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImageUtilities.Extentions;
using ImageProcessor.Imaging;

namespace ImageUtilities
{
    public class ImageProcessor
    {
        Stream imageStream;
        Bitmap image;
        float ratio;
        string imagePath;
        string imageName;

        public void SetImage(string path)
        {
            image = LoadBitmap(path);
            imagePath = path;
            imageName = Path.GetFileName(path);
            Console.WriteLine(imageName);
            ratio = image.Width < image.Height ? (float)image.Width / (float)image.Height : (float)image.Height / (float)image.Width;
        }

        public void Resize(int width, int height)
        {
            Resizer resizer = new Resizer(new Size(width, height));
            image = resizer.ResizeImage(image);
        }

        public void ResizeWidthProportinaly(int width)
        {
            Resize(width, (int)(width * ratio));
        }

        public void ResizeHeightProportinaly(int height)
        {
            Resize((int)(height * ratio), height);
        }

        public void ExpandImage(int width, int height)
        {
            Bitmap blank = new Bitmap(width, height);
            Graphics canvas = Graphics.FromImage(blank);
            Pen pen = new Pen(Color.White, width);
            
            canvas.DrawRectangle(pen, 0,0,width, height);
            int x = (width - image.Width) / 2;
            int y = (height - image.Height) / 2;
            canvas.DrawImage(image, x, y, image.Width, image.Height);

			image.Dispose ();
			imageStream.Close ();
            image = blank;
        }

        public void SaveImage(string directory)
        {
            string path = directory + "\\" + imageName;

            imageStream.Close();
            try {
                image.Save(path);
                image.Dispose();
            }
            catch(Exception e) {
				Console.WriteLine(e.Message);
                Image toSave = new Bitmap(image);
                image.Dispose();
                toSave.Save(path);
            }
        }

        public void SaveImage() {
            SaveImage(Path.GetDirectoryName( imagePath));
        }

        public void ResizeToPowerOf4() {
            Resize(image.Width.NearestPowerOf4(), image.Height.NearestPowerOf4());
        }

        public void ToInfinityAndBeyond(int width, int height) {
            if(width < image.Width)
                ResizeWidthProportinaly(width);
            if(height < image.Height)
                ResizeHeightProportinaly(height);

           ExpandImage(width, height);
        }

        public Color GetPixel(int x, int y) {
            return image.GetPixel(x, y);
        }

        public void CropImage(int x1, int y1, int x2, int y2) {
            Bitmap cropped = new Bitmap(x2 - x1, y2 - y1);
            Graphics canvas = Graphics.FromImage(cropped);
            Rectangle dest = new Rectangle(0, 0, cropped.Width, cropped.Height);
            Rectangle src = new Rectangle(x1, y1, cropped.Width, cropped.Height);
            canvas.DrawImage(image, dest, src,GraphicsUnit.Pixel);

            image.Dispose();
            image = cropped;
        }

        Bitmap LoadBitmap(string path) {
            imageStream = File.Open(path, FileMode.Open);
            return new Bitmap(imageStream);
        }

        #region GettersAndSetters
        public void SetName(string imageName) {
            this.imageName = imageName;
        }

        public string GetName() {
            return imageName;
        }

        public int GetWidth() {
            return image.Width;
        }

        public int GetHeight() {
            return image.Height;
        } 
        #endregion
    }
}
