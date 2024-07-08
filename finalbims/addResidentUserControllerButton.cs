private async void addNewResidentButton_Click(object sender, EventArgs e) {
  // Check for empty required fields and show an error dialog if any are empty
  if (string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
      string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
      string.IsNullOrWhiteSpace(middleNameTextBox.Text) ||
      string.IsNullOrWhiteSpace(addressTextBox.Text) ||
      sexDropdown.SelectedItem == null ||
      civilStatusDropdown.SelectedItem == null ||
      string.IsNullOrWhiteSpace(yearsResidingTextBox.Text) ||
      string.IsNullOrWhiteSpace(occupationTextBox.Text)) {
    MessageBox.Show("Please fill in all required fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
    return; // Stop further execution
  }

  try {
    string directoryPath = "oop-bims-final\\residentimages\\";
    string defaultImagePath = Path.Combine(directoryPath, "defaultpicture.jpg");
    string filename;

    // Check if idImage has an image uploaded and construct the filename
    // accordingly
    if (idImage.Image != null) {
      filename = $"{lastNameTextBox.Text}_{firstNameTextBox.Text}.jpg";
    } else {
      filename = "defaultpicture.jpg"; // Use the default image name
    }

    string imagePath = Path.Combine(directoryPath, filename);
    // Ensure the default image exists if no image is uploaded
    if (!File.Exists(imagePath)) {
      imagePath = defaultImagePath;
    }

    byte[] pictureData = File.ReadAllBytes(imagePath);
    string lastName = lastNameTextBox.Text;
    string firstName = firstNameTextBox.Text;
    string middleName = middleNameTextBox.Text;
    DateTime birthdate = birthDatePicker.Value;
    string sex = sexDropdown.SelectedItem.ToString();
    string civilStatus = civilStatusDropdown.SelectedItem.ToString();
    string address = addressTextBox.Text;
    int yearsResiding = int.Parse(yearsResidingTextBox.Text); // Convert to int
    string occupation = occupationTextBox.Text;

    // Create an instance of your Database class
    Database db = new Database();
    // Call the AddResident method
    await db.AddResident(pictureData, lastName, firstName, middleName,
                         birthdate, sex, civilStatus, address, yearsResiding,
                         occupation);
    MessageBox.Show("Resident added successfully!");
    this.ParentForm.Close();
    await db.RefreshResidentsTableAsync(this.residentsTable);
  } catch (Exception ex) {
    MessageBox.Show($"Failed to add resident. Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}
