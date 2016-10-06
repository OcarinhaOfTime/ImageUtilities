using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageUtilities.Commands {
    class WhiteSpaceRemoverCommand : CommandBase{
        public override void Execute() {
            base.MassImageOperation(WhiteSpaceRemover);
        }

        void WhiteSpaceRemover(ImageProcessor imageProcessor) {
            int x1, x2, y1, y2;
            Color white = Color.White;
            Console.WriteLine("Removing white space from: " + imageProcessor.GetName());
            
            x1 = GetX1(imageProcessor, imageProcessor.GetWidth(), imageProcessor.GetHeight());
            x2 = GetX2(imageProcessor, imageProcessor.GetWidth(), imageProcessor.GetHeight());
            y1 = GetY1(imageProcessor, imageProcessor.GetWidth(), imageProcessor.GetHeight());
            y2 = GetY2(imageProcessor, imageProcessor.GetWidth(), imageProcessor.GetHeight());

            imageProcessor.CropImage(x1, y1, x2, y2);
        }

        int GetX1(ImageProcessor imageProcessor, int width, int heigth) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < heigth; y++) {
                    if (!isWhite(imageProcessor.GetPixel(x, y))) {
                        if (x == 0)
                            return 0;
                        return --x;
                    }
                }
            }

            return 0;
        }

        int GetX2(ImageProcessor imageProcessor, int width, int heigth) {
            for (int x = width -1; x > 0; x--) {
                for (int y = 0; y < heigth; y++) {
                    if (!isWhite(imageProcessor.GetPixel(x, y))) {
                        if (x == width - 1)
                            return width - 1;
                        return ++x;
                    }
                }
            }

            return 0;
        }

        int GetY1(ImageProcessor imageProcessor, int width, int heigth) {
            for (int y = 0; y < heigth; y++) {
                for (int x = 0; x < width; x++) {
                    if (!isWhite(imageProcessor.GetPixel(x, y))) {
                        if (y == 0)
                            return 0;
                        return --y;
                    }
                }
            }

            return 0;
        }

        int GetY2(ImageProcessor imageProcessor, int width, int heigth) {
            for (int y = heigth -1; y > 0; y--) {
                for (int x = 0; x < width; x++) {
                    if (!isWhite(imageProcessor.GetPixel(x, y))) {
                        if (y == heigth - 1)
                            return heigth - 1;
                        return ++y;
                    }
                }
            }

            return 0;
        }

        bool isWhite(Color color) {
            if (color.A == 255 && color.R == 255 && color.G == 255 && color.B == 255)
                return true;

            return false;
        }
    }
}
