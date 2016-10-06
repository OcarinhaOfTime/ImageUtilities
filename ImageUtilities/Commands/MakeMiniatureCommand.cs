using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageUtilities.Extentions;

namespace ImageUtilities.Commands {
    class MakeMiniatureCommand : CommandBase {
        int x, y;

        public override void Execute() {
            Console.WriteLine("enter the width and height of the miniatures: ");
            base.IntFromConsole(ref x, ref y);
            base.MassImageOperation(Resizer);
        }

        void Resizer(ImageProcessor imageProcessor) {
			string name = imageProcessor.GetName ();
			if (!name.HasPrefix ("_main"))
				return;
            imageProcessor.ToInfinityAndBeyond(x, y);
            string imageName = imageProcessor.GetName().Replace("_main", "_miniature");
            imageProcessor.SetName(imageName);
            Console.WriteLine(imageName+" miniature was created");
        }
    }
}
