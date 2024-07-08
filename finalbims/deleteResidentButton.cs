private async void deleteResidentButton_Click(object sender, EventArgs e)
{
    if (residentsTable.SelectedRows.Count > 0)
    {
        var confirmResult = MessageBox.Show("Are you sure you want to delete this resident?",
                                            "Confirm Delete",
                                            MessageBoxButtons.YesNo);
        if (confirmResult == DialogResult.Yes)
        {
            int idColumnIndex = residentsTable.Columns["idDataGridViewTextBoxColumn"].Index; // Ensure this matches the actual column name in your DataGridView

            Database db = new Database();
            bool refreshNeeded = false;

            foreach (DataGridViewRow row in residentsTable.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    // Check for null value before calling ToString()
                    var cellValue = row.Cells[idColumnIndex].Value;
                    if (cellValue != null)
                    {
                        var residentId = cellValue.ToString();
                        bool success = await db.DeleteResidentAsync(residentId);
                        if (success)
                        {
                            residentsTable.Rows.Remove(row);
                            refreshNeeded = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete resident.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Resident ID is missing.");
                    }
                }
            }

            // If at least one row was successfully deleted, refresh the DataGridView
            if (refreshNeeded)
            {
                await db.RefreshResidentsTableAsync(residentsTable);
            }
        }
    }
    else
    {
        MessageBox.Show("Please select a row to delete.");
    }
}