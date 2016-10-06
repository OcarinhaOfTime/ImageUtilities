using System;
using ImageUtilities.Commands;

namespace ImageUtilities {
    class Menu {
        const string CLEAR = "cls";
        const string HELP = "help";
        const string MASS_RESIZE = "ms";
        const string MAKE_MINIATURE = "mm";
        const string INFINITY_RESIZER = "ir";
        const string DELETE_BY_PREFIX = "dbp";
        const string TO_POWER_OF_4 = "tp4";
        const string STRANGE_CHAR_REMOVER = "scr";
        const string IMAGE_SHRINK = "is";
		const string MAIN_CHOOSER = "mc";
		const string MINIATURE_DELETER = "md";
        const string PREFIX_DELETER = "pd";
        const string WHITE_SPACE_REMOVER = "wsr";
        const string PROPORTIONAL_WIDTH = "pw";
        const string PROPORTIONAL_HEIGTH = "ph";

        string choice;

        public void Start() {
            while (true) {
                ChooseAction();
                GC.Collect();
            }
        }

        void ChooseAction() {
            Console.WriteLine("choose what you wanna do (type \""+HELP+"\" for the list of commands )");
            choice = Console.ReadLine();

            switch(choice) {
                case CLEAR:
                    Console.Clear();
                    break;
                case HELP:
                    Help();
                    break;
                case MASS_RESIZE:
                    ExecuteComand(new MassResizeCommand());
                    break;
                case MAKE_MINIATURE:
					ExecuteComand(new MakeMiniatureCommand());
					break;
                case DELETE_BY_PREFIX:
                    ExecuteComand(new DeleteByPrefixCommand());
                    break;
                case INFINITY_RESIZER:
                    ExecuteComand(new InfinityResizeCommand());
                    break;
                case TO_POWER_OF_4:
                    ExecuteComand(new PowerOf4Command());
                    break;
                case STRANGE_CHAR_REMOVER:
                    throw new System.NotImplementedException();
                   // break;
                case IMAGE_SHRINK:
                    ExecuteComand(new ImageShrinkCommand());
                    break;
				case MAIN_CHOOSER:
					ExecuteComand(new MainChooserCommand());
					break;
				case MINIATURE_DELETER:
					ExecuteComand(new MiniatureDeleter());
					break;
                case PREFIX_DELETER:
                    ExecuteComand(new PrefixDeleterCommand());
                    break;
                case WHITE_SPACE_REMOVER:
                    ExecuteComand(new WhiteSpaceRemoverCommand());
                    break;
                case PROPORTIONAL_WIDTH:
                    ExecuteComand(new ProportionalyWidthResizeCommand());
                    break;
                case PROPORTIONAL_HEIGTH:
                    ExecuteComand(new ProportionalyHeightCommand());
                    break;
                default:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
            }
        }

        void ExecuteComand(ICommand command) {
            command.Execute();
        }

        void Help() {
            Console.WriteLine(MASS_RESIZE + " - resizes all images inside a given directory to a especific width x height");
            Console.WriteLine(MAKE_MINIATURE + " - creates a miniature for all images inside a directory, resizing then and putting into then a prefix");
            Console.WriteLine(INFINITY_RESIZER + " - resizes the image keeping a proportion and filling with white the empty spaces");
            Console.WriteLine(TO_POWER_OF_4 + " - changes all images to a power of 4 size");
            Console.WriteLine(PROPORTIONAL_WIDTH + " - resizes by width keeping the proportion");
            Console.WriteLine(PROPORTIONAL_HEIGTH + " - resizes by height keeping the proportion");
            Console.WriteLine(IMAGE_SHRINK + " -reduces the image to a given width and adjusts her size to a power of 4");
            Console.WriteLine(WHITE_SPACE_REMOVER + " - crops all white lines and columns in a image");
            Console.WriteLine("plumatex stuff: --------------------------------------------------");
            Console.WriteLine(MAIN_CHOOSER + " -starts the main chooser window");
            Console.WriteLine(MINIATURE_DELETER + " - deletes all miniatures");
            Console.WriteLine(PREFIX_DELETER + " - removes from all files the typed prefix");
            Console.WriteLine(DELETE_BY_PREFIX + " - delete all files that contains the specified prefix");
        }
    }
}
