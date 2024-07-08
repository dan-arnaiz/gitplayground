private void barangaysDatatable_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    // Check if the click is on a row, not the column header
    if (e.RowIndex >= 0)
    {
        // Access the DataGridView
        DataGridView dgv = sender as DataGridView;
        if (dgv == null) return;

        // Get the 'barangayNameDataGridViewTextBoxColumn' column value of the clicked row
        string barangayName = dgv.Rows[e.RowIndex].Cells["barangayNameDataGridViewTextBoxColumn"].Value.ToString();
        string barangayAddress = dgv.Rows[e.RowIndex].Cells["addressDataGridViewTextBoxColumn"].Value.ToString();
        string barangayDescription = dgv.Rows[e.RowIndex].Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString();

        // Update the Text of barangayLabelTitle with the selected barangay name
        barangayLabelTitle.Text = barangayName;
        addressplaceholder.Text = barangayAddress;
        descriptionplaceholder.Text = barangayDescription;


        var cellValue = dgv.Rows[e.RowIndex].Cells["barangayLogoDataGridViewImageColumn"].Value;
        if (cellValue != DBNull.Value && cellValue is Image)
        {
            // Update the Image of BarangayLogoPlaceholder with the selected image
            BarangayLogoPlaceholder.Image = cellValue as Image;
        }
        else
        {
            // Optionally, set a default image if the cell value is not an image
            BarangayLogoPlaceholder.Image = null; // Or set to a default image
        }
    }

}