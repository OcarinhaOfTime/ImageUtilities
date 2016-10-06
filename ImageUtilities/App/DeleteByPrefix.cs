using System;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.App {
    class DeleteByPrefix {
        public static void ExeCute() {
            View view = new View();
            string dir = view.GetFolderPathDialog2();
            IOUtilities ioHandler = new IOUtilities();
            ioHandler.RecursiveOperationThrougthFiles(dir, Deleter);
        }

        static void Deleter(string file) {
            string name = Path.GetFileName(file);
            if(name.HasPrefix("_miniature")) {
                File.Delete(file);
                Console.WriteLine("Deleted: "+name);
            }
        }
    }
}
