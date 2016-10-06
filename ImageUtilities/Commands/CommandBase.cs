using System;

namespace ImageUtilities.Commands {
    public delegate void MassImageOperation(ImageProcessor image);
    abstract class CommandBase : ICommand {
        private View view;
        private IOUtilities ioUtilities;
        private ImageProcessor imageProcessor;
        private MassImageOperation massImageOperation;

        abstract public void Execute();

        public CommandBase() {
            view = new View();
            ioUtilities = new IOUtilities();
        }

        protected void RecursiveOperationThrougthFiles(FileOperation fileOperation) {
            string directory = GetFolderDialog();
            ioUtilities.RecursiveOperationThrougthFiles(directory, fileOperation);
        }

        protected void RecursiveOperationThrougthFiles(string directory, FileOperation fileOperation) {
            ioUtilities.RecursiveOperationThrougthFiles(directory, fileOperation);
        }

        protected void RecursiveOperationThrougthImages(FileOperation fileOperation) {
            string directory = GetFolderDialog();
            ioUtilities.RecursiveOperationThrougthImages(directory, fileOperation);
        }

        protected void RecursiveOperationThrougthImages(string directory, FileOperation fileOperation) {
            ioUtilities.RecursiveOperationThrougthImages(directory, fileOperation);
        }

        protected void RecursiveOperationThrougthImages(FileOperation fileOperation, string prefix) {
            string directory = GetFolderDialog();
            ioUtilities.RecursiveOperationThrougthImages(directory, fileOperation, prefix);
        }

        protected void RecursiveOperationThrougthImages(string directory, FileOperation fileOperation, string prefix) {
            ioUtilities.RecursiveOperationThrougthImages(directory, fileOperation, prefix);
        }

        protected string GetFileDialog() {
            return view.GetFilePathDialog();
        }

        protected string GetFolderDialog() {
            return view.GetFolderPathDialog3();
        }

        protected void IntFromConsole(ref int x) {
            x = int.Parse(Console.ReadLine());
        }

        protected void IntFromConsole(ref int x, ref int y) {
            string[] str = Console.ReadLine().Split(' ');
            x = int.Parse(str[0]);
            y = int.Parse(str[1]);
        }

        protected void MassImageOperation(MassImageOperation massImageOperation) {
            this.massImageOperation = massImageOperation;
            RecursiveOperationThrougthImages(MassImageOperation);
        }

        private void MassImageOperation(string fileOperation) {
            imageProcessor = new ImageProcessor();
            imageProcessor.SetImage(fileOperation);
            massImageOperation.Invoke(imageProcessor);
            imageProcessor.SaveImage();
			imageProcessor = null;
        }
    }
}
