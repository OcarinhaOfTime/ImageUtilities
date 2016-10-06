using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities {
    class RenameUtilities {
		public string fullpath{get{return _fullPath;}}
		public string fileName{get{return _fileName;}}
		public string directory{get{return _directory;}}

        string _fullPath;
		string _fileName;
		string _directory;

        public void SetFile(string path) {
            _fullPath = path;
            _fileName = Path.GetFileName(_fullPath);
            _directory = Path.GetDirectoryName(_fullPath);
        }

        public void Rename(string newName) {
            File.Move(_fullPath, _directory + "/" + newName);
			SetFile (_directory + "/" + newName);
        }

        public void RenameTecido() {
            char[] iterator = _fileName.ToCharArray();
            string renamed = "";
            int i = 0;
            while (!ASC2Utilities.IsNumber(iterator[i]))
                i++;
            for (int j = 0; j < 4; j++) {
                renamed += iterator[i];
                i++;
            }
            renamed += "_";
            while (!ASC2Utilities.IsNumber(iterator[i]))
                i++;
            renamed += "G";
            renamed += iterator[i];
            renamed += Path.GetExtension(_fullPath);
            File.Move(_fullPath, _directory + "/" + renamed);
            Console.WriteLine(renamed);
        }

        public void AddPrefix(string prefix) {
            Rename(prefix + _fileName);
        }

        public void AddOrRemovePrefix(string prefix) {
            if (_fileName.HasPrefix(prefix))
                Rename(_fileName.Replace(prefix, ""));
            else
                Rename(prefix + _fileName);
        }

		public void RemovePrefix(string prefix){
			Rename(_fileName.Replace(prefix, ""));
		}
    }
}
