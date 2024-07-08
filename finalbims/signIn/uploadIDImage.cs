private void uploadPhotoButton_Click(object sender, EventArgs e)
{
    string directoryPath = "oop-bims-final\\residentimages\\";
    string filePath;
    Bitmap imageToSave;
    bool useDefaultImage = false; // Flag to indicate if the default image should be used

    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files|*.jpg;*.png";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = openFileDialog.FileName;
            imageToSave = new Bitmap(filePath);
        }
        else
        {
            // Use default image if no image is selected
            filePath = Path.Combine(directoryPath, "defaultpicture.jpg");
            imageToSave = new Bitmap(filePath);
            useDefaultImage = true; // Set the flag to true as the default image is being used
        }
    }

    // Resize the image
    int cellSize = 100; // Example size, adjust as needed
    using (Bitmap resizedImage = new Bitmap(imageToSave, new Size(cellSize, cellSize)))
    {
        // Apply circular frame
        using (Bitmap circularImage = new Bitmap(cellSize, cellSize))
        {
            using (Graphics g = Graphics.FromImage(circularImage))
            {
                g.Clear(Color.Transparent);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, cellSize, cellSize);
                g.SetClip(path);
                g.DrawImage(resizedImage, 0, 0);
            }

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Use BarangayID as the filename
            string filename = $"{BarangayID}.jpg";
            string savePath = Path.Combine(directoryPath, filename);

            // Save the resized image
            resizedImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Display the resized image in the PictureBox called idImage
            idImage.Image = Image.FromFile(savePath);
        }
    }
}