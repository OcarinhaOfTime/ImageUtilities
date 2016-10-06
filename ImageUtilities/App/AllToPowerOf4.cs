namespace ImageUtilities.App {
    class AllToPowerOf4 {
        public static void Execute() {
            View view = new View();

            //string dir = view.GetFolderPathDialog2();
            //IOUtilities ioHandler = new IOUtilities();
            //ioHandler.RecursiveOperationThrougthImages(dir, ToPowerOf4);
            ToPowerOf4(view.GetFilePathDialog());

        }

        static void ToPowerOf4(string file) {
            ImageProcessor image = new ImageProcessor();
            image.SetImage(file);
            if(image.GetWidth() > 1024)
                image.ResizeWidthProportinaly(1024);
            
            image.SaveImage();
        }
    }
}
