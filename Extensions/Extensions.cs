using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Extensions
{
    /// <summary>
    /// Extensions for wenglor Students Software Challenge 2016.
    /// </summary>
    static class WenglorStudentsSoftwareChallege2016Extensions
    {
        /// <summary>
        /// Extract operations for wenglor Students Software Challenge 2016.
        /// </summary>
        /// <param name="operations">Lines from Operation.txt from wenglor Students Software Challenge 2016.</param>
        /// <returns>A Tuple containg code friendly operations to be used in wenglor Students Software Challenge 2016.</returns>
        public static Tuple<RotateFlipType, ColorMap[]> ExtractOperations(this string[] operations)
        {
            var rotateGrades = 0;
            var marks = new List<ColorMap>();

            foreach (var operation in operations)
            {
                if (operation.StartsWith("rotate"))
                {
                    rotateGrades += operation.ExtractGrades();
                }
                else
                {
                    var parts = operation.Split(' ');

                    var colorMap = new ColorMap();
                    colorMap.OldColor = parts.SubArray(1, 3).ExtractColor();
                    colorMap.NewColor = parts.SubArray(4, 3).ExtractColor();

                    marks.Add(colorMap);
                }
            }

            var rotateType = rotateGrades.ToRotateFlipType();
            var remapTable = marks.ToArray();

            return Tuple.Create(rotateType, remapTable);
        }

        /// <summary>
        /// Extract the number of grades from a rotate operation.
        /// </summary>
        public static int ExtractGrades(this string operation)
        {
            var gradesString = operation.Split(' ')[1];
            var grades = int.Parse(gradesString);
            return grades;
        }

        /// <summary>
        /// Contruct a Color from a >= 3 sized string array.
        /// </summary>
        /// <param name="colorParts">
        /// The >= 3 sized string array.
        /// Strings must be valid integers. Only the first 3 elements will be used
        /// </param>
        public static Color ExtractColor(this string[] colorParts)
        {
            var red = int.Parse(colorParts[0]);
            var green = int.Parse(colorParts[1]);
            var blue = int.Parse(colorParts[2]);

            return Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Create an output path for an imaged, based on it's input path.
        /// </summary>
        public static string ToOutputPath(this string inputPath, string outputFolder)
        {
            var name = Path.GetFileName(inputPath);
            name = name.Replace("Input", "Output");
            var outputPath = outputFolder + "\\" + name;
            return outputPath;
        }
    }

    static class Extensions
    {
        public static T[] SubArray<T>(this T[] source, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(source, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Convert to RotateFlipType.
        /// </summary>
        /// <param name="grades">Number of grades to rotate. Valid values are: 0, 90, 180, 270</param>
        public static RotateFlipType ToRotateFlipType(this int grades)
        {
            RotateFlipType rotateType;
            if (grades == 0)
            {
                rotateType = RotateFlipType.RotateNoneFlipNone;
            }
            else if (grades == 90)
            {
                rotateType = RotateFlipType.Rotate90FlipNone;
            }
            else if (grades == 180)
            {
                rotateType = RotateFlipType.Rotate180FlipNone;
            }
            else //if (grades == 270)
            {
                rotateType = RotateFlipType.Rotate270FlipNone;
            }
            return rotateType;
        }
    }
}
