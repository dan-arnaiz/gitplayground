private async void addNewItemButtonModal_Click(object sender, EventArgs e)
{
    try
    {
        // Validate numerical values before parsing
        if (!decimal.TryParse(priceTextBox.Text, out decimal price))
        {
            MessageBox.Show("Please enter a valid decimal value for price.");
            return;
        }
        if (!int.TryParse(quantityTextBox.Text, out int quantity))
        {
            MessageBox.Show("Please enter a valid integer value for quantity.");
            return;
        }

        // Instantiate your Database class
        Database db = new Database();

        // Collect input values from text boxes
        string name = nametextBox.Text;
        string brand = brandTextBox.Text;
        string category = categoryTextBox.Text;
        string supplier = supplierTextBox.Text;
        string description = descriptionTextbox.Text;

        // Call the AddComputerPart method asynchronously
        bool success = await db.AddComputerPartAsync(name, brand, category, price, quantity, supplier, description);

        if (success)
        {
            MessageBox.Show("Item added successfully.");
            // Clear the text boxes
            nametextBox.Clear();
            brandTextBox.Clear();
            categoryTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();
            supplierTextBox.Clear();
            descriptionTextbox.Clear();

            // Assuming this form is a modal dialog of the parent form that contains dataGridView1
            // Refresh dataGridView1 on the parent form
            var parentForm = this.Owner as MainForm; // Replace MainForm with the actual type of your parent form
            if (parentForm != null)
            {
                parentForm.RefreshDataGridView(); // Implement this method in your parent form to refresh dataGridView1
            }

            // Close the modal form
            this.Close();
        }
        else
        {
            MessageBox.Show("Failed to add the item.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred: {ex.Message}");
    }
}