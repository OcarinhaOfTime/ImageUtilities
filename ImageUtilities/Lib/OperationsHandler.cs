using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUtilities
{
    class OperationsHandler
    {
        public void MassResizeTo1024x768()
        {
            MassResize(1024, 768);
        }

        public void MakeMiniature320x240()
        {
            MassResize(320, 240);
        }

        public void MassResize(int width, int height)
        {
            View view = new View();
            MassImageOperations massImageOperations = new MassImageOperations();
            string directorySrc = view.GetFolderPathDialog();
            string directoryDest = view.GetFolderPathDialog();
            massImageOperations.MassResize(directorySrc, directoryDest, width, height);
        }

        public void GetXml()
        {
            View view = new View();
            MassImageOperations massImageOperations = new MassImageOperations();
            string directorySrc = view.GetFolderPathDialog();
            string[] xmls = massImageOperations.NameToXML(directorySrc);
            foreach (string xml in xmls)
                Console.WriteLine(xml);

            Console.ReadLine();
        }

        public void EndMessage()
        {
            Console.WriteLine("That's all folks");
            Console.ReadLine();
        }

        public void ToInfinityAndBeyond()
        {
            View view = new View();
            MassImageOperations massImageOperations = new MassImageOperations();
            string directorySrc = view.GetFolderPathDialog();
            string directoryDest = view.GetFolderPathDialog();
            massImageOperations.MassImageToInfinity(directorySrc, directoryDest);
        }

        public void RenameFile(string path, string newName)
        {
            System.IO.File.Move(path, newName);
        }

        public void MassTecidoRename()
        {
            View view = new View();
            MassImageOperations massImageOperations = new MassImageOperations();
            string directorySrc = view.GetFolderPathDialog();
            massImageOperations.MassTecidoRename(directorySrc);
        }

        public void MassXMLProp()
        {
            View view = new View();
            MassImageOperations massImageOperations = new MassImageOperations();
            string directorySrc = view.GetFolderPathDialog();
            massImageOperations.MassImageXMLProp(directorySrc);
        }
    }
}
