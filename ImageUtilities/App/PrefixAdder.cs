using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities.App
{
    class PrefixAdder
    {
        public static void execute()
        {
            while (true)
            {
                View view = new View();
                string file = view.GetFilePathDialog();
                RenameUtilities renamer = new RenameUtilities();
                renamer.SetFile(file);
                renamer.AddOrRemovePrefix("_main ");
            }
        }
    }
}
