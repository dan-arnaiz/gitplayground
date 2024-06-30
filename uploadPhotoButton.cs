private void uploadPhotoButton_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files|*.jpg;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            using (Bitmap originalImage = new Bitmap(filePath))
            {
                // Resize the image
                int cellSize = 100; // Example size, adjust as needed
                Bitmap resizedImage = new Bitmap(originalImage, new Size(cellSize, cellSize));

                // Apply circular frame
                Bitmap circularImage = new Bitmap(cellSize, cellSize);
                using (Graphics g = Graphics.FromImage(circularImage))
                {
                    g.Clear(Color.Transparent);
                    GraphicsPath path = new GraphicsPath();
                    path.AddEllipse(0, 0, cellSize, cellSize);
                    g.SetClip(path);
                    g.DrawImage(resizedImage, 0, 0);
                }

                // Save the circular image to a specific path
                string directoryPath = "oop-bims-final\\residentimages\\";
                // Ensure the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fileName = Path.GetFileName(filePath); // Use original file name, or generate a new one as needed
                string savePath = Path.Combine(directoryPath, fileName);
                circularImage.Save(savePath);

                // Display the circularImage in the PictureBox called idImage
                idImage.Image = Image.FromFile(savePath);
            }
        }
    }
}