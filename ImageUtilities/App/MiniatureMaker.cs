using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.App
{
    class MiniatureMaker
    {
        public static void execute()
        {
            View view = new View();
            string path = view.GetFilePathDialog();
            string root = Path.GetDirectoryName(path);
            Console.WriteLine(root);
            foreach (string segs in Directory.GetDirectories(root))
                foreach(string cats in Directory.GetDirectories(segs))
                    foreach(string prods in Directory.GetDirectories(cats))
                        FindMain(prods);

            Console.WriteLine("Done!!!");
        }

        static void FindMain(string productFolder)
        {
            foreach (string product in IOUtilities.GetAllImagesInADirectory(productFolder))
            {
                //Console.WriteLine("not filtered: "+Path.GetFileName(Path.GetDirectoryName(product)));
                string productName = Path.GetFileName(product);
                if (productName.HasPrefix("_main"))
                    MakeMiniature(product);
                
            }
        }

        static void MakeMiniature(string mainPath)
        {
            ImageProcessor image = new ImageProcessor();
            string miniatureName = Path.GetFileName(mainPath).Replace("_main", "_miniature");
            string directoryName = Path.GetDirectoryName(mainPath);
            /*Console.WriteLine("miniatureName: " + miniatureName);
            Console.WriteLine("directoryName: " + directoryName);
             * */
            
            image.SetImage(mainPath);
            image.Resize(320, 320);
            image.SetName(miniatureName);
            image.SaveImage(directoryName);
            Console.WriteLine("miniature created: " + Path.GetFileName(directoryName));
        }
    }
}
