private async void button3_Click(object sender, EventArgs e)
{
    try
    {
        // Assuming Database is the class that contains your database operations
        Database db = new Database();

        // Await the call to get all computer parts. Make sure this method exists and is implemented correctly.
        var computerParts = await db.GetAllComputerPartsAsync();

        // Set the data source for dataGridView1
        dataGridView1.DataSource = computerParts;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while refreshing the list: {ex.Message}");
    }
}