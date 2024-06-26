private void textBox1_TextChanged(object sender, EventArgs e)
{
    // Assuming 'db' is an instance of your database access class
    Database db = new Database();
    string searchText = textBox1.Text;

    // Fetch the search results asynchronously
    DataTable searchResults = await db.SearchComputerPartsAsync(searchText);

    // Update the DataGridView with the search results
    dataGridView1.DataSource = searchResults;
}