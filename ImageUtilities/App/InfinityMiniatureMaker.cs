using System;

namespace ImageUtilities.App {
    class InfinityMiniatureMaker {
        public static void Execute() {
            
            IOUtilities ioHandler = new IOUtilities();
            View view = new View();

            string dir = view.GetFolderPathDialog2();
            ioHandler.RecursiveOperationThrougthImages(dir, ToInfinityAndBeyond, "_main");
        }

        public static void ToInfinityAndBeyond(string file) {
            ImageProcessor image = new ImageProcessor();
            image.SetImage(file);

            image.ToInfinityAndBeyond(1024 / 4, 768 / 4);

            string imageName = image.GetName().Replace("_main", "_miniature");
            Console.WriteLine("imageName: "+imageName);
            image.SetName(imageName);
            image.SaveImage();
        }
    }
}
