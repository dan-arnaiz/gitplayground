private async void addNewBarangayButton_Click(object sender, EventArgs e) {
  // Check for empty required fields and show an error dialog if any are empty
  if (string.IsNullOrWhiteSpace(BarangayNameTextBox.Text) ||
      string.IsNullOrWhiteSpace(barangayAddressTextBox.Text) ||
      string.IsNullOrWhiteSpace(barangayDescriptionTextBox.Text)) {
    MessageBox.Show("Please fill in all required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
    return; // Stop further execution
  }

  try {
    string directoryPath = "oop-bims-final\\barangayimages\\";
    string defaultImagePath = Path.Combine(directoryPath, "defaultpicture.jpg");
    string filename;

    // Check if idImage has an image uploaded and construct the filename
    // accordingly
    if (BarangayLogoImage.Image != null) {
      filename = $"{BarangayNameTextBox.Text}.jpg";
    } else {
      filename = "defaultpicture.jpg"; // Use the default image name
    }

    string imagePath = Path.Combine(directoryPath, filename);
    // Ensure the default image exists if no image is uploaded
    if (!File.Exists(imagePath)) {
      imagePath = defaultImagePath;
    }

    byte[] pictureBarangayData = File.ReadAllBytes(imagePath);
    string BarangayName = BarangayNameTextBox.Text;
    string barangayAddress = barangayAddressTextBox.Text;
    string barangayDescription = barangayDescriptionTextBox.Text;

    // Create an instance of your Database class
    Database db = new Database();
    // Call the AddResident method
    await db.AddBarangay(pictureBarangayData, BarangayName, barangayAddress,
                         barangayDescription);
    MessageBox.Show("Barangay added successfully!");
    this.ParentForm.Close();
    OnBarangayAdded();
  } catch (Exception ex) {
    MessageBox.Show($"Failed to add Barangay. Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}