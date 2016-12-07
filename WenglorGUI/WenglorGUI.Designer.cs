namespace WenglorGUI
{
    partial class WenglorGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadImagesButton = new System.Windows.Forms.Button();
            this.loadOperationsButton = new System.Windows.Forms.Button();
            this.originalPicture = new System.Windows.Forms.PictureBox();
            this.processedPicture = new System.Windows.Forms.PictureBox();
            this.executeOperationsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processImagesWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImages
            // 
            this.loadImagesButton.Location = new System.Drawing.Point(12, 12);
            this.loadImagesButton.Name = "LoadImages";
            this.loadImagesButton.Size = new System.Drawing.Size(167, 59);
            this.loadImagesButton.TabIndex = 0;
            this.loadImagesButton.Text = "Load Images";
            this.loadImagesButton.UseVisualStyleBackColor = true;
            this.loadImagesButton.Click += new System.EventHandler(this.loadImagesButton_Click);
            // 
            // LoadOperations
            // 
            this.loadOperationsButton.Location = new System.Drawing.Point(581, 12);
            this.loadOperationsButton.Name = "LoadOperations";
            this.loadOperationsButton.Size = new System.Drawing.Size(165, 59);
            this.loadOperationsButton.TabIndex = 1;
            this.loadOperationsButton.Text = "Load Operations";
            this.loadOperationsButton.UseVisualStyleBackColor = true;
            this.loadOperationsButton.Click += new System.EventHandler(this.loadOperationsButton_Click);
            // 
            // OriginalPicture
            // 
            this.originalPicture.Location = new System.Drawing.Point(12, 132);
            this.originalPicture.Name = "OriginalPicture";
            this.originalPicture.Size = new System.Drawing.Size(228, 216);
            this.originalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPicture.TabIndex = 2;
            this.originalPicture.TabStop = false;
            // 
            // ProcessedPicture
            // 
            this.processedPicture.Location = new System.Drawing.Point(519, 132);
            this.processedPicture.Name = "ProcessedPicture";
            this.processedPicture.Size = new System.Drawing.Size(227, 216);
            this.processedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.processedPicture.TabIndex = 3;
            this.processedPicture.TabStop = false;
            // 
            // ExecuteOperations
            // 
            this.executeOperationsButton.Location = new System.Drawing.Point(301, 200);
            this.executeOperationsButton.Name = "ExecuteOperations";
            this.executeOperationsButton.Size = new System.Drawing.Size(167, 59);
            this.executeOperationsButton.TabIndex = 4;
            this.executeOperationsButton.Text = "Execute Operations";
            this.executeOperationsButton.UseVisualStyleBackColor = true;
            this.executeOperationsButton.Click += new System.EventHandler(this.executeOperationsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Original Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Processed Image:";
            // 
            // processImagesWorker
            // 
            this.processImagesWorker.WorkerReportsProgress = true;
            this.processImagesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.processImagesWorker_DoWork);
            this.processImagesWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.processImagesWorker_ProgressChanged);
            this.processImagesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.processImagesWorker_RunWorkerCompleted);
            // 
            // WenglorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.executeOperationsButton);
            this.Controls.Add(this.processedPicture);
            this.Controls.Add(this.originalPicture);
            this.Controls.Add(this.loadOperationsButton);
            this.Controls.Add(this.loadImagesButton);
            this.MaximumSize = new System.Drawing.Size(776, 407);
            this.MinimumSize = new System.Drawing.Size(776, 407);
            this.Name = "WenglorGUI";
            this.Text = "Wenglor Students Software Challenge - Image Manipulator";
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadImagesButton;
        private System.Windows.Forms.Button loadOperationsButton;
        private System.Windows.Forms.PictureBox originalPicture;
        private System.Windows.Forms.PictureBox processedPicture;
        private System.Windows.Forms.Button executeOperationsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker processImagesWorker;
    }
}

