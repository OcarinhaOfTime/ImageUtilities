using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.Commands {
    class ProportionalyHeightCommand : CommandBase{
        int height;

        public override void Execute() {
            Console.WriteLine("Type the desired height: ");
            base.IntFromConsole(ref height);
            base.MassImageOperation(ResizeWidth);
        }

        void ResizeWidth(ImageProcessor imageProcessor) {
            imageProcessor.ResizeHeightProportinaly(height);
        }
    }
}
