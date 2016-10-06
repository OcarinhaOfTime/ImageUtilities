using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities
{
    class MassImageOperations
    {
        ImageProcessor customImage;

        public MassImageOperations()
        {
            customImage = new ImageProcessor();
        }

        public void MassResize(string directorySrc, string directoryDest, int width, int height)
        {
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);
            foreach (string path in imagePaths)
            {
                customImage.SetImage(path);
                customImage.Resize(width, height);
                customImage.SaveImage(directoryDest);
                Console.WriteLine(customImage.GetName() + " done!");
            }
        }
        public string[] NameToXML(string directorySrc)
        {
            TextUtilities textUtilities = new TextUtilities();
            string[] imageNames = IOUtilities.GetAllNamesOnADirectory(directorySrc);
            string[] xmls = new string[imageNames.Length];
            for (int i = 0; i < imageNames.Length; i++)
                xmls[i] = textUtilities.ConvertToXml(imageNames[i]);

            return xmls;
        }

        public void MassImageToInfinity(string directorySrc, string directoryDest)
        {
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);
            foreach (string path in imagePaths)
            {
                customImage.SetImage(path);
                customImage.ResizeWidthProportinaly(1024);
                customImage.ExpandImage(1024, 768);
                customImage.SaveImage(directoryDest);
                Console.WriteLine(customImage.GetName() + " done!");
            }
        }

        public void MassTecidoRename(string directorySrc)
        {
            RenameUtilities renamer = new RenameUtilities();
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);
            foreach (string path in imagePaths)
            {
                renamer.SetFile(path);
                renamer.RenameTecido();
            }
        }

        public void MassImageXMLProp(string directorySrc)
        {
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);
            foreach (string path in imagePaths)
            {
                Image ima = Bitmap.FromFile(path);
                float ratio;
                if(ima.Height > ima.Width){
                    ratio = (float)ima.Height / (float)ima.Width;
                    Console.WriteLine(Path.GetFileNameWithoutExtension(path) + ImageInfo(ima) + ": " + "15x" + (int)(15 * ratio));
                }
                else if(ima.Height < ima.Width){
                    ratio = (float)ima.Width / (float)ima.Height;
                    Console.WriteLine(Path.GetFileNameWithoutExtension(path)+ ImageInfo(ima)+": "+(int)(15*ratio)+"x15");
                }
            }
        }

        public void MassImagePrefixAdder(string directorySrc, string prefix)
        {
            RenameUtilities renamer = new RenameUtilities();
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);

            foreach (string imagePath in imagePaths)
            {
                renamer.SetFile(imagePath);
                renamer.AddPrefix(prefix);
            }
        }

        public void MassImageToPowerOf4(string directorySrc) {
            string[] imagePaths = IOUtilities.GetAllImagesInADirectory(directorySrc);

            foreach (string path in imagePaths) {
                customImage.SetImage(path);
                int width = customImage.GetWidth();
                int height = customImage.GetHeight();
                customImage.Resize(width.NearestPowerOf4(), height.NearestPowerOf4());
                customImage.SaveImage(directorySrc + "/News");
                Console.WriteLine(customImage.GetName() + " done!");
            }
        }

        string ImageInfo(Image ima)
        {
            return "(width " + ima.Width + " height " + ima.Height + ")";
        }
    }
}
