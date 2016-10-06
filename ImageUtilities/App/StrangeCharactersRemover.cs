using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.App {
    class StrangeCharactersRemover {
        public static void Execute() {
            View view = new View();

            string directory = view.GetFolderPathDialog();
            Remover(directory);
        }

        static void Remover(string dir) {
            string[] folders = Directory.GetDirectories(dir);
            foreach(string folder in folders)
                Remover(folder);

            string[] files = Directory.GetFiles(dir);
            foreach(string file in files)
                Remove(file);

        }

        static void Remove(string file) {
            try {
                File.Move(file, file.RemoveStrangeCharacters());
            }
            catch(System.IO.DirectoryNotFoundException e) {
                Console.WriteLine("the file: "+file+" was not found");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
            Console.WriteLine("Adjusted "+Path.GetFileName(file)+", to"+Path.GetFileName(file.RemoveStrangeCharacters()));
            //Console.ReadKey();
        }
    }
}
