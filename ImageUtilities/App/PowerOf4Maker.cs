using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageUtilities.Extentions;

namespace ImageUtilities.App {
    class PowerOf4Maker {
        public static void Execute() {
            View view = new View();
            string dir = view.GetFolderPathDialog();
            MassImageOperations miops = new MassImageOperations();
            miops.MassImageToPowerOf4(dir);
        }

        public static void ExecuteSingle() {
            while (true) {
                View view = new View();
                string path = view.GetFilePathDialog();
                ImageProcessor customImage = new ImageProcessor();
                customImage.SetImage(path);
                int width = customImage.GetWidth();
                int height = customImage.GetHeight();
                customImage.Resize(width.NearestPowerOf4(), height.NearestPowerOf4());
                customImage.SaveImage();
                Console.WriteLine(customImage.GetName() + " done!");
            }
        }
    }
}
