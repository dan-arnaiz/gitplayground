public partial class YourForm : Form
{
    public YourForm()
    {
        InitializeComponent();

        // Subscribe to the RowsAdded and RowsRemoved events
        this.residentsTable.RowsAdded += new DataGridViewRowsAddedEventHandler(residentsTable_RowsAdded);
        this.residentsTable.RowsRemoved += new DataGridViewRowsRemovedEventHandler(residentsTable_RowsRemoved);

        // Initial update of row numbers
        UpdateRowNumbers();
    }

    private void residentsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Existing code here
    }

    private void residentsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        UpdateRowNumbers();
    }

    private void residentsTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        UpdateRowNumbers();
    }

    private void UpdateRowNumbers()
    {
        foreach (DataGridViewRow row in residentsTable.Rows)
        {
            row.Cells["numColumn"].Value = row.Index + 1; // Assuming numColumn is the name of your counter column
        }
    }
}