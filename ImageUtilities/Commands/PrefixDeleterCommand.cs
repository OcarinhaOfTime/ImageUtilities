using System;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.Commands {
    class PrefixDeleterCommand : CommandBase{
        string prefix;
        public override void Execute() {
            Console.WriteLine("Type the prefix that you wanna to remove:");
            prefix = Console.ReadLine();
            base.RecursiveOperationThrougthFiles(DeletePrefix);            
        }

        void DeletePrefix(string file){
            RenameUtilities ru = new RenameUtilities();
            ru.SetFile(file);
            if(ru.fileName.HasPrefix(prefix))
                ru.Rename(ru.fileName.Replace(prefix, ""));
        }
    }
}
