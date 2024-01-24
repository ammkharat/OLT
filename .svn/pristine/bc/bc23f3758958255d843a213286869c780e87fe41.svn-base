using System;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormGN75BSchematicForm : Form
    {
        public FormGN75BSchematicForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadImage();
            Resize += FormGN75BSchematicForm_SizeChanged;
        }

        internal Image OriginalImage { set; private get; }

        private void LoadImage()
        {
            Rectangle clientRectangle = pictureBox1.ClientRectangle;
            Image resizedImage = ScaleImage(OriginalImage, clientRectangle.Width, clientRectangle.Height);
            pictureBox1.Image = resizedImage;
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            if (image.Height <= maxHeight && image.Width <= maxWidth)
            {
                // no need to scale the image as it fits in the area already.
                return new Bitmap(image);
            }

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
        
        private void FormGN75BSchematicForm_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            LoadImage();
        }
    }
}