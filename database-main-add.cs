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
        string id = idTextbox.Text;
        string name = nametextBox.Text;
        string brand = brandTextBox.Text;
        string category = categoryTextBox.Text;
        string supplier = supplierTextBox.Text;
        string description = descriptionTextbox.Text;

        // Call the AddComputerPart method asynchronously
        bool success = await db.AddComputerPartAsync(id, name, brand, category, price, quantity, supplier, description);

        if (success)
        {
            MessageBox.Show("Item added successfully.");
            // Optionally, clear the text boxes
            idTextbox.Clear();
            nametextBox.Clear();
            brandTextBox.Clear();
            categoryTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();
            supplierTextBox.Clear();
            descriptionTextbox.Clear();
            this.ParentForm.Close();
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



//database method

