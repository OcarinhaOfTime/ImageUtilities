using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class MassResizeCommand : CommandBase {
        int x, y;

        public override void Execute() {
            Console.WriteLine("enter the width and height that you wanna the image to be resized to: ");
            base.IntFromConsole(ref x, ref y);
            base.MassImageOperation(Resizer);
        }

        void Resizer(ImageProcessor imageProcessor) {
            imageProcessor.Resize(x, y);
            Console.WriteLine(imageProcessor.GetName() + "was resizeded");
        }
    }
}
