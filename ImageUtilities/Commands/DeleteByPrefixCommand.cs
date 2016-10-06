using System;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.Commands {
    class DeleteByPrefixCommand : CommandBase{
        string prefix;

        public override void Execute() {
            Console.WriteLine("enter the prefix of the files dat you want to delete:");
            prefix = Console.ReadLine();
            base.RecursiveOperationThrougthFiles(Deleter);
        }

        void Deleter(string file) {
            string name = Path.GetFileName(file);
            if(name.HasPrefix(prefix)) {
                File.Delete(file);
                Console.WriteLine(name+" was deleted");
            }
        }
    }
}
