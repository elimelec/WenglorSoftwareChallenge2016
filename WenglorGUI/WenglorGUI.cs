using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Image;
using Extensions;
using System.Drawing.Imaging;
using System.Threading;

namespace WenglorGUI
{
    public partial class WenglorGUI : Form
    {
        string inputFolder;
        string outputFolder;

        RotateFlipType rotateOperation;
        ColorMap[] remapOperation;

        string[] filesToProcess;

        public WenglorGUI()
        {
            InitializeComponent();
        }

        private void loadImagesButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Directory.GetCurrentDirectory();
            dialog.ShowDialog();
            var selectedPath = dialog.SelectedPath;

            if (string.IsNullOrWhiteSpace(selectedPath))
            {
                loadImagesButton.BackColor = Color.Red;
                return;
            }

            var files = Directory.EnumerateFiles(selectedPath, "*.bmp");
            if (files.LongCount() == 0)
            {
                loadImagesButton.BackColor = Color.Red;
                return;
            }

            inputFolder = selectedPath;
            outputFolder = Directory.GetParent(inputFolder) + "\\Output Files";
            Directory.CreateDirectory(outputFolder);
            filesToProcess = files.ToArray();

            loadImagesButton.BackColor = Color.Green;
        }

        private void loadOperationsButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.ShowDialog();
            var selectedPath = dialog.FileName;

            if (string.IsNullOrWhiteSpace(selectedPath))
            {
                loadOperationsButton.BackColor = Color.Red;
                return;
            }

            Tuple<RotateFlipType, ColorMap[]> operations;
            try
            {
                operations = File.ReadAllLines(selectedPath).ExtractOperations();
            }
            catch
            {
                loadOperationsButton.BackColor = Color.Red;
                return;
            }

            rotateOperation = operations.Item1;
            remapOperation = operations.Item2;

            loadOperationsButton.BackColor = Color.Green;
            loadOperationsButton.Enabled = false;
        }

        private void executeOperationsButton_Click(object sender, EventArgs e)
        {
            loadImagesButton.Enabled = false;
            loadOperationsButton.Enabled = false;
            executeOperationsButton.Enabled = false;
            executeOperationsButton.BackColor = Color.LightGray;
            processImagesWorker.RunWorkerAsync();
        }

        private void processImagesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            
            for (int i = 0; i < filesToProcess.Length; i++)
            {
                var file = filesToProcess[i];
                var image = new BitmapImage(file);

                image.Rotate(rotateOperation);
                image.RemapColors(remapOperation);

                image.Save(file.ToOutputPath(outputFolder));

                worker.ReportProgress(i);
                Thread.Sleep(1000);
            }
        }

        private void processImagesWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (originalPicture.Image != null)
            {
                originalPicture.Image.Dispose();
            }
            if (processedPicture.Image != null)
            {
                processedPicture.Image.Dispose();
            }

            var originalImagePath = filesToProcess[e.ProgressPercentage];
            var processedImagePath = originalImagePath.ToOutputPath(outputFolder);

            originalPicture.Image = new Bitmap(originalImagePath);
            processedPicture.Image = new Bitmap(processedImagePath);

            GC.Collect();
        }

        private void processImagesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            executeOperationsButton.BackColor = Color.Green;
            executeOperationsButton.Enabled = true;
            loadOperationsButton.Enabled = true;
            loadImagesButton.Enabled = true;
        }
    }
}
