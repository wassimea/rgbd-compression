namespace rgbd_copmression
{
    partial class Form1
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
            this.textbox_destination_folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_source_folder = new System.Windows.Forms.TextBox();
            this.label_source_folder = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textbox_depth_image = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_destination_folder
            // 
            this.textbox_destination_folder.Location = new System.Drawing.Point(179, 52);
            this.textbox_destination_folder.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_destination_folder.Name = "textbox_destination_folder";
            this.textbox_destination_folder.Size = new System.Drawing.Size(303, 22);
            this.textbox_destination_folder.TabIndex = 17;
            this.textbox_destination_folder.Text = "C:\\Users\\welah\\Desktop\\folder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Destination Folder";
            // 
            // textbox_source_folder
            // 
            this.textbox_source_folder.Location = new System.Drawing.Point(179, 19);
            this.textbox_source_folder.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_source_folder.Name = "textbox_source_folder";
            this.textbox_source_folder.Size = new System.Drawing.Size(303, 22);
            this.textbox_source_folder.TabIndex = 15;
            this.textbox_source_folder.Text = "C:\\Users\\welah\\Desktop\\epfl_corridor.tar_2\\epfl_corridor\\epfl_corridor\\20141008_1" +
    "41323_00";
            // 
            // label_source_folder
            // 
            this.label_source_folder.AutoSize = true;
            this.label_source_folder.Location = new System.Drawing.Point(37, 21);
            this.label_source_folder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_source_folder.Name = "label_source_folder";
            this.label_source_folder.Size = new System.Drawing.Size(97, 17);
            this.label_source_folder.TabIndex = 14;
            this.label_source_folder.Text = "Source Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 150);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(504, 22);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(278, 17);
            this.progressLabel.TabIndex = 19;
            this.progressLabel.Text = "Press the Start button to start compressing";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(523, 52);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(133, 62);
            this.pictureBox.TabIndex = 20;
            this.pictureBox.TabStop = false;
            // 
            // textbox_depth_image
            // 
            this.textbox_depth_image.Location = new System.Drawing.Point(179, 92);
            this.textbox_depth_image.Margin = new System.Windows.Forms.Padding(4);
            this.textbox_depth_image.Name = "textbox_depth_image";
            this.textbox_depth_image.Size = new System.Drawing.Size(303, 22);
            this.textbox_depth_image.TabIndex = 22;
            this.textbox_depth_image.Text = "C:\\Users\\welah\\Desktop\\base_image\\base_image_depth.png";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Reference Depth Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 212);
            this.Controls.Add(this.textbox_depth_image);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.textbox_destination_folder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_source_folder);
            this.Controls.Add(this.label_source_folder);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textbox_destination_folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_source_folder;
        private System.Windows.Forms.Label label_source_folder;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textbox_depth_image;
        private System.Windows.Forms.Label label2;
    }
}

