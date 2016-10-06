using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class InfinityResizeCommand : CommandBase{
        int x, y;

        public override void Execute() {
            Console.WriteLine("enter the width and height that you wanna the image to be infinitely resized to: ");
            base.IntFromConsole(ref x, ref y);
            base.MassImageOperation(Resizer);
        }

        void Resizer(ImageProcessor imageProcessor) {           
            if(imageProcessor.GetWidth() >= x && imageProcessor.GetHeight() >= y)
                imageProcessor.ToInfinityAndBeyond(x, y);

            Console.WriteLine(imageProcessor.GetName() + ": "+imageProcessor.GetWidth() + ", "+imageProcessor.GetHeight());
            Console.WriteLine(imageProcessor.GetName()+"was infinitely resized");
        }
    }
}
