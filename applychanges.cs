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

        // Use the values from currentRow instead of trying to access dataGridView1


        string originalName = currentRow.Cells["nameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
        string originalBrand = currentRow.Cells["brandDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
        string originalCategory = currentRow.Cells["categoryDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
        decimal originalPrice = Convert.ToDecimal(currentRow.Cells["priceDataGridViewTextBoxColumn"].Value?.ToString() ?? "0");
        int originalQuantity = Convert.ToInt32(currentRow.Cells["quantityDataGridViewTextBoxColumn"].Value?.ToString() ?? "0");
        string originalSupplier = currentRow.Cells["supplierDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
        string originalDescription = currentRow.Cells["descriptionDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

        // Compare the original data with the new data
        bool dataChanged = !(originalName == name && originalBrand == brand && originalCategory == category && originalPrice == price && originalQuantity == quantity && originalSupplier == supplier && originalDescription == description);

        if (dataChanged)
        {
            // Call the UpdateComputerPart method asynchronously
            bool success = await db.UpdateComputerPartAsync(itemId, name, brand, category, price, quantity, supplier, description);

            if (success)
            {
                MessageBox.Show("Changes have been applied successfully.");
                // Optionally, close the form
                this.ParentForm.Close();
            }
            else
            {
                MessageBox.Show("Failed to apply the changes.");
            }
        }
        else
        {
            MessageBox.Show("No changes have been made.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred: {ex.Message}");
    }
}