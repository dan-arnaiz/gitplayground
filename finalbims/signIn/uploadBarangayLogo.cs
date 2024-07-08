private void uploadBarangayLogoButton_Click(object sender, EventArgs e)
{
    string directoryPath = "oop-bims-final\\barangayimages\\";
    string filePath;
    Bitmap imageToSave;

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
        }
    }

    // Resize the image to 100x100
    int cellSize = 100; // New size for both width and height
    using (Bitmap resizedImage = new Bitmap(imageToSave, new Size(cellSize, cellSize)))
    {
        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Construct the filename based on the resident's name or use a default name
        string filename = string.IsNullOrWhiteSpace(lastNameTextBox.Text) || string.IsNullOrWhiteSpace(firstNameTextBox.Text)
                          ? "defaultpicture.jpg" // Use the default picture name if names are empty
                          : $"{lastNameTextBox.Text}_{firstNameTextBox.Text}.jpg";
        string savePath = Path.Combine(directoryPath, filename);

        // Save the resized image
        resizedImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

        // Display the resized image in the PictureBox called BarangayLogoImage
        BarangayLogoImage.Image = Image.FromFile(savePath);
    }
}