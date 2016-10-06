using System;
using System.Windows.Forms;
using System.IO;
using ImageUtilities.ExternalCode;

namespace ImageUtilities
{
    class View
    {
        OpenFileDialog dialog;
        FolderBrowserDialog folderBrowser;

        public View()
        {
            dialog = new OpenFileDialog();
            folderBrowser = new FolderBrowserDialog();
        }

        public string GetFilePathDialog()
        {
            DialogResult result = dialog.ShowDialog();

            if(result == DialogResult.OK)
                return dialog.FileName;
            else if(result == DialogResult.Cancel) {
                Application.Exit();
                return "";
            }

            else {
                Application.Exit();
                return "";
            }
        }

        public string GetFolderPathDialog()
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                return folderBrowser.SelectedPath;
            else
            {
                Application.Exit();
                return "";
            }
        }

        public string GetFolderPathDialog2() {
            DialogResult result = dialog.ShowDialog();
            Console.WriteLine("I used the GetFolderPathDialog2");

            if(result == DialogResult.OK)
                return Path.GetDirectoryName(dialog.FileName);
            else if(result == DialogResult.Cancel) {
                Application.Exit();
                return "";
            }
            else {
                Application.Exit();
                return "";
            }
        }

        public string GetFolderPathDialog3() {
            FolderSelectDialog dialog = new FolderSelectDialog();
            dialog.Title = "Select folder";
            Console.WriteLine("I used the GetFolderPathDialog3");
            if (dialog.ShowDialog(IntPtr.Zero)) {
                Console.WriteLine(dialog.FileName);
            }

            return dialog.FileName;
        }
    }
}
