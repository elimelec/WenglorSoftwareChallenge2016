using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using Image;
using Extensions;

namespace Wenglor
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var operationsFile = currentDirectory + "\\Operations.txt";
            var inputFolder = currentDirectory + "\\Input Files";
            var outputFolder = currentDirectory + "\\Output Files";

            Directory.CreateDirectory(outputFolder);

            var operations = File.ReadAllLines(operationsFile).ExtractOperations();
            var rotateType = operations.Item1;
            var remapTable = operations.Item2;

            var files = Directory.EnumerateFiles(inputFolder, "*.bmp");
            Parallel.ForEach(files, file => {
                var image = new BitmapImage(file);
                
                image.Rotate(rotateType);
                image.RemapColors(remapTable);

                image.Save(file.ToOutputPath(outputFolder));
            });
        }
    }
}
