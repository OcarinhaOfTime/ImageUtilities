using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class PowerOf4Command : CommandBase {
        public override void Execute() {
            base.MassImageOperation(ToPowerOf4);
        }

        void ToPowerOf4(ImageProcessor imageProcessor) {
            imageProcessor.ResizeToPowerOf4();
            Console.WriteLine(imageProcessor.GetName()+" was resized to has a power of 4 size");
        }
    }
}
