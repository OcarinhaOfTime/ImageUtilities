using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class ProportionalyWidthResizeCommand : CommandBase {
        int width;

        public override void Execute() {
            Console.WriteLine("Type the desired width: ");
            base.IntFromConsole(ref width);
            base.MassImageOperation(ResizeWidth);
        }

        void ResizeWidth(ImageProcessor imageProcessor) {
            imageProcessor.ResizeWidthProportinaly(width);
        }
    }
}
