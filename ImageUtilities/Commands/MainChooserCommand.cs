using System;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.Commands
{
	class MainChooserCommand : CommandBase
	{
		RenameUtilities renameUtilities;
		ImageProcessor imageProcessor;

		public MainChooserCommand(){
			renameUtilities = new RenameUtilities ();
			imageProcessor = new ImageProcessor ();
		}

		public override void Execute(){
			while (true)
				Choose ();
		}
		public void Choose() {
			string mainImagePath = base.GetFileDialog ();
			string folderPath = Path.GetDirectoryName (mainImagePath);

			renameUtilities.SetFile (mainImagePath);

			renameUtilities.AddOrRemovePrefix ("_main");

		}

		void OlderMainRemover(string path){
			Console.WriteLine ("OlderMainRemover: " + path);
			renameUtilities.SetFile (path);
			renameUtilities.RemovePrefix ("_main");
		}
	}
}

