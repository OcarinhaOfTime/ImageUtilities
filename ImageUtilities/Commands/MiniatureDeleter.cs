using System;
using System.IO;
using ImageUtilities.Extentions;

namespace ImageUtilities.Commands
{
	class MiniatureDeleter : CommandBase
	{
		public override void Execute(){
			base.RecursiveOperationThrougthImages (DeleteMiniature);
		} 

		void DeleteMiniature(string file){
			if (Path.GetFileName (file).HasPrefix ("_miniature"))
				File.Delete (file);
		}
	}
}

