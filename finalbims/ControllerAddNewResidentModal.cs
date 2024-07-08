using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMS_dan
{
public partial class ControllerAddNewResidentModal : UserControl
{
    public event EventHandler ResidentAdded;
    public ControllerAddNewResidentModal()
    {
        InitializeComponent();
    }

    private void ControllerAddNewResidentModal_Load(object sender, EventArgs e)
    {

    }

    protected virtual void OnResidentAdded()
    {
        ResidentAdded?.Invoke(this, EventArgs.Empty);
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

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

                // Construct the filename based on the resident's name or use a default name
                string filename = useDefaultImage || string.IsNullOrWhiteSpace(lastNameTextBox.Text) || string.IsNullOrWhiteSpace(firstNameTextBox.Text)
                                  ? "defaultpicture.jpg" // Use the default picture name if flag is true or names are empty
                                  : $"{lastNameTextBox.Text}_{firstNameTextBox.Text}.jpg";
                string savePath = Path.Combine(directoryPath, filename);

                // Save the circular image
                circularImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Display the circularImage in the PictureBox called idImage
                idImage.Image = Image.FromFile(savePath);
            }
        }
    }

    private void idImage_Click(object sender, EventArgs e)
    {

    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.ParentForm.Close();
    }

    private void lastNameTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void firstNameTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void middleNameTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void suffixTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private async void addNewResidentButton_Click(object sender, EventArgs e)
    {
        // Check for empty required fields and show an error dialog if any are empty
        if (string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(middleNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addressTextBox.Text) ||
                sexDropdown.SelectedItem == null ||
                civilStatusDropdown.SelectedItem == null ||
                string.IsNullOrWhiteSpace(yearsResidingTextBox.Text) ||
                string.IsNullOrWhiteSpace(occupationTextBox.Text))
        {
            MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // Stop further execution
        }

        try
        {
            string directoryPath = "oop-bims-final\\residentimages\\";
            string defaultImagePath = Path.Combine(directoryPath, "defaultpicture.jpg");
            string filename;

            // Check if idImage has an image uploaded and construct the filename accordingly
            if (idImage.Image != null)
            {
                filename = $"{lastNameTextBox.Text}_{firstNameTextBox.Text}.jpg";
            }
            else
            {
                filename = "defaultpicture.jpg"; // Use the default image name
            }

            string imagePath = Path.Combine(directoryPath, filename);
            // Ensure the default image exists if no image is uploaded
            if (!File.Exists(imagePath))
            {
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
            await db.AddResident(pictureData, lastName, firstName, middleName, birthdate, sex, civilStatus, address, yearsResiding, occupation);
            MessageBox.Show("Resident added successfully!");
            this.ParentForm.Close();
            OnResidentAdded();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add resident. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void birthDatePicker_ValueChanged(object sender, EventArgs e)
    {

    }

    private void sexDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void civilStatusDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void addressTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void yearsResidingTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void occupationTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
}
