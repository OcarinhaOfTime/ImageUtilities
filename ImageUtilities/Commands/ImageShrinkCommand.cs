using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class ImageShrinkCommand : CommandBase{
        int x;

        public override void Execute() {
            Console.WriteLine("enter the size that you wanna the image to be shrinked to: ");
            base.IntFromConsole(ref x);
            base.MassImageOperation(Resizer);
        }

        void Resizer(ImageProcessor imageProcessor) {
            if(imageProcessor.GetWidth() < x || imageProcessor.GetHeight() < x)
                return;
            if(imageProcessor.GetWidth() > imageProcessor.GetHeight())               
                imageProcessor.ResizeWidthProportinaly(x);
            else
                imageProcessor.ResizeHeightProportinaly(x);

            imageProcessor.ResizeToPowerOf4();
            Console.WriteLine(imageProcessor.GetName() + "was resized");
        }
    }
}
