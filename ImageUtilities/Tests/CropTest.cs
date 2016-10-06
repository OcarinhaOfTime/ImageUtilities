using System;
using ImageUtilities.Commands;

namespace ImageUtilities.Tests {
    class CropTest : CommandBase{
        public void Crop() {
            string imageFile = base.GetFileDialog();
            ImageProcessor imageProcessor = new ImageProcessor();
            imageProcessor.SetImage(imageFile);
            imageProcessor.CropImage(50, 50, 800, 800);
            imageProcessor.SaveImage();
        }

        public override void Execute() {
            Crop();
        }
    }
}
