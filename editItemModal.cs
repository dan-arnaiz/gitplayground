using System.Windows.Forms;
using System;

namespace interventory
{
    public partial class editItemModal : UserControl
    {
        private DataGridViewRow currentRow;

        // Modified constructor to accept a DataGridViewRow
        public editItemModal(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            currentRow = selectedRow; // Assign the passed row to currentRow

            // Initialize your text boxes with the current row values using updated column names
            nametextBox.Text = currentRow.Cells["nameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            categoryTextBox.Text = currentRow.Cells["categoryDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            priceTextBox.Text = currentRow.Cells["priceDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            brandTextBox.Text = currentRow.Cells["brandDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            quantityTextBox.Text = currentRow.Cells["quantityDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            descriptionTextbox.Text = currentRow.Cells["descriptionDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            supplierTextBox.Text = currentRow.Cells["supplierDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
        }

        // Other methods remain unchanged
        


        private void editItemModal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void descriptionTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void supplierTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void brandTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cancelAddButton_Click(object sender, EventArgs e)
        {

        }



        private void addNewItemButtonModal_Click(object sender, EventArgs e)
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

                // Retrieve the original values from the selected row in dataGridView1 using the new column names
                string originalName = dataGridView1.CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                string originalBrand = dataGridView1.CurrentRow.Cells["brandDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                string originalCategory = dataGridView1.CurrentRow.Cells["categoryDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                decimal originalPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["priceDataGridViewTextBoxColumn"].Value?.ToString() ?? "0");
                int originalQuantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells["quantityDataGridViewTextBoxColumn"].Value?.ToString() ?? "0");
                string originalSupplier = dataGridView1.CurrentRow.Cells["supplierDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                string originalDescription = dataGridView1.CurrentRow.Cells["descriptionDataGridViewTextBoxColumn"].Value?.ToString() ?? "";

                // Compare the original data with the new data
                bool dataChanged = !(originalName == name && originalBrand == brand && originalCategory == category && originalPrice == price && originalQuantity == quantity && originalSupplier == supplier && originalDescription == description);

                if (dataChanged)
                {
                    // Call the UpdateComputerPart method asynchronously
                    bool success = await db.UpdateComputerPartAsync(name, brand, category, price, quantity, supplier, description);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
