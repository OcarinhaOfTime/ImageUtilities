using System;
using System.Text;
using System.Threading.Tasks;
using ImageUtilities.App;
using ImageUtilities.Extentions;
using ImageUtilities.Tests;
using ImageUtilities.ExternalCode;

namespace ImageUtilities
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
