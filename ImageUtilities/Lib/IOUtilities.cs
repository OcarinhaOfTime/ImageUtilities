using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities
{

    public delegate void FileOperation(string file);
    class IOUtilities
    {
        #region OperationThrougthFiles...
        public void RecursiveOperationThrougthFiles(string directory, FileOperation fileOperation) {
            string[] folders = Directory.GetDirectories(directory);
            foreach(string folder in folders)
                RecursiveOperationThrougthFiles(folder, fileOperation);

            string[] files = Directory.GetFiles(directory);
            foreach(string file in files)
                fileOperation.Invoke(file);
        }

        public void RecursiveOperationThrougthImages(string directory, FileOperation fileOperation) {
            string[] folders = Directory.GetDirectories(directory);

            foreach(string folder in folders)
                RecursiveOperationThrougthImages(folder, fileOperation);

            string[] files = GetImageFiles(directory);
            foreach(string file in files) {
                fileOperation.Invoke(file);
            }
        }

        public void RecursiveOperationThrougthImages(string directory, FileOperation fileOperation, string prefix) {
            string[] folders = Directory.GetDirectories(directory);

            foreach(string folder in folders)
                RecursiveOperationThrougthImages(folder, fileOperation, prefix);

            string[] files = IOUtilities.GetImageFiles(directory);
            foreach(string file in files) {
                if(Path.GetFileName(file).HasPrefix(prefix))
                    fileOperation.Invoke(file);
            }
        }

        #endregion

        #region Static stuff
        public static string[] GetAllFilesInADirectory(string directory) {
            return Directory.GetFiles(directory);
        }

        public static string[] GetAllImagesInADirectory(string directory) {
            string[] jpgs = Directory.GetFiles(directory, "*.jpg");
            string[] pngs = Directory.GetFiles(directory, "*.png");
            return ArrayUtilities.MergeArrays<string>(pngs, jpgs);
        }

        public static string[] GetAllNamesOnADirectory(string directory, bool includeExtention = false) {
            string[] files = Directory.GetFiles(directory);
            string[] fileNames = new string[files.Length];
            for(int i = 0; i<files.Length; i++) {
                fileNames[i] = GetFileName(files[i], includeExtention);
            }

            return fileNames;
        }

        public static string GetFileName(string file, bool includeExtention) {
            if(includeExtention)
                return Path.GetFileName(file);
            else
                return Path.GetFileNameWithoutExtension(file);
        }

        public static string[] GetImageFiles(string path) {
            return GetFiles(path, "*.png", "*.jpg", "*.psd");
        }

        public static string[] GetFiles(string path, params string[] patterns) {
            string[] allFiles = new string[0];
            foreach(string pattern in patterns) {
                string[] files = Directory.GetFiles(path, pattern);
                allFiles = allFiles.Merge(files);
            }
            return allFiles;
        }
        #endregion
    }

}
