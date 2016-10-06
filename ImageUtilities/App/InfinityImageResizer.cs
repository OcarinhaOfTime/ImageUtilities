using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.App {
    class InfinityImageResizer {
        public static void Execute() {
            View view = new View();
            string dir = view.GetFolderPathDialog2();

            IOUtilities util = new IOUtilities();
            util.RecursiveOperationThrougthImages(dir, Resize);

            //string hue = view.GetFilePathDialog();
            //Resize(hue);
        }

        static void Resize(string file) {
            ImageProcessor imageProcessor = new ImageProcessor();
            imageProcessor.SetImage(file);
            if(imageProcessor.GetWidth() < 1024 || imageProcessor.GetHeight() < 768)
                return;
            imageProcessor.ResizeWidthProportinaly(1024);

            if(imageProcessor.GetHeight() > 768)
                imageProcessor.ResizeHeightProportinaly(768);

            imageProcessor.ExpandImage(1024, 768);
            imageProcessor.SaveImage();
        }
    }
}
