using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video.FFMPEG;
using System.Drawing.Imaging;

namespace rgbd_copmression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //when the start button is clicked
        {
            pictureBox.Image = Properties.Resources.Animation;
            backgroundWorker1.RunWorkerAsync(); //start background work
        }
        int percentage = 0;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)   //background work
        {
            if (percentage == 0)
            {
                this.backgroundWorker1.ReportProgress(percentage, string.Format("Processing..."));  //show that we are still alive
            }
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();    //used for JPEG compression
            ImageCodecInfo image_codec_info = null;

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                    image_codec_info = codec;    //set image codec info to jpeg
            }
            EncoderParameters encoder_parameters = new EncoderParameters();
            string source_folder_path = textbox_source_folder.Text;
            //create directories for work
            //
            //
            Directory.CreateDirectory(textbox_destination_folder.Text);
            Directory.CreateDirectory(textbox_destination_folder.Text + @"\video");

            //depth image that all image depths will be compared to
            //
            //
            string path_original_image_depth = @textbox_depth_image.Text;
            Image<Gray, UInt16> image_depth_control = new Image<Gray, UInt16>(path_original_image_depth);
            int width = image_depth_control.Width;
            int height = image_depth_control.Height;

            foreach (string file in Directory.EnumerateFiles(source_folder_path))   //for every image
            {
                string file_name = Path.GetFileName(file);
                if (file_name.Contains("rgb"))  //if it's rgb
                {
                    string depth_image_path = file_name.Replace("rgb", "depth");    //get corresponding depth image
                    string path_image_depth = @source_folder_path + @"\" + depth_image_path;
                    string path_image_rgb = @source_folder_path + @"\" + file_name;
                    Image<Gray, UInt16> image_depth = new Image<Gray, UInt16>(path_image_depth);    //create gray image for the depth image
                    Image<Bgr, byte> image_rgb = new Image<Bgr, byte>(path_image_rgb);

                    //loop through the pixels
                    for (int v = 0; v < image_depth_control.Height; v++)
                    {
                        for (int u = 0; u < image_depth_control.Width; u++)
                        {
                            UInt16 a = image_depth_control.Data[v, u, 0];   //get original image depth data of current pixel
                            UInt16 b = image_depth.Data[v, u, 0];   //get current image depth data of current pixel

                            if (Math.Abs(a - b) < 2)    //if the pixels have the same depth, then this pixel belongs to a stationary object. Set it's RGB and depth values to 0
                            {
                                image_rgb.Data[v, u, 0] = 0;
                                image_rgb.Data[v, u, 1] = 0;
                                image_rgb.Data[v, u, 2] = 0;
                                image_depth.Data[v, u, 0] = 0;
                            }
                        }
                    }
                    encoder_parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)80);   //set JPEG configuration, most importantly quality 80%
                    image_rgb.ToBitmap().Save(@textbox_destination_folder.Text + @"\" + file_name.Replace("png", "jpg"), image_codec_info, encoder_parameters); //perform jpeg compression for RGB image and save
                    image_depth.ToBitmap().Save(@textbox_destination_folder.Text + @"\" + depth_image_path);    //save depth image without jpeg compression
                }
            }
            using (var writer = new VideoFileWriter())  //create a video from the output RGB frames
            {

                memory.MemoryManagement.FlushMemory();  //enhance performance
                writer.Open(Path.Combine(@textbox_destination_folder.Text + @"\video\output.avi"), width, height, 25, VideoCodec.Raw);

                foreach (string file in Directory.EnumerateFiles(@textbox_destination_folder.Text))
                {
                    if (!file.Contains(".png")) //if file is not a depth image
                    {
                        memory.MemoryManagement.FlushMemory();
                        using (var img = (Bitmap)Image.FromFile(file))
                        {
                            writer.WriteVideoFrame(img);
                        }
                    }
                }
                writer.Close();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                this.progressLabel.Text = (String)e.UserState;  //update progressLabel
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.pictureBox.Image = null;
            if (e.Error != null)    //if an error occured
            {
                this.progressLabel.Text = "Operation failed: " + e.Error.Message;   //report error
                this.pictureBox.Image = Properties.Resources.Error; //show error icon
            }
            else    //if no error occured
            {
                this.progressLabel.Text = "Operation completed successfuly";
                this.pictureBox.Image = Properties.Resources.Information;   //show information icon
            }
        }
    }
}